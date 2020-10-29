
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
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_POSITIVE_X_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_POSITIVE_X_NV = 0x9350;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_NEGATIVE_X_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_NEGATIVE_X_NV = 0x9351;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_POSITIVE_Y_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_POSITIVE_Y_NV = 0x9352;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_NEGATIVE_Y_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_NEGATIVE_Y_NV = 0x9353;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_POSITIVE_Z_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_POSITIVE_Z_NV = 0x9354;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_NEGATIVE_Z_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_NEGATIVE_Z_NV = 0x9355;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_POSITIVE_W_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_POSITIVE_W_NV = 0x9356;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_NEGATIVE_W_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_NEGATIVE_W_NV = 0x9357;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_X_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_X_NV = 0x9358;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_Y_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_Y_NV = 0x9359;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_Z_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_Z_NV = 0x935A;

		/// <summary>
		/// [GL] Value of GL_VIEWPORT_SWIZZLE_W_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public const int VIEWPORT_SWIZZLE_W_NV = 0x935B;

		/// <summary>
		/// [GL] glViewportSwizzleNV: Binding for glViewportSwizzleNV.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="swizzlex">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="swizzley">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="swizzlez">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="swizzlew">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
		public static void ViewportSwizzleNV(uint index, int swizzlex, int swizzley, int swizzlez, int swizzlew)
		{
			Debug.Assert(Delegates.pglViewportSwizzleNV != null, "pglViewportSwizzleNV not implemented");
			Delegates.pglViewportSwizzleNV(index, swizzlex, swizzley, swizzlez, swizzlew);
			LogCommand("glViewportSwizzleNV", null, index, swizzlex, swizzley, swizzlez, swizzlew			);
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glViewportSwizzleNV(uint index, int swizzlex, int swizzley, int swizzlez, int swizzlew);

			[RequiredByFeature("GL_NV_viewport_swizzle", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glViewportSwizzleNV pglViewportSwizzleNV;

		}
	}

}
