
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
		/// [GL] Value of GL_SAMPLE_ALPHA_TO_MASK_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int SAMPLE_ALPHA_TO_MASK_EXT = 0x809E;

		/// <summary>
		/// [GL] Value of GL_SAMPLE_MASK_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		public const int SAMPLE_MASK_EXT = 0x80A0;

		/// <summary>
		/// [GL] Value of GL_1PASS_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _1PASS_EXT = 0x80A1;

		/// <summary>
		/// [GL] Value of GL_2PASS_0_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _2PASS_0_EXT = 0x80A2;

		/// <summary>
		/// [GL] Value of GL_2PASS_1_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _2PASS_1_EXT = 0x80A3;

		/// <summary>
		/// [GL] Value of GL_4PASS_0_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _4PASS_0_EXT = 0x80A4;

		/// <summary>
		/// [GL] Value of GL_4PASS_1_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _4PASS_1_EXT = 0x80A5;

		/// <summary>
		/// [GL] Value of GL_4PASS_2_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _4PASS_2_EXT = 0x80A6;

		/// <summary>
		/// [GL] Value of GL_4PASS_3_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int _4PASS_3_EXT = 0x80A7;

		/// <summary>
		/// [GL] Value of GL_SAMPLE_MASK_VALUE_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		public const int SAMPLE_MASK_VALUE_EXT = 0x80AA;

		/// <summary>
		/// [GL] Value of GL_SAMPLE_MASK_INVERT_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int SAMPLE_MASK_INVERT_EXT = 0x80AB;

		/// <summary>
		/// [GL] Value of GL_SAMPLE_PATTERN_EXT symbol.
		/// </summary>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public const int SAMPLE_PATTERN_EXT = 0x80AC;

		/// <summary>
		/// [GL] glSampleMaskEXT: Binding for glSampleMaskEXT.
		/// </summary>
		/// <param name="value">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="invert">
		/// A <see cref="T:bool"/>.
		/// </param>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public static void SampleMaskEXT(float value, bool invert)
		{
			Debug.Assert(Delegates.pglSampleMaskEXT != null, "pglSampleMaskEXT not implemented");
			Delegates.pglSampleMaskEXT(value, invert);
			LogCommand("glSampleMaskEXT", null, value, invert			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glSamplePatternEXT: Binding for glSamplePatternEXT.
		/// </summary>
		/// <param name="pattern">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("GL_EXT_multisample")]
		[RequiredByFeature("GL_SGIS_multisample")]
		public static void SamplePatternEXT(int pattern)
		{
			Debug.Assert(Delegates.pglSamplePatternEXT != null, "pglSamplePatternEXT not implemented");
			Delegates.pglSamplePatternEXT(pattern);
			LogCommand("glSamplePatternEXT", null, pattern			);
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_EXT_multisample")]
			[RequiredByFeature("GL_SGIS_multisample")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glSampleMaskEXT(float value, [MarshalAs(UnmanagedType.I1)] bool invert);

			[RequiredByFeature("GL_EXT_multisample")]
			[RequiredByFeature("GL_SGIS_multisample", EntryPoint = "glSampleMaskSGIS")]
			[ThreadStatic]
			internal static glSampleMaskEXT pglSampleMaskEXT;

			[RequiredByFeature("GL_EXT_multisample")]
			[RequiredByFeature("GL_SGIS_multisample")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glSamplePatternEXT(int pattern);

			[RequiredByFeature("GL_EXT_multisample")]
			[RequiredByFeature("GL_SGIS_multisample", EntryPoint = "glSamplePatternSGIS")]
			[ThreadStatic]
			internal static glSamplePatternEXT pglSamplePatternEXT;

		}
	}

}
