
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
		/// [GL] Value of GL_RESTART_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int RESTART_SUN = 0x0001;

		/// <summary>
		/// [GL] Value of GL_REPLACE_MIDDLE_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACE_MIDDLE_SUN = 0x0002;

		/// <summary>
		/// [GL] Value of GL_REPLACE_OLDEST_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACE_OLDEST_SUN = 0x0003;

		/// <summary>
		/// [GL] Value of GL_TRIANGLE_LIST_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int TRIANGLE_LIST_SUN = 0x81D7;

		/// <summary>
		/// [GL] Value of GL_REPLACEMENT_CODE_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACEMENT_CODE_SUN = 0x81D8;

		/// <summary>
		/// [GL] Value of GL_REPLACEMENT_CODE_ARRAY_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACEMENT_CODE_ARRAY_SUN = 0x85C0;

		/// <summary>
		/// [GL] Value of GL_REPLACEMENT_CODE_ARRAY_TYPE_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACEMENT_CODE_ARRAY_TYPE_SUN = 0x85C1;

		/// <summary>
		/// [GL] Value of GL_REPLACEMENT_CODE_ARRAY_STRIDE_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACEMENT_CODE_ARRAY_STRIDE_SUN = 0x85C2;

		/// <summary>
		/// [GL] Value of GL_REPLACEMENT_CODE_ARRAY_POINTER_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int REPLACEMENT_CODE_ARRAY_POINTER_SUN = 0x85C3;

		/// <summary>
		/// [GL] Value of GL_R1UI_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_V3F_SUN = 0x85C4;

		/// <summary>
		/// [GL] Value of GL_R1UI_C4UB_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_C4UB_V3F_SUN = 0x85C5;

		/// <summary>
		/// [GL] Value of GL_R1UI_C3F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_C3F_V3F_SUN = 0x85C6;

		/// <summary>
		/// [GL] Value of GL_R1UI_N3F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_N3F_V3F_SUN = 0x85C7;

		/// <summary>
		/// [GL] Value of GL_R1UI_C4F_N3F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_C4F_N3F_V3F_SUN = 0x85C8;

		/// <summary>
		/// [GL] Value of GL_R1UI_T2F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_T2F_V3F_SUN = 0x85C9;

		/// <summary>
		/// [GL] Value of GL_R1UI_T2F_N3F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_T2F_N3F_V3F_SUN = 0x85CA;

		/// <summary>
		/// [GL] Value of GL_R1UI_T2F_C4F_N3F_V3F_SUN symbol.
		/// </summary>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public const int R1UI_T2F_C4F_N3F_V3F_SUN = 0x85CB;

		/// <summary>
		/// [GL] glReplacementCodeuiSUN: Binding for glReplacementCodeuiSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:uint"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeuiSUN(uint code)
		{
			Debug.Assert(Delegates.pglReplacementCodeuiSUN != null, "pglReplacementCodeuiSUN not implemented");
			Delegates.pglReplacementCodeuiSUN(code);
			LogCommand("glReplacementCodeuiSUN", null, code			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodeusSUN: Binding for glReplacementCodeusSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:ushort"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeusSUN(ushort code)
		{
			Debug.Assert(Delegates.pglReplacementCodeusSUN != null, "pglReplacementCodeusSUN not implemented");
			Delegates.pglReplacementCodeusSUN(code);
			LogCommand("glReplacementCodeusSUN", null, code			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodeubSUN: Binding for glReplacementCodeubSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:byte"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeubSUN(byte code)
		{
			Debug.Assert(Delegates.pglReplacementCodeubSUN != null, "pglReplacementCodeubSUN not implemented");
			Delegates.pglReplacementCodeubSUN(code);
			LogCommand("glReplacementCodeubSUN", null, code			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodeuivSUN: Binding for glReplacementCodeuivSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:uint[]"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeuiSUN(uint[] code)
		{
			unsafe {
				fixed (uint* p_code = code)
				{
					Debug.Assert(Delegates.pglReplacementCodeuivSUN != null, "pglReplacementCodeuivSUN not implemented");
					Delegates.pglReplacementCodeuivSUN(p_code);
					LogCommand("glReplacementCodeuivSUN", null, code					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodeusvSUN: Binding for glReplacementCodeusvSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:ushort[]"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeusSUN(ushort[] code)
		{
			unsafe {
				fixed (ushort* p_code = code)
				{
					Debug.Assert(Delegates.pglReplacementCodeusvSUN != null, "pglReplacementCodeusvSUN not implemented");
					Delegates.pglReplacementCodeusvSUN(p_code);
					LogCommand("glReplacementCodeusvSUN", null, code					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodeubvSUN: Binding for glReplacementCodeubvSUN.
		/// </summary>
		/// <param name="code">
		/// A <see cref="T:byte[]"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodeubSUN(byte[] code)
		{
			unsafe {
				fixed (byte* p_code = code)
				{
					Debug.Assert(Delegates.pglReplacementCodeubvSUN != null, "pglReplacementCodeubvSUN not implemented");
					Delegates.pglReplacementCodeubvSUN(p_code);
					LogCommand("glReplacementCodeubvSUN", null, code					);
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glReplacementCodePointerSUN: Binding for glReplacementCodePointerSUN.
		/// </summary>
		/// <param name="type">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="stride">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="pointer">
		/// A <see cref="T:IntPtr[]"/>.
		/// </param>
		[RequiredByFeature("GL_SUN_triangle_list")]
		public static void ReplacementCodePointerSUN(int type, int stride, IntPtr[] pointer)
		{
			unsafe {
				fixed (IntPtr* p_pointer = pointer)
				{
					Debug.Assert(Delegates.pglReplacementCodePointerSUN != null, "pglReplacementCodePointerSUN not implemented");
					Delegates.pglReplacementCodePointerSUN(type, stride, p_pointer);
					LogCommand("glReplacementCodePointerSUN", null, type, stride, pointer					);
				}
			}
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeuiSUN(uint code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeuiSUN pglReplacementCodeuiSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeusSUN(ushort code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeusSUN pglReplacementCodeusSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeubSUN(byte code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeubSUN pglReplacementCodeubSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeuivSUN(uint* code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeuivSUN pglReplacementCodeuivSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeusvSUN(ushort* code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeusvSUN pglReplacementCodeusvSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodeubvSUN(byte* code);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodeubvSUN pglReplacementCodeubvSUN;

			[RequiredByFeature("GL_SUN_triangle_list")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glReplacementCodePointerSUN(int type, int stride, IntPtr* pointer);

			[RequiredByFeature("GL_SUN_triangle_list")]
			[ThreadStatic]
			internal static glReplacementCodePointerSUN pglReplacementCodePointerSUN;

		}
	}

}
