
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
		/// [GL] Value of GL_BLEND_OVERLAP_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int BLEND_OVERLAP_NV = 0x9281;

		/// <summary>
		/// [GL] Value of GL_BLEND_PREMULTIPLIED_SRC_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int BLEND_PREMULTIPLIED_SRC_NV = 0x9280;

		/// <summary>
		/// [GL] Value of GL_CONJOINT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int CONJOINT_NV = 0x9284;

		/// <summary>
		/// [GL] Value of GL_CONTRAST_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int CONTRAST_NV = 0x92A1;

		/// <summary>
		/// [GL] Value of GL_DISJOINT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DISJOINT_NV = 0x9283;

		/// <summary>
		/// [GL] Value of GL_DST_ATOP_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DST_ATOP_NV = 0x928F;

		/// <summary>
		/// [GL] Value of GL_DST_IN_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DST_IN_NV = 0x928B;

		/// <summary>
		/// [GL] Value of GL_DST_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DST_NV = 0x9287;

		/// <summary>
		/// [GL] Value of GL_DST_OUT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DST_OUT_NV = 0x928D;

		/// <summary>
		/// [GL] Value of GL_DST_OVER_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int DST_OVER_NV = 0x9289;

		/// <summary>
		/// [GL] Value of GL_HARDMIX_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int HARDMIX_NV = 0x92A9;

		/// <summary>
		/// [GL] Value of GL_INVERT_OVG_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int INVERT_OVG_NV = 0x92B4;

		/// <summary>
		/// [GL] Value of GL_INVERT_RGB_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int INVERT_RGB_NV = 0x92A3;

		/// <summary>
		/// [GL] Value of GL_LINEARBURN_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int LINEARBURN_NV = 0x92A5;

		/// <summary>
		/// [GL] Value of GL_LINEARDODGE_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int LINEARDODGE_NV = 0x92A4;

		/// <summary>
		/// [GL] Value of GL_LINEARLIGHT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int LINEARLIGHT_NV = 0x92A7;

		/// <summary>
		/// [GL] Value of GL_MINUS_CLAMPED_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int MINUS_CLAMPED_NV = 0x92B3;

		/// <summary>
		/// [GL] Value of GL_MINUS_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int MINUS_NV = 0x929F;

		/// <summary>
		/// [GL] Value of GL_PINLIGHT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int PINLIGHT_NV = 0x92A8;

		/// <summary>
		/// [GL] Value of GL_PLUS_CLAMPED_ALPHA_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int PLUS_CLAMPED_ALPHA_NV = 0x92B2;

		/// <summary>
		/// [GL] Value of GL_PLUS_CLAMPED_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int PLUS_CLAMPED_NV = 0x92B1;

		/// <summary>
		/// [GL] Value of GL_PLUS_DARKER_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int PLUS_DARKER_NV = 0x9292;

		/// <summary>
		/// [GL] Value of GL_PLUS_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int PLUS_NV = 0x9291;

		/// <summary>
		/// [GL] Value of GL_SRC_ATOP_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int SRC_ATOP_NV = 0x928E;

		/// <summary>
		/// [GL] Value of GL_SRC_IN_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int SRC_IN_NV = 0x928A;

		/// <summary>
		/// [GL] Value of GL_SRC_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int SRC_NV = 0x9286;

		/// <summary>
		/// [GL] Value of GL_SRC_OUT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int SRC_OUT_NV = 0x928C;

		/// <summary>
		/// [GL] Value of GL_SRC_OVER_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int SRC_OVER_NV = 0x9288;

		/// <summary>
		/// [GL] Value of GL_UNCORRELATED_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int UNCORRELATED_NV = 0x9282;

		/// <summary>
		/// [GL] Value of GL_VIVIDLIGHT_NV symbol.
		/// </summary>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public const int VIVIDLIGHT_NV = 0x92A6;

		/// <summary>
		/// [GL] glBlendParameteriNV: Binding for glBlendParameteriNV.
		/// </summary>
		/// <param name="pname">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="value">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
		public static void BlendParameterNV(int pname, int value)
		{
			Debug.Assert(Delegates.pglBlendParameteriNV != null, "pglBlendParameteriNV not implemented");
			Delegates.pglBlendParameteriNV(pname, value);
			LogCommand("glBlendParameteriNV", null, pname, value			);
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glBlendParameteriNV(int pname, int value);

			[RequiredByFeature("GL_NV_blend_equation_advanced", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glBlendParameteriNV pglBlendParameteriNV;

		}
	}

}
