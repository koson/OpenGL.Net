
// MIT License
// 
// Copyright (c) 2009-2017 Luca Piccioni
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
// 
// This file is automatically generated

#pragma warning disable 649, 1572, 1573

// ReSharper disable RedundantUsingDirective
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

using Khronos;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable JoinDeclarationAndInitializer

namespace OpenGL
{
	public partial class Gl
	{
		/// <summary>
		/// [GL] Value of GL_PARALLEL_ARRAYS_INTEL symbol.
		/// </summary>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public const int PARALLEL_ARRAYS_INTEL = 0x83F4;

		/// <summary>
		/// [GL] Value of GL_VERTEX_ARRAY_PARALLEL_POINTERS_INTEL symbol.
		/// </summary>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public const int VERTEX_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F5;

		/// <summary>
		/// [GL] Value of GL_NORMAL_ARRAY_PARALLEL_POINTERS_INTEL symbol.
		/// </summary>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public const int NORMAL_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F6;

		/// <summary>
		/// [GL] Value of GL_COLOR_ARRAY_PARALLEL_POINTERS_INTEL symbol.
		/// </summary>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public const int COLOR_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F7;

		/// <summary>
		/// [GL] Value of GL_TEXTURE_COORD_ARRAY_PARALLEL_POINTERS_INTEL symbol.
		/// </summary>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public const int TEXTURE_COORD_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F8;

		/// <summary>
		/// [GL] glVertexPointervINTEL: Binding for glVertexPointervINTEL.
		/// </summary>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="type">
		/// A <see cref="T:VertexPointerType"/>.
		/// </param>
		/// <param name="pointer">
		/// A <see cref="T:IntPtr[]"/>.
		/// </param>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public static void VertexPointerINTEL(int size, VertexPointerType type, IntPtr[] pointer)
		{
			Debug.Assert(pointer.Length >= 4);
			unsafe {
				fixed (IntPtr* p_pointer = pointer)
				{
					Debug.Assert(Delegates.pglVertexPointervINTEL != null, "pglVertexPointervINTEL not implemented");
					Delegates.pglVertexPointervINTEL(size, (int)type, p_pointer);
					LogCommand("glVertexPointervINTEL", null, size, type, pointer					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glNormalPointervINTEL: Binding for glNormalPointervINTEL.
		/// </summary>
		/// <param name="type">
		/// A <see cref="T:NormalPointerType"/>.
		/// </param>
		/// <param name="pointer">
		/// A <see cref="T:IntPtr[]"/>.
		/// </param>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public static void NormalPointerINTEL(NormalPointerType type, IntPtr[] pointer)
		{
			Debug.Assert(pointer.Length >= 4);
			unsafe {
				fixed (IntPtr* p_pointer = pointer)
				{
					Debug.Assert(Delegates.pglNormalPointervINTEL != null, "pglNormalPointervINTEL not implemented");
					Delegates.pglNormalPointervINTEL((int)type, p_pointer);
					LogCommand("glNormalPointervINTEL", null, type, pointer					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glColorPointervINTEL: Binding for glColorPointervINTEL.
		/// </summary>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="type">
		/// A <see cref="T:VertexPointerType"/>.
		/// </param>
		/// <param name="pointer">
		/// A <see cref="T:IntPtr[]"/>.
		/// </param>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public static void ColorPointerINTEL(int size, VertexPointerType type, IntPtr[] pointer)
		{
			Debug.Assert(pointer.Length >= 4);
			unsafe {
				fixed (IntPtr* p_pointer = pointer)
				{
					Debug.Assert(Delegates.pglColorPointervINTEL != null, "pglColorPointervINTEL not implemented");
					Delegates.pglColorPointervINTEL(size, (int)type, p_pointer);
					LogCommand("glColorPointervINTEL", null, size, type, pointer					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glTexCoordPointervINTEL: Binding for glTexCoordPointervINTEL.
		/// </summary>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="type">
		/// A <see cref="T:TexCoordPointerType"/>.
		/// </param>
		/// <param name="pointer">
		/// A <see cref="T:IntPtr[]"/>.
		/// </param>
		[RequiredByFeature("GL_INTEL_parallel_arrays")]
		public static void TexCoordPointerINTEL(int size, TexCoordPointerType type, IntPtr[] pointer)
		{
			Debug.Assert(pointer.Length >= 4);
			unsafe {
				fixed (IntPtr* p_pointer = pointer)
				{
					Debug.Assert(Delegates.pglTexCoordPointervINTEL != null, "pglTexCoordPointervINTEL not implemented");
					Delegates.pglTexCoordPointervINTEL(size, (int)type, p_pointer);
					LogCommand("glTexCoordPointervINTEL", null, size, type, pointer					);
				}
			}
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glVertexPointervINTEL(int size, int type, IntPtr* pointer);

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[ThreadStatic]
			internal static glVertexPointervINTEL pglVertexPointervINTEL;

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glNormalPointervINTEL(int type, IntPtr* pointer);

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[ThreadStatic]
			internal static glNormalPointervINTEL pglNormalPointervINTEL;

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glColorPointervINTEL(int size, int type, IntPtr* pointer);

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[ThreadStatic]
			internal static glColorPointervINTEL pglColorPointervINTEL;

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glTexCoordPointervINTEL(int size, int type, IntPtr* pointer);

			[RequiredByFeature("GL_INTEL_parallel_arrays")]
			[ThreadStatic]
			internal static glTexCoordPointervINTEL pglTexCoordPointervINTEL;

		}
	}

}
