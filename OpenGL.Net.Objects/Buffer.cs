<<<<<<< HEAD

// Copyright (C) 2009-2017 Luca Piccioni
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenGL.Objects
{
	/// <summary>
	/// Buffer object abstraction.
	/// </summary>
	/// <remarks>
	/// Implements:
	/// - Mapping
	/// - Immutable storage support (GL_ARB_buffer_storage)
	/// </remarks>
	public abstract class Buffer : GraphicsResource, IBindingResource
	{
		#region Constructors

		/// <summary>
		/// Construct a mutable Buffer determining its type, data usage and transfer mode.
		/// </summary>
		/// <param name="type">
		/// A <see cref="BufferTarget"/> that specify the buffer object type.
		/// </param>
		/// <param name="hint">
		/// An <see cref="BufferUsage"/> that specify the data buffer usage hints.
		/// </param>
		protected Buffer(BufferTarget type, BufferUsage hint)
		{
			// Store the buffer object type
			Target = type;
			// Store the buffer data usage hints
			Hint = hint;
			// Let be mutable
			Immutable = false;

			// Guess appropriate storage flags
			// Note: mutable storage is allowed to:
			// - be mapped for reading/writing
			// - specify information via glBufferSubData
			UsageMask = MapBufferUsageMask.MapReadBit | MapBufferUsageMask.MapWriteBit | MapBufferUsageMask.DynamicStorageBit;
		}

		/// <summary>
		/// Construct a immutable Buffer determining its type, data usage and storage mode.
		/// </summary>
		/// <param name="type">
		/// A <see cref="BufferTarget"/> that specify the buffer object type.
		/// </param>
		/// <param name="usageMask">
		/// An <see cref="MapBufferUsageMask"/> that specify the buffer storage usage mask.
		/// </param>
		protected Buffer(BufferTarget type, MapBufferUsageMask usageMask)
		{
			// Store the buffer object type
			Target = type;
			// Store the buffer usage mask
			UsageMask = usageMask;
			// Let be immutable
			Immutable = true;

			// Guess appropriate hint flags
			// Note: this flag is not actually used when buffer is immutable
			Hint = BufferUsage.StaticDraw;
		}
		
		#endregion

		#region Target

		/// <summary>
		/// Buffer target, indicating the buffer class.
		/// </summary>
		public readonly BufferTarget Target;

		/// <summary>
		/// The usage hint of this Buffer.
		/// </summary>
		public readonly BufferUsage Hint;

		/// <summary>
		/// Map storage flags, valid when GL_ARB_buffer_storage is implemented.
		/// </summary>
		public readonly MapBufferUsageMask UsageMask;

		#endregion

		#region Buffer Alignment

		/// <summary>
		/// The default memory alignment required for buffers.
		/// </summary>
		protected const uint DefaultBufferAlignment = 16;

		#endregion

		#region Technique

		/// <summary>
		/// Technique for creating/updating Buffer storage.
		/// </summary>
		protected abstract class Technique : IDisposable
		{
			/// <summary>
			/// Construct a Technique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			protected Technique(Buffer buffer)
			{
				if (buffer == null)
					throw new ArgumentNullException(nameof(buffer));
				Buffer = buffer;
			}

			/// <summary>
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </summary>
			protected readonly Buffer Buffer;

			/// <summary>
			/// Create the texture, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public abstract void Create(GraphicsContext ctx);

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			public virtual void Dispose() { }
		}

		/// <summary>
		/// Technique defining an empty buffer.
		/// </summary>
		protected sealed class EmptyCreateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="size">
			/// A <see cref="uint"/> that specifies the (new) size of <paramref name="buffer"/>.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			public EmptyCreateTechnique(Buffer buffer, uint size) :
				base(buffer)
			{
				if (size == 0)
					throw new ArgumentException("invalid", nameof(size));
				_Size = size;
			}

			#endregion

			#region Information

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly uint _Size;

			#endregion

			#region Overrides

			/// <summary>
			/// Create the texture, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				if (!Buffer.Immutable || !ctx.Extensions.BufferStorage_ARB)
					Gl.BufferData(Buffer.Target, _Size, IntPtr.Zero, Buffer.Hint);
				else
					Gl.BufferStorage(Buffer.Target, _Size, IntPtr.Zero, Buffer.UsageMask);
				Buffer.Size = _Size;
			}

			#endregion
		}

		/// <summary>
		/// Technique defining a buffer initialized with an <see cref="Array"/>.
		/// </summary>
		protected sealed class ArrayCreateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="array">
			/// A <see cref="Array"/> that specifies the (new) content of <paramref name="buffer"/>.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			public ArrayCreateTechnique(Buffer buffer, Array array) :
				base(buffer)
			{
				if (array == null)
					throw new ArgumentNullException(nameof(array));
				if (array.Length == 0)
					throw new ArgumentException("empty", nameof(array));

				Type elementType = array.GetType().GetElementType();
				if (elementType == null)
					throw new InvalidOperationException("unknown element type");
				if (!elementType.IsValueType)
					throw new ArgumentException("element is not a value type", nameof(array));

				_Array = array;
				_Size = (uint)(array.Length * Marshal.SizeOf(elementType));
			}

			#endregion

			#region Information

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly Array _Array;

			/// <summary>
			/// The effective size of <see cref="_Array"/>, in bytes.
			/// </summary>
			private readonly uint _Size;

			#endregion

			#region Overrides

			/// <summary>
			/// Create the texture, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				if (!Buffer.Immutable || !ctx.Extensions.BufferStorage_ARB)
					Gl.BufferData(Buffer.Target, _Size, _Array, Buffer.Hint);
				else
					Gl.BufferStorage(Buffer.Target, _Size, _Array, Buffer.UsageMask);
				Buffer.Size = _Size;
			}

			#endregion
		}

		/// <summary>
		/// Technique updating a buffer with an <see cref="Array"/>.
		/// </summary>
		protected sealed class ArrayUpdateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="array">
			/// A <see cref="Array"/> that specifies the (new) content of <paramref name="buffer"/>.
			/// </param>
			/// <param name="bufferOffset">
			/// A <see cref="uint"/> that specifies the offset of the content to be updated, in bytes.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			/// <exception cref="ArgumentException">
			/// Exception thrown if <paramref name="buffer"/> is immutable.
			/// </exception>
			public ArrayUpdateTechnique(Buffer buffer, Array array, uint bufferOffset = 0) :
				base(buffer)
			{
				if (buffer.Immutable)
					throw new ArgumentException("immutable", nameof(buffer));
				_Array = array;
				_BufferOffset = bufferOffset;
			}

			#endregion

			#region Overrides

			/// <summary>
			/// Create the texture, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				Gl.BufferSubData(Buffer.Target, new IntPtr(_BufferOffset), (uint)_Array.Length, _Array);
			}

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly Array _Array;

			/// <summary>
			/// The offset of the content to be updated, in bytes.
			/// </summary>
			private readonly uint _BufferOffset;

			#endregion
		}

		/// <summary>
		/// Set the technique used for creating and updating this Texture.
		/// </summary>
		/// <param name="technique">
		/// The <see cref="Technique"/> that specify the method creating/updating this Texture.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="technique"/> is null.
		/// </exception>
		protected void AddTechnique(Technique technique)
		{
			if (technique == null)
				throw new ArgumentNullException(nameof(technique));

			// Set technique
			_Techniques.Add(technique);
		}

		/// <summary>
		/// Technique used for creating this texture.
		/// </summary>
		private readonly List<Technique> _Techniques = new List<Technique>();

		#endregion

		#region GPU Buffer

		/// <summary>
		/// The size of this Buffer, in bytes.
		/// </summary>
		public virtual uint Size { get; protected set; }

		/// <summary>
		/// Get the address of the GPU buffer used to specify the vertex arrays (i.e. glVertexAttribPointer).
		/// </summary>
		protected internal IntPtr GpuBufferAddress
		{
			get { return GpuBuffer?.AlignedBuffer ?? IntPtr.Zero; }
		}

		/// <summary>
		/// A <see cref="AlignedMemoryBuffer"/> instance for simulating the GPU buffer in the case GL_ARB_vertex_array_object is not supported.
		/// </summary>
		protected AlignedMemoryBuffer GpuBuffer;

		#endregion

		#region Mapping

		/// <summary>
		/// Map the GPU buffer allocated by this Buffer.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> required for mapping this Buffer.
		/// </param>
		/// <param name="mask">
		/// A <see cref="BufferAccess"/> that specify the map access.
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is already mapped.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer does not exist for <paramref name="ctx"/>.
		/// </exception>
		public void Map(GraphicsContext ctx, BufferAccess mask)
		{
			CheckThisExistence(ctx);

			Debug.Assert(ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES) || GpuBuffer != null);

			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES)) {
				ctx.Bind(this);

				MappedBuffer = Gl.MapBuffer(Target, mask);
			} else
				MappedBuffer = GpuBuffer.AlignedBuffer;
		}

		/// <summary>
		/// Unmap this Buffer data.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer has been corrupted after being unmapped.
		/// </exception>
		public void Unmap(GraphicsContext ctx)
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES)) {
				// Unmap buffer object data (resident on server)
				bool uncorrupted = Gl.UnmapBuffer(Target);

				if (uncorrupted == false)
					throw new InvalidOperationException("corrupted buffer");
			}
			// Removes reference for mapped buffer data
			MappedBuffer = IntPtr.Zero;
		}

		/// <summary>
		/// Check whether this Buffer data is mapped.
		/// </summary>
		public bool IsMapped { get { return MappedBuffer != IntPtr.Zero; } }

		/// <summary>
		/// Get the tointer to the mapped GPU buffer.
		/// </summary>
		public IntPtr MappedBuffer { get; private set; } = IntPtr.Zero;

		/// <summary>
		/// Set an element to this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="value">
		/// A <typeparamref name="T"/> that specify the mapped Buffer element.
		/// </param>
		/// <param name="offset">
		/// A <see cref="UInt64"/> that specify the offset applied to the mapped Buffer where <paramref name="value"/>
		/// is stored. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		public void Set<T>(T value, ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				Unsafe.Write((byte*)MappedBuffer.ToPointer() + offset, value);
			}
