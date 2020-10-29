
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
		/// [GL] glDepthRangeArrayfvNV: Binding for glDepthRangeArrayfvNV.
		/// </summary>
		/// <param name="first">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="count">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="v">
		/// A <see cref="T:float[]"/>.
		/// </param>
		[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
		public static void DepthRangeArrayNV(uint first, int count, float[] v)
		{
			unsafe {
				fixed (float* p_v = v)
				{
					Debug.Assert(Delegates.pglDepthRangeArrayfvNV != null, "pglDepthRangeArrayfvNV not implemented");
					Delegates.pglDepthRangeArrayfvNV(first, count, p_v);
					LogCommand("glDepthRangeArrayfvNV", null, first, count, v					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glDepthRangeIndexedfNV: Binding for glDepthRangeIndexedfNV.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="n">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="f">
		/// A <see cref="T:float"/>.
		/// </param>
		[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
		public static void DepthRangeIndexedNV(uint index, float n, float f)
		{
			Debug.Assert(Delegates.pglDepthRangeIndexedfNV != null, "pglDepthRangeIndexedfNV not implemented");
			Delegates.pglDepthRangeIndexedfNV(index, n, f);
			LogCommand("glDepthRangeIndexedfNV", null, index, n, f			);
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glDepthRangeArrayfvNV(uint first, int count, float* v);

			[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
			[ThreadStatic]
			internal static glDepthRangeArrayfvNV pglDepthRangeArrayfvNV;

			[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glDepthRangeIndexedfNV(uint index, float n, float f);

			[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
			[ThreadStatic]
			internal static glDepthRangeIndexedfNV pglDepthRangeIndexedfNV;

		}
	}

}
