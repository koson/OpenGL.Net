
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
		/// [GL] glGetColorTableSGI: Binding for glGetColorTableSGI.
		/// </summary>
		/// <param name="target">
		/// A <see cref="T:ColorTableTarget"/>.
		/// </param>
		/// <param name="format">
		/// A <see cref="T:PixelFormat"/>.
		/// </param>
		/// <param name="type">
		/// A <see cref="T:PixelType"/>.
		/// </param>
		/// <param name="table">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		[RequiredByFeature("GL_SGI_color_table")]
		public static void GetColorTableSGI(ColorTableTarget target, PixelFormat format, PixelType type, IntPtr table)
		{
			Debug.Assert(Delegates.pglGetColorTableSGI != null, "pglGetColorTableSGI not implemented");
			Delegates.pglGetColorTableSGI((int)target, (int)format, (int)type, table);
			LogCommand("glGetColorTableSGI", null, target, format, type, table			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glGetColorTableSGI: Binding for glGetColorTableSGI.
		/// </summary>
		/// <param name="target">
		/// A <see cref="T:ColorTableTarget"/>.
		/// </param>
		/// <param name="format">
		/// A <see cref="T:PixelFormat"/>.
		/// </param>
		/// <param name="type">
		/// A <see cref="T:PixelType"/>.
		/// </param>
		/// <param name="table">
		/// A <see cref="T:object"/>.
		/// </param>
		[RequiredByFeature("GL_SGI_color_table")]
		public static void GetColorTableSGI(ColorTableTarget target, PixelFormat format, PixelType type, object table)
		{
			GCHandle pin_table = GCHandle.Alloc(table, GCHandleType.Pinned);
			try {
				GetColorTableSGI(target, format, type, pin_table.AddrOfPinnedObject());
			} finally {
				pin_table.Free();
			}
		}

		/// <summary>
		/// [GL] glGetColorTableParameterfvSGI: Binding for glGetColorTableParameterfvSGI.
		/// </summary>
		/// <param name="target">
		/// A <see cref="T:ColorTableTarget"/>.
		/// </param>
		/// <param name="pname">
		/// A <see cref="T:GetColorTableParameterPNameSGI"/>.
		/// </param>
		/// <param name="params">
		/// A <see cref="T:float[]"/>.
		/// </param>
		[RequiredByFeature("GL_SGI_color_table")]
		public static void GetColorTableParameterSGI(ColorTableTarget target, GetColorTableParameterPNameSGI pname, [Out] float[] @params)
		{
			unsafe {
				fixed (float* p_params = @params)
				{
					Debug.Assert(Delegates.pglGetColorTableParameterfvSGI != null, "pglGetColorTableParameterfvSGI not implemented");
					Delegates.pglGetColorTableParameterfvSGI((int)target, (int)pname, p_params);
					LogCommand("glGetColorTableParameterfvSGI", null, target, pname, @params					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glGetColorTableParameterivSGI: Binding for glGetColorTableParameterivSGI.
		/// </summary>
		/// <param name="target">
		/// A <see cref="T:ColorTableTarget"/>.
		/// </param>
		/// <param name="pname">
		/// A <see cref="T:GetColorTableParameterPNameSGI"/>.
		/// </param>
		/// <param name="params">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GL_SGI_color_table")]
		public static void GetColorTableParameterSGI(ColorTableTarget target, GetColorTableParameterPNameSGI pname, [Out] int[] @params)
		{
			unsafe {
				fixed (int* p_params = @params)
				{
					Debug.Assert(Delegates.pglGetColorTableParameterivSGI != null, "pglGetColorTableParameterivSGI not implemented");
					Delegates.pglGetColorTableParameterivSGI((int)target, (int)pname, p_params);
					LogCommand("glGetColorTableParameterivSGI", null, target, pname, @params					);
				}
			}
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_SGI_color_table")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glGetColorTableSGI(int target, int format, int type, IntPtr table);

			[RequiredByFeature("GL_SGI_color_table")]
			[ThreadStatic]
			internal static glGetColorTableSGI pglGetColorTableSGI;

			[RequiredByFeature("GL_SGI_color_table")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glGetColorTableParameterfvSGI(int target, int pname, float* @params);

			[RequiredByFeature("GL_SGI_color_table")]
			[ThreadStatic]
			internal static glGetColorTableParameterfvSGI pglGetColorTableParameterfvSGI;

			[RequiredByFeature("GL_SGI_color_table")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glGetColorTableParameterivSGI(int target, int pname, int* @params);

			[RequiredByFeature("GL_SGI_color_table")]
			[ThreadStatic]
			internal static glGetColorTableParameterivSGI pglGetColorTableParameterivSGI;

		}
	}

}