#else
			throw new NotImplementedException();
#endif
		}

		/// <summary>
		/// Set an array of elements to this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="array">
		/// A <typeparamref name="T:T[]"/> that specify the mapped Buffer element.
		/// </param>
		/// <param name="offset">
		/// A <see cref="ulong"/> that specify the offset applied to the mapped Buffer where <paramref name="array"/>
		/// is stored. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		public void Set<T>(T[] array, ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				byte* ptr = (byte*)MappedBuffer.ToPointer() + offset;
				int stride = Marshal.SizeOf(typeof(T));

				for (int i = 0; i < array.Length; i++, ptr += stride)
					Unsafe.Write(ptr, array[i]);
			}
#else
			throw new NotImplementedException();
#endif
		}

		/// <summary>
		/// Get an element from this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="offset">
		/// A <see cref="UInt64"/> that specify the offset applied to the mapped Buffer to get the stored
		/// value. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <returns>
		/// It returns a structure of type <typeparamref name="T"/>, read from the mapped Buffer
		/// </returns>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		public T Get<T>(ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				return Unsafe.Read<T>((byte*)MappedBuffer.ToPointer() + offset);
			}
#else
			throw new NotImplementedException();
#endif
		}

		#endregion

		#region Immutable Storage

		/// <summary>
		/// Get whether this Buffer is immutable (GL_ARB_buffer_storage).
		/// </summary>
		public readonly bool Immutable;

		#endregion

		#region GraphicsResource Overrides

		/// <summary>
		/// Buffer object class.
		/// </summary>
		internal static readonly Guid ThisObjectClass = new Guid("BFE3C5F0-4E22-49F1-9AD6-4DB4B2711B67");

		/// <summary>
		/// Buffer object class.
		/// </summary>
		public override Guid ObjectClass { get { return ThisObjectClass; } }

		/// <summary>
		/// Determine whether this Buffer really exists for a specific context.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> that would have created (or a sharing one) the object. This context shall be current to
		/// the calling thread.
		/// </param>
		/// <returns>
		/// It returns a boolean value indicating whether this Buffer exists in the object space of <paramref name="ctx"/>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The object existence is done by checking a valid object by its name <see cref="IGraphicsResource.ObjectName"/>. This routine will test whether
		/// <paramref name="ctx"/> has created this Buffer (or is sharing with the creator).
		/// </para>
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		public override bool Exists(GraphicsContext ctx)
		{
			// Object name space test (and 'ctx' sanity checks)
			if (base.Exists(ctx) == false)
				return false;

			return ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES) ? Gl.IsBuffer(ObjectName) : GpuBuffer != null;
		}

		/// <summary>
		/// Create a Buffer name.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for creating this buffer object name.
		/// </param>
		/// <returns>
		/// It returns a valid object name for this Buffer.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		protected override uint CreateName(GraphicsContext ctx)
		{
			CheckCurrentContext(ctx);

			Debug.Assert(ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES));

			return Gl.GenBuffer();
		}

		/// <summary>
		/// Delete a Buffer name.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for deleting this buffer object name.
		/// </param>
		/// <param name="name">
		/// A <see cref="UInt32"/> that specify the object name to delete.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer does not exist.
		/// </exception>
		protected override void DeleteName(GraphicsContext ctx, uint name)
		{
			CheckThisExistence(ctx);

			Debug.Assert(ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES));

			// Delete buffer object
			Gl.DeleteBuffers(name);
		}

		/// <summary>
		/// Actually create this Buffer resources.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for allocating resources.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is currently mapped.
		/// </exception>
		protected override void CreateObject(GraphicsContext ctx)
		{
			CheckCurrentContext(ctx);

			// Buffer must be bound
			ctx.Bind(this, true);

			if (_Techniques.Count > 0) {
				
				// Note: in the case of no techniques, texture will exists but it will be undefined (no storage defined)

				foreach (Technique technique in _Techniques) {
					// Create/update texture using technique
					technique.Create(ctx);
					// Technique no more useful: dispose it
					technique.Dispose();
				}

				// Layers updated only once
				_Techniques.Clear();
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting managed/unmanaged resources.
		/// </summary>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown in the case <see cref="GraphicsResource.RefCount"/> is greater than zero. This means that the method is trying to dispose
		/// an object that is actually referenced by something else.
		/// </exception>
		protected override void Dispose(bool disposing)
		{
			// Base implementation
			base.Dispose(disposing);
			
			if (disposing)
				GpuBuffer?.Dispose();
		}

		#endregion

		#region IBindingResource Implementation

		/// <summary>
		/// Get the identifier of the binding point.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		int IBindingResource.GetBindingTarget(GraphicsContext ctx)
		{
			// Cannot lazy binding on buffer objects if GL_ARB_vertex_array_object is not supported
			if (!ctx.Extensions.VertexArrayObject_ARB && !ctx.Version.IsCompatible(Gl.Version_200_ES))
				return 0;
				
			// All-in-one implementation for all targets
			switch (Target) {
				case BufferTarget.ArrayBuffer:
					return Gl.ARRAY_BUFFER_BINDING;
				case BufferTarget.ElementArrayBuffer:
					return Gl.ELEMENT_ARRAY_BUFFER_BINDING;
				case BufferTarget.TransformFeedbackBuffer:
					return Gl.TRANSFORM_FEEDBACK_BINDING;
				case BufferTarget.UniformBuffer:
					return Gl.UNIFORM_BUFFER;
				case BufferTarget.ShaderStorageBuffer:
					return Gl.SHADER_STORAGE_BUFFER_BINDING;

				default:
					throw new NotSupportedException($"buffer target {Target} not supported");
			}
		}

		/// <summary>
		/// Bind this IBindingResource.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		void IBindingResource.Bind(GraphicsContext ctx)
		{
			BindCore(ctx);
		}

		/// <summary>
		/// Virtual Bind implementation.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		protected virtual void BindCore(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES))
				Gl.BindBuffer(Target, ObjectName);
		}

		/// <summary>
		/// Bind this IBindingResource.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		void IBindingResource.Unbind(GraphicsContext ctx)
		{
			CheckThisExistence(ctx);

			UnbindCore(ctx);
		}

		/// <summary>
		/// Virtual Unbind implementation.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		protected virtual void UnbindCore(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES))
				Gl.BindBuffer(Target, InvalidObjectName);
		}

		/// <summary>
		/// Check whether this IBindingResource is currently bound on the specified graphics context.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for querying the current binding state.
		/// </param>
		/// <returns>
		/// It returns a boolean value indicating whether this IBindingResource is currently bound on <paramref name="ctx"/>.
		/// </returns>
		bool IBindingResource.IsBound(GraphicsContext ctx)
		{
			int bindingTarget = ((IBindingResource)this).GetBindingTarget(ctx);
			int currentBufferObject;

			Debug.Assert(bindingTarget != 0);
			Gl.Get(bindingTarget, out currentBufferObject);

			return currentBufferObject == (int)ObjectName;
		}

		#endregion
	}
}
=======

// Copyright (C) 2009-2017 Luca Piccioni
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenGL.Objects
{
	/// <summary>
	/// Buffer object abstraction.
	/// </summary>
	/// <remarks>
	/// Implements:
	/// - Mapping
	/// - Immutable storage support (GL_ARB_buffer_storage)
	/// </remarks>
	public abstract class Buffer : GraphicsResource, IBindingResource, IBindingIndexResource
	{
		#region Constructors

		/// <summary>
		/// Construct a mutable Buffer determining its type, data usage and transfer mode.
		/// </summary>
		/// <param name="type">
		/// A <see cref="BufferTarget"/> that specify the buffer object type.
		/// </param>
		/// <param name="hint">
		/// An <see cref="BufferUsage"/> that specify the data buffer usage hints.
		/// </param>
		protected Buffer(BufferTarget type, BufferUsage hint)
		{
			// Store the buffer object type
			Target = type;
			// Store the buffer data usage hints
			Hint = hint;
			// Let be mutable
			Immutable = false;

			// Guess appropriate storage flags
			// Note: mutable storage is allowed to:
			// - be mapped for reading/writing
			// - specify information via glBufferSubData
			UsageMask = MapBufferUsageMask.MapReadBit | MapBufferUsageMask.MapWriteBit | MapBufferUsageMask.DynamicStorageBit;
		}

		/// <summary>
		/// Construct a immutable Buffer determining its type, data usage and storage mode.
		/// </summary>
		/// <param name="type">
		/// A <see cref="BufferTarget"/> that specify the buffer object type.
		/// </param>
		/// <param name="usageMask">
		/// An <see cref="MapBufferUsageMask"/> that specify the buffer storage usage mask.
		/// </param>
		protected Buffer(BufferTarget type, MapBufferUsageMask usageMask)
		{
			// Store the buffer object type
			Target = type;
			// Store the buffer usage mask
			UsageMask = usageMask;
			// Let be immutable
			Immutable = true;

			// Guess appropriate hint flags
			// Note: this flag is not actually used when buffer is immutable
			Hint = BufferUsage.StaticDraw;
		}
		
		#endregion

		#region Target

		/// <summary>
		/// Buffer target, indicating the buffer class.
		/// </summary>
		public readonly BufferTarget Target;

		/// <summary>
		/// The usage hint of this Buffer.
		/// </summary>
		public readonly BufferUsage Hint;

		/// <summary>
		/// Map storage flags, valid when GL_ARB_buffer_storage is implemented.
		/// </summary>
		public readonly MapBufferUsageMask UsageMask;

		#endregion

		#region Buffer Alignment

		/// <summary>
		/// The default memory alignment required for buffers.
		/// </summary>
		protected const uint DefaultBufferAlignment = 16;

		#endregion

		#region Technique

		/// <summary>
		/// Technique for creating/updating Buffer storage.
		/// </summary>
		protected abstract class Technique : IDisposable
		{
			/// <summary>
			/// Construct a Technique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			protected Technique(Buffer buffer)
			{
				if (buffer == null)
					throw new ArgumentNullException(nameof(buffer));
				Buffer = buffer;
			}

			/// <summary>
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </summary>
			protected readonly Buffer Buffer;

			/// <summary>
			/// Update the reference Buffer, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public abstract void Create(GraphicsContext ctx);

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			public virtual void Dispose() { }
		}

		/// <summary>
		/// Technique defining an empty buffer.
		/// </summary>
		protected sealed class EmptyCreateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="size">
			/// A <see cref="uint"/> that specifies the (new) size of <paramref name="buffer"/>.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			public EmptyCreateTechnique(Buffer buffer, uint size) :
				base(buffer)
			{
				if (size == 0)
					throw new ArgumentException("invalid", nameof(size));
				_Size = size;
			}

			#endregion

			#region Information

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly uint _Size;

			#endregion

			#region Overrides

			/// <summary>
			/// Update the reference Buffer, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
					CreateDSA(ctx);
				} else {
					CreateCompatible(ctx);
				}

				// Explictly check for errors
				Gl.CheckErrors();
				
				Buffer.Size = _Size;
			}

			private void CreateCompatible(GraphicsContext ctx)
			{
				if (!ctx.Extensions.BufferStorage_ARB || !Buffer.Immutable) {
					
					// Emulates glBufferStorage error checking (only for size)
					if (Buffer.Immutable && Buffer.Size != 0)
						throw new GlException(ErrorCode.InvalidOperation);

					Gl.BufferData(Buffer.Target, _Size, IntPtr.Zero, Buffer.Hint);

				} else {

					if (Buffer.Immutable)
						Gl.BufferStorage(Buffer.Target, _Size, IntPtr.Zero, Buffer.UsageMask);
					else
						Gl.BufferData(Buffer.Target, _Size, IntPtr.Zero, Buffer.Hint);
				}
			}

			private void CreateDSA(GraphicsContext ctx)
			{
				if (!ctx.Extensions.BufferStorage_ARB || !Buffer.Immutable) {
					
					// Emulates glBufferStorage error checking (only for size)
					if (Buffer.Immutable && Buffer.Size != 0)
						throw new GlException(ErrorCode.InvalidOperation);

					Gl.NamedBufferData(Buffer.ObjectName,  _Size, IntPtr.Zero, Buffer.Hint);

				} else {

					if (Buffer.Immutable)
						Gl.NamedBufferStorage(Buffer.ObjectName, _Size, IntPtr.Zero, Buffer.UsageMask);
					else
						Gl.NamedBufferData(Buffer.ObjectName, _Size, IntPtr.Zero, Buffer.Hint);

				}
			}

			#endregion
		}

		/// <summary>
		/// Technique defining a buffer initialized with an <see cref="Array"/>.
		/// </summary>
		protected sealed class ArrayCreateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="array">
			/// A <see cref="Array"/> that specifies the (new) content of <paramref name="buffer"/>.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			public ArrayCreateTechnique(Buffer buffer, Array array) :
				base(buffer)
			{
				if (array == null)
					throw new ArgumentNullException(nameof(array));
				if (array.Length == 0)
					throw new ArgumentException("empty", nameof(array));

				Type elementType = array.GetType().GetElementType();
				if (elementType == null)
					throw new InvalidOperationException("unknown element type");
				if (!elementType.IsValueType)
					throw new ArgumentException("element is not a value type", nameof(array));

				_Array = array;
				_Size = (uint)(array.Length * Marshal.SizeOf(elementType));
			}

			#endregion

			#region Information

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly Array _Array;

			/// <summary>
			/// The effective size of <see cref="_Array"/>, in bytes.
			/// </summary>
			private readonly uint _Size;

			#endregion

			#region Overrides

			/// <summary>
			/// Update the reference Buffer, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
					if (!ctx.Extensions.BufferStorage_ARB || !Buffer.Immutable) {
					
						// Emulates glBufferStorage error checking (only for size)
						if (Buffer.Immutable && Buffer.Size != 0)
							throw new GlException(ErrorCode.InvalidOperation);

						Gl.NamedBufferData(Buffer.ObjectName, _Size, _Array, Buffer.Hint);

					} else {

						if (Buffer.Immutable)
							Gl.NamedBufferStorage(Buffer.ObjectName, _Size, _Array, Buffer.UsageMask);
						else
							Gl.NamedBufferData(Buffer.ObjectName, _Size, _Array, Buffer.Hint);
					}
				} else {
					if (!ctx.Extensions.BufferStorage_ARB || !Buffer.Immutable) {
					
						// Emulates glBufferStorage error checking (only for size)
						if (Buffer.Immutable && Buffer.Size != 0)
							throw new GlException(ErrorCode.InvalidOperation);

						Gl.BufferData(Buffer.Target, _Size, _Array, Buffer.Hint);

					} else {

						if (Buffer.Immutable)
							Gl.BufferStorage(Buffer.Target, _Size, _Array, Buffer.UsageMask);
						else
							Gl.BufferData(Buffer.Target, _Size, _Array, Buffer.Hint);
					}
				}

				// Explictly check for errors
				Gl.CheckErrors();
				
				Buffer.Size = _Size;
			}

			#endregion
		}

		/// <summary>
		/// Technique updating a buffer with an <see cref="Array"/>.
		/// </summary>
		protected sealed class ArrayUpdateTechnique : Technique
		{
			#region Construtors

			/// <summary>
			/// Construct a EmptyCreateTechnique.
			/// </summary>
			/// <param name="buffer">
			/// The <see cref="Buffer"/> affected by this Technique.
			/// </param>
			/// <param name="array">
			/// A <see cref="Array"/> that specifies the (new) content of <paramref name="buffer"/>.
			/// </param>
			/// <param name="bufferOffset">
			/// A <see cref="uint"/> that specifies the offset of the content to be updated, in bytes.
			/// </param>
			/// <exception cref="ArgumentNullException">
			/// Exception thrown if <paramref name="buffer"/> is null.
			/// </exception>
			/// <exception cref="ArgumentException">
			/// Exception thrown if <paramref name="buffer"/> is immutable.
			/// </exception>
			public ArrayUpdateTechnique(Buffer buffer, Array array, uint bufferOffset = 0) :
				base(buffer)
			{
				if (buffer.Immutable)
					throw new ArgumentException("immutable buffer", nameof(buffer));
				_Array = array;
				_BufferOffset = bufferOffset;
			}

			#endregion

			#region Overrides

			/// <summary>
			/// Update the reference Buffer, using this technique.
			/// </summary>
			/// <param name="ctx">
			/// A <see cref="GraphicsContext"/> used for allocating resources.
			/// </param>
			public override void Create(GraphicsContext ctx)
			{
				Gl.BufferSubData(Buffer.Target, new IntPtr(_BufferOffset), (uint)_Array.Length, _Array);
			}

			/// <summary>
			/// Size of the Buffer, in bytes.
			/// </summary>
			private readonly Array _Array;

			/// <summary>
			/// The offset of the content to be updated, in bytes.
			/// </summary>
			private readonly uint _BufferOffset;

			#endregion
		}

		/// <summary>
		/// Set the technique used for creating and updating this Texture.
		/// </summary>
		/// <param name="technique">
		/// The <see cref="Technique"/> that specify the method creating/updating this Texture.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="technique"/> is null.
		/// </exception>
		protected void AddTechnique(Technique technique)
		{
			if (technique == null)
				throw new ArgumentNullException(nameof(technique));

			// Set technique
			_Techniques.Add(technique);
		}

		/// <summary>
		/// Technique used for creating this texture.
		/// </summary>
		private readonly List<Technique> _Techniques = new List<Technique>();

		#endregion

		#region GPU Buffer

		/// <summary>
		/// The size of this Buffer, in bytes.
		/// </summary>
		public virtual uint Size { get; protected set; }

		/// <summary>
		/// Get the address of the GPU buffer used to specify the vertex arrays (i.e. glVertexAttribPointer).
		/// </summary>
		protected internal IntPtr GpuBufferAddress
		{
			get { return GpuBuffer?.AlignedBuffer ?? IntPtr.Zero; }
		}

		/// <summary>
		/// A <see cref="AlignedMemoryBuffer"/> instance for simulating the GPU buffer in the case GL_ARB_vertex_array_object is not supported.
		/// </summary>
		protected AlignedMemoryBuffer GpuBuffer;

		#endregion

		#region Mapping

		/// <summary>
		/// Map the GPU buffer allocated by this Buffer.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> required for mapping this Buffer.
		/// </param>
		/// <param name="mask">
		/// A <see cref="BufferAccess"/> that specify the map access.
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is already mapped.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer does not exist for <paramref name="ctx"/>.
		/// </exception>
		public void Map(GraphicsContext ctx, BufferAccess mask)
		{
			CheckThisExistence(ctx);

			if (IsMapSupported(ctx)) {
#if !MONODROID
				if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
					if ((MappedBuffer = Gl.MapNamedBuffer(ObjectName, mask)) == IntPtr.Zero)
						Gl.CheckErrors();
				} else {
#endif
					ctx.Bind(this);

					if ((MappedBuffer = Gl.MapBuffer(Target, mask)) == IntPtr.Zero)
						Gl.CheckErrors();
#if !MONODROID
				}
#endif
			} else {

				if (GpuBuffer == null)
					throw new GlException(ErrorCode.InvalidOperation);
				if ((MappedBuffer = GpuBuffer.AlignedBuffer) == IntPtr.Zero)
					throw new GlException(ErrorCode.InvalidOperation);
			}

			Debug.Assert(MappedBuffer != IntPtr.Zero);

			MapOffset = IntPtr.Zero;
			MapSize = Size;
			_Access = mask;
		}

		/// <summary>
		/// Determine whether glMapBuffer is supported.
		/// </summary>
		/// <param name="ctx">
		/// The <see cref="GraphicsContext"/> which is executed glMaBuffer on.
		/// </param>
		/// <returns>
		/// It returns whether glMapBuffer is available on <paramref name="ctx"/>.
		/// </returns>
		private bool IsMapSupported(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexBufferObject_ARB)
				return true;
			if (ctx.Extensions.Mapbuffer_OES)
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_150))
				return true;

			return false;
		}

		/// <summary>
		/// Map a range of the GPU buffer allocated by this Buffer.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> required for mapping this Buffer.
		/// </param>
		/// <param name="mask">
		/// A <see cref="BufferAccessMask"/> that specify the map access.
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is already mapped.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer does not exist for <paramref name="ctx"/>.
		/// </exception>
		public void Map(GraphicsContext ctx, BufferAccessMask mask, IntPtr offset = default(IntPtr), uint size = 0)
		{
			CheckThisExistence(ctx);

			uint mapSize = size != 0 ? size : Size;

			if (IsMapRangeSupported(ctx)) {
#if !MONODROID
				if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
					if ((MappedBuffer = Gl.MapNamedBufferRange(ObjectName, offset, mapSize, mask)) == IntPtr.Zero)
						Gl.CheckErrors();
				} else {
#endif
					ctx.Bind(this);

					if ((MappedBuffer = Gl.MapBufferRange(Target, offset, mapSize, mask)) == IntPtr.Zero)
						Gl.CheckErrors();
#if !MONODROID
				}
#endif
			} else {

				if (GpuBuffer == null)
					throw new GlException(ErrorCode.InvalidOperation);
				if (GpuBuffer.AlignedBuffer == IntPtr.Zero)
					throw new GlException(ErrorCode.InvalidOperation);

				MappedBuffer = new IntPtr(GpuBuffer.AlignedBuffer.ToInt64() + offset.ToInt64());
			}

			// Determine map access
			if (mask.HasFlag(BufferAccessMask.MapReadBit) && mask.HasFlag(BufferAccessMask.MapWriteBit))
				_Access = BufferAccess.ReadWrite;
			else if (mask.HasFlag(BufferAccessMask.MapReadBit))
				_Access = BufferAccess.ReadOnly;
			else if (mask.HasFlag(BufferAccessMask.MapWriteBit))
				_Access = BufferAccess.WriteOnly;
			else
				_Access = 0;

			Debug.Assert(MappedBuffer != IntPtr.Zero);

			MapOffset = offset;
			MapSize = mapSize;
			_AccessMask = mask;
		}

		/// <summary>
		/// Determine whether glMapBufferRange is supported.
		/// </summary>
		/// <param name="ctx">
		/// The <see cref="GraphicsContext"/> which is executed glMapBufferRange on.
		/// </param>
		/// <returns>
		/// It returns whether glMapBufferRange is available on <paramref name="ctx"/>.
		/// </returns>
		private bool IsMapRangeSupported(GraphicsContext ctx)
		{
			if (ctx.Extensions.MapBufferRange_ARB)
				return true;
			if (ctx.Extensions.MapBufferRange_EXT)
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_300))
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_300_ES))
				return true;

			return false;
		}

		/// <summary>
		/// Unmap this Buffer data.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer has been corrupted after being unmapped.
		/// </exception>
		public void Unmap(GraphicsContext ctx)
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

			// Removes reference for mapped buffer data
			MappedBuffer = IntPtr.Zero;
			MapOffset = IntPtr.Zero;
			MapSize = 0;

			if (IsMapSupported(ctx) || IsMapRangeSupported(ctx)) {
				bool uncorrupted;

				if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
					uncorrupted = Gl.UnmapNamedBuffer(ObjectName);
				} else {
					ctx.Bind(this);
					uncorrupted = Gl.UnmapBuffer(Target);
				}

				if (uncorrupted == false)
					throw new InvalidOperationException("corrupted buffer");
			}
		}

		/// <summary>
		/// Check whether this Buffer data is mapped.
		/// </summary>
		public bool IsMapped { get { return MappedBuffer != IntPtr.Zero; } }

		/// <summary>
		/// Get the pointer to the mapped GPU buffer.
		/// </summary>
		public IntPtr MappedBuffer { get; private set; } = IntPtr.Zero;
		
		/// <summary>
		/// Get the offset of <see cref="MappedBuffer"/> respect the GPU buffer.
		/// </summary>
		public IntPtr MapOffset { get; private set; } = IntPtr.Zero;

		/// <summary>
		/// Get the number of bytes of GPU buffer are mapped by <see cref="MappedBuffer"/>.
		/// </summary>
		public uint MapSize { get; private set; } = 0;

		/// <summary>
		/// The access mask requested on last Map call.
		/// </summary>
		private BufferAccess _Access = 0;

		/// <summary>
		/// The access mask requested on last Map call.
		/// </summary>
		private BufferAccessMask _AccessMask = 0;

		#endregion

		#region Mapping Tracking

		public IDisposable CreateMapGuard(GraphicsContext ctx, BufferAccess mask)
		{
			return new Mapper(ctx, this, mask);
		}

		private class Mapper : IDisposable
		{
			public Mapper(GraphicsContext ctx, Buffer thisBuffer, BufferAccess mask)
			{
				CheckCurrentContext(ctx);
				CheckThatExistence(ctx, thisBuffer);

				_Context = ctx;
				_Buffer = thisBuffer;

				// Leave unmapped if not mapped yet
				_UnmapOnDispose = thisBuffer.MappedBuffer == IntPtr.Zero;

				if (_UnmapOnDispose)
					_Buffer.Map(_Context, mask);
			}

			private GraphicsContext _Context;

			private Buffer _Buffer;

			private bool _UnmapOnDispose;

			public void Dispose()
			{
				if (_UnmapOnDispose)
					_Buffer.Unmap(_Context);
			}
		}

		#endregion

		#region Mapped I/O

		/// <summary>
		/// Indicate modifications to a range of the mapped buffer <see cref="MappedBuffer"/>.
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="offset">
		/// Specifies the start of the buffer subrange, in basic machine units.
		/// </param>
		/// <param name="size">
		/// Specifies the length of the buffer subrange, in basic machine units.
		/// </param>
		public void Flush(GraphicsContext ctx, IntPtr offset = default(IntPtr), uint size = 0)
		{
			CheckThisExistence(ctx);
			if (!IsMapped)
				throw new InvalidOperationException("not mapped");

			// Should we throw an exception?
			if (!_AccessMask.HasFlag(BufferAccessMask.MapFlushExplicitBit))
				return;
			if (!IsFlushSupported(ctx))
				return;

			uint mapSize = size != 0 ? size : Size;

			if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)) {
				Gl.FlushMappedNamedBufferRange(ObjectName, offset, mapSize);
			} else {
				ctx.Bind(this);

				Gl.FlushMappedBufferRange(Target, offset, mapSize);
			}
		}

		/// <summary>
		/// Determine whether glFlushMappedBufferRange is supported.
		/// </summary>
		/// <param name="ctx">
		/// The <see cref="GraphicsContext"/> which is executed glFlushMappedBufferRange on.
		/// </param>
		/// <returns>
		/// It returns whether glFlushMappedBufferRange is available on <paramref name="ctx"/>.
		/// </returns>
		private bool IsFlushSupported(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexArrayObject_ARB)
				return true;
			if (ctx.Extensions.VertexArrayObject_OES)
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_300))
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_300_ES))
				return true;

			return false;
		}

		/// <summary>
		/// Read a structure from this BufferObject.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public T Load<T>(GraphicsContext ctx, ulong offset = 0) where T : struct
		{
			using (CreateMapGuard(ctx, BufferAccess.ReadOnly))
				return Get<T>(offset);
		}

		public void Store<T>(GraphicsContext ctx, T value, ulong offset = 0) where T : struct
		{
			using (CreateMapGuard(ctx, BufferAccess.WriteOnly))
				Set(value, offset);
		}

		/// <summary>
		/// Read an array from this BufferObject
		/// </summary>
		/// <param name="ctx"></param>
		/// <param name="value"></param>
		/// <param name="size"></param>
		/// <param name="offset"></param>
		public void Load(GraphicsContext ctx, Array value, ulong size, ulong offset = 0)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			using (CreateMapGuard(ctx, BufferAccess.ReadOnly))
				Memory.Copy(value, new IntPtr(MappedBuffer.ToInt64() + (long)offset), size);
		}

		/// <summary>
		/// Store an array to this BufferObject.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ctx"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public void Store(GraphicsContext ctx, Array value, ulong size, ulong offset = 0)
		{
			using (CreateMapGuard(ctx, BufferAccess.ReadOnly))
				Memory.Copy(new IntPtr(MappedBuffer.ToInt64() + (long)offset), value, size);
		}

		/// <summary>
		/// Set an value to this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="value">
		/// A <typeparamref name="T"/> that specify the mapped Buffer element.
		/// </param>
		/// <param name="offset">
		/// A <see cref="UInt64"/> that specify the offset applied to the mapped Buffer where <paramref name="value"/>
		/// is stored. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		protected void Set<T>(T value, ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				Unsafe.Write((byte*)MappedBuffer.ToPointer() + offset, value);
			}
#else
			throw new NotImplementedException();
#endif
		}

		/// <summary>
		/// Set an array of elements to this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="array">
		/// A <typeparamref name="T:T[]"/> that specify the mapped Buffer element.
		/// </param>
		/// <param name="offset">
		/// A <see cref="ulong"/> that specify the offset applied to the mapped Buffer where <paramref name="array"/>
		/// is stored. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		protected void Set<T>(T[] array, ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				byte* ptr = (byte*)MappedBuffer.ToPointer() + offset;
				int stride = Marshal.SizeOf(typeof(T));

				for (int i = 0; i < array.Length; i++, ptr += stride)
					Unsafe.Write(ptr, array[i]);
			}
#else
			throw new NotImplementedException();
#endif
		}

		/// <summary>
		/// Get an element from this mapped Buffer.
		/// </summary>
		/// <typeparam name="T">
		/// A structure representing this Buffer element.
		/// </typeparam>
		/// <param name="offset">
		/// A <see cref="UInt64"/> that specify the offset applied to the mapped Buffer to get the stored
		/// value. This value is expressed in basic machine units (bytes).
		/// </param>
		/// <returns>
		/// It returns a structure of type <typeparamref name="T"/>, read from the mapped Buffer
		/// </returns>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is not mapped (<see cref="IsMapped"/>).
		/// </exception>
		protected T Get<T>(ulong offset) where T : struct
		{
			if (IsMapped == false)
				throw new InvalidOperationException("not mapped");

#if HAVE_UNSAFE
			unsafe
			{
				return Unsafe.Read<T>((byte*)MappedBuffer.ToPointer() + offset);
			}
#else
			throw new NotImplementedException();
#endif
		}

		#endregion

		#region Immutable Storage

		/// <summary>
		/// Get whether this Buffer is immutable (GL_ARB_buffer_storage).
		/// </summary>
		public readonly bool Immutable;

		#endregion

		#region Invalidation

		/// <summary>
		/// Invalidate the content of this Buffer.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> that created this Buffer.
		/// </param>
		public void Invalidate(GraphicsContext ctx)
		{
			if (ctx.Extensions.InvalidateSubdata_ARB || ctx.Version.IsCompatible(Gl.Version_430))
				Gl.InvalidateBufferData(ObjectName);
			else {
				if (!Immutable && RequiresName(ctx)) {
					ctx.Bind(this);
					Gl.BufferData(Target, Size, IntPtr.Zero, Hint);
				}
			}

			Gl.CheckErrors();
		}

		/// <summary>
		/// Invalidate a range of the content of this Buffer.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> that created this Buffer.
		/// </param>
		public void Invalidate(GraphicsContext ctx, IntPtr offset, uint length)
		{
			if (ctx.Extensions.InvalidateSubdata_ARB || ctx.Version.IsCompatible(Gl.Version_430))
				Gl.InvalidateBufferSubData(ObjectName, offset, length);
			else {
				if (!Immutable && RequiresName(ctx)) {
					ctx.Bind(this);
					Gl.BufferSubData(Target, offset, length, IntPtr.Zero);
				}
			}

			Gl.CheckErrors();
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Buffer object class.
		/// </summary>
		internal static readonly Guid ThisObjectClass = new Guid("BFE3C5F0-4E22-49F1-9AD6-4DB4B2711B67");

		/// <summary>
		/// Buffer object class.
		/// </summary>
		public override Guid ObjectClass { get { return ThisObjectClass; } }

		/// <summary>
		/// Determine whether this Buffer really exists for a specific context.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> that would have created (or a sharing one) the object. This context shall be current to
		/// the calling thread.
		/// </param>
		/// <returns>
		/// It returns a boolean value indicating whether this Buffer exists in the object space of <paramref name="ctx"/>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The object existence is done by checking a valid object by its name <see cref="IGraphicsResource.ObjectName"/>. This routine will test whether
		/// <paramref name="ctx"/> has created this Buffer (or is sharing with the creator).
		/// </para>
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		public override bool Exists(GraphicsContext ctx)
		{
			// Object name space test (and 'ctx' sanity checks)
			if (base.Exists(ctx) == false)
				return false;

			return RequiresName(ctx) ? Gl.IsBuffer(ObjectName) : GpuBuffer != null;
		}

		/// <summary>
		/// Determine whether this object requires a name bound to a context or not.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for creating this object name.
		/// </param>
		/// <returns>
		/// It returns always false. Names are managed manually
		/// </returns>
		protected override bool RequiresName(GraphicsContext ctx)
		{
			CheckValidContext(ctx);

			if (ctx.Extensions.VertexBufferObject_ARB)
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_150))
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_100_ES))
				return true;
			if (ctx.Version.IsCompatible(Gl.Version_200_ES))
				return true;

			return false;
		}

		/// <summary>
		/// Create a Buffer name.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for creating this buffer object name.
		/// </param>
		/// <returns>
		/// It returns a valid object name for this Buffer.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		protected override uint CreateName(GraphicsContext ctx)
		{
			CheckCurrentContext(ctx);

			if (ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450))
				return Gl.CreateBuffer();
			else
				return Gl.GenBuffer();
		}

		/// <summary>
		/// Delete a Buffer name.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for deleting this buffer object name.
		/// </param>
		/// <param name="name">
		/// A <see cref="UInt32"/> that specify the object name to delete.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer does not exist.
		/// </exception>
		protected override void DeleteName(GraphicsContext ctx, uint name)
		{
			CheckThisExistence(ctx);

			// Delete buffer object
			Gl.DeleteBuffers(name);
		}

		/// <summary>
		/// Actually create this Buffer resources.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for allocating resources.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="ctx"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if <paramref name="ctx"/> is not current on the calling thread.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown if this Buffer is currently mapped.
		/// </exception>
		protected override void CreateObject(GraphicsContext ctx)
		{
			CheckCurrentContext(ctx);

			// Buffer must be bound
			if (!(ctx.Extensions.DirectStateAccess_ARB || ctx.Version.IsCompatible(Gl.Version_450)))
				ctx.Bind(this, true);

			if (_Techniques.Count > 0) {
				
				// Note: in the case of no techniques, texture will exists but it will be undefined (no storage defined)

				foreach (Technique technique in _Techniques) {
					// Create/update texture using technique
					technique.Create(ctx);
					// Technique no more useful: dispose it
					technique.Dispose();
				}

				// Layers updated only once
				_Techniques.Clear();
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting managed/unmanaged resources.
		/// </summary>
		/// <exception cref="InvalidOperationException">
		/// Exception thrown in the case <see cref="GraphicsResource.RefCount"/> is greater than zero. This means that the method is trying to dispose
		/// an object that is actually referenced by something else.
		/// </exception>
		protected override void Dispose(bool disposing)
		{
			// Base implementation
			base.Dispose(disposing);
			
			if (disposing)
				GpuBuffer?.Dispose();
		}

		#endregion

		#region IBindingResource Implementation

		/// <summary>
		/// Get the identifier of the binding point.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		int IBindingResource.GetBindingTarget(GraphicsContext ctx)
		{
			// Cannot lazy binding on buffer objects if GL_ARB_vertex_array_object is not supported
			if (!ctx.Extensions.VertexArrayObject_ARB && !ctx.Version.IsCompatible(Gl.Version_200_ES))
				return 0;
				
			// All-in-one implementation for all targets
			switch (Target) {
				case BufferTarget.ArrayBuffer:
					return Gl.ARRAY_BUFFER_BINDING;
				case BufferTarget.ElementArrayBuffer:
					return Gl.ELEMENT_ARRAY_BUFFER_BINDING;
				case BufferTarget.TransformFeedbackBuffer:
					return Gl.TRANSFORM_FEEDBACK_BINDING;
				case BufferTarget.UniformBuffer:
					return Gl.UNIFORM_BUFFER;
				case BufferTarget.ShaderStorageBuffer:
					return Gl.SHADER_STORAGE_BUFFER_BINDING;

				default:
					throw new NotSupportedException($"buffer target {Target} not supported");
			}
		}

		/// <summary>
		/// Bind this IBindingResource.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		void IBindingResource.Bind(GraphicsContext ctx)
		{
			BindCore(ctx);
		}

		/// <summary>
		/// Virtual Bind implementation.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		protected virtual void BindCore(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES))
				Gl.BindBuffer(Target, ObjectName);
		}

		/// <summary>
		/// Bind this IBindingResource.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		void IBindingResource.Unbind(GraphicsContext ctx)
		{
			CheckThisExistence(ctx);

			UnbindCore(ctx);
		}

		/// <summary>
		/// Virtual Unbind implementation.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		protected virtual void UnbindCore(GraphicsContext ctx)
		{
			if (ctx.Extensions.VertexBufferObject_ARB || ctx.Version.IsCompatible(Gl.Version_200_ES))
				Gl.BindBuffer(Target, InvalidObjectName);
		}

		/// <summary>
		/// Check whether this IBindingResource is currently bound on the specified graphics context.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for querying the current binding state.
		/// </param>
		/// <returns>
		/// It returns a boolean value indicating whether this IBindingResource is currently bound on <paramref name="ctx"/>.
		/// </returns>
		bool IBindingResource.IsBound(GraphicsContext ctx)
		{
			int bindingTarget = ((IBindingResource)this).GetBindingTarget(ctx);
			int currentBufferObject;

			Debug.Assert(bindingTarget != 0);
			Gl.Get(bindingTarget, out currentBufferObject);

			return currentBufferObject == (int)ObjectName;
		}

		#endregion

		#region IBindingIndexResource Implementation

		/// <summary>
		/// Get the identifier of the binding point.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="GraphicsContext"/> used for binding.
		/// </param>
		BufferTarget IBindingIndexResource.GetBindingTarget(GraphicsContext ctx)
		{
			return BufferTarget.ShaderStorageBuffer;
		}

		/// <summary>
		/// Current binding point of the IBindingIndexResource.
		/// </summary>
		uint IBindingIndexResource.BindingIndex { get; set; } = GraphicsContext.InvalidBindingIndex;

		#endregion
	}
}
>>>>>>> 540aacd305c7bd2e6b7148cadc6574b49fe9a458
