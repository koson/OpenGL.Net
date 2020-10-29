
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
	public partial class Glx
	{
		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_PIPE_NAME_LENGTH_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public const int HYPERPIPE_PIPE_NAME_LENGTH_SGIX = 80;

		/// <summary>
		/// [GLX] Value of GLX_BAD_HYPERPIPE_CONFIG_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public const int BAD_HYPERPIPE_CONFIG_SGIX = 91;

		/// <summary>
		/// [GLX] Value of GLX_BAD_HYPERPIPE_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public const int BAD_HYPERPIPE_SGIX = 92;

		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_DISPLAY_PIPE_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeTypeMask")]
		public const int HYPERPIPE_DISPLAY_PIPE_SGIX = 0x00000001;

		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_RENDER_PIPE_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeTypeMask")]
		public const int HYPERPIPE_RENDER_PIPE_SGIX = 0x00000002;

		/// <summary>
		/// [GLX] Value of GLX_PIPE_RECT_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
		public const int PIPE_RECT_SGIX = 0x00000001;

		/// <summary>
		/// [GLX] Value of GLX_PIPE_RECT_LIMITS_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
		public const int PIPE_RECT_LIMITS_SGIX = 0x00000002;

		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_STEREO_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
		public const int HYPERPIPE_STEREO_SGIX = 0x00000003;

		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_PIXEL_AVERAGE_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		[Log(BitmaskName = "GLXHyperpipeAttribSGIX")]
		public const int HYPERPIPE_PIXEL_AVERAGE_SGIX = 0x00000004;

		/// <summary>
		/// [GLX] Value of GLX_HYPERPIPE_ID_SGIX symbol.
		/// </summary>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public const int HYPERPIPE_ID_SGIX = 0x8030;

		/// <summary>
		/// [GLX] glXQueryHyperpipeNetworkSGIX: Binding for glXQueryHyperpipeNetworkSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="npipes">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static unsafe IntPtr* QueryHyperpipeNetworkSGIX(IntPtr dpy, int[] npipes)
		{
			IntPtr* retValue;

			unsafe {
				fixed (int* p_npipes = npipes)
				{
					Debug.Assert(Delegates.pglXQueryHyperpipeNetworkSGIX != null, "pglXQueryHyperpipeNetworkSGIX not implemented");
					retValue = Delegates.pglXQueryHyperpipeNetworkSGIX(dpy, p_npipes);
					LogCommand("glXQueryHyperpipeNetworkSGIX", new IntPtr(retValue), dpy, npipes					);
				}
			}
			DebugCheckErrors(null);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXHyperpipeConfigSGIX: Binding for glXHyperpipeConfigSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="networkId">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="npipes">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="cfg">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="hpId">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int HyperpipeConfigSGIX(IntPtr dpy, int networkId, int npipes, IntPtr cfg, int[] hpId)
		{
			int retValue;

			unsafe {
				fixed (int* p_hpId = hpId)
				{
					Debug.Assert(Delegates.pglXHyperpipeConfigSGIX != null, "pglXHyperpipeConfigSGIX not implemented");
					retValue = Delegates.pglXHyperpipeConfigSGIX(dpy, networkId, npipes, cfg, p_hpId);
					LogCommand("glXHyperpipeConfigSGIX", retValue, dpy, networkId, npipes, cfg, hpId					);
				}
			}
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXQueryHyperpipeConfigSGIX: Binding for glXQueryHyperpipeConfigSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="hpId">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="npipes">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static IntPtr QueryHyperpipeConfigSGIX(IntPtr dpy, int hpId, int[] npipes)
		{
			IntPtr retValue;

			unsafe {
				fixed (int* p_npipes = npipes)
				{
					Debug.Assert(Delegates.pglXQueryHyperpipeConfigSGIX != null, "pglXQueryHyperpipeConfigSGIX not implemented");
					retValue = Delegates.pglXQueryHyperpipeConfigSGIX(dpy, hpId, p_npipes);
					LogCommand("glXQueryHyperpipeConfigSGIX", retValue, dpy, hpId, npipes					);
				}
			}
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXDestroyHyperpipeConfigSGIX: Binding for glXDestroyHyperpipeConfigSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="hpId">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int DestroyHyperpipeConfigSGIX(IntPtr dpy, int hpId)
		{
			int retValue;

			Debug.Assert(Delegates.pglXDestroyHyperpipeConfigSGIX != null, "pglXDestroyHyperpipeConfigSGIX not implemented");
			retValue = Delegates.pglXDestroyHyperpipeConfigSGIX(dpy, hpId);
			LogCommand("glXDestroyHyperpipeConfigSGIX", retValue, dpy, hpId			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXBindHyperpipeSGIX: Binding for glXBindHyperpipeSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="hpId">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int BindHyperpipeSGIX(IntPtr dpy, int hpId)
		{
			int retValue;

			Debug.Assert(Delegates.pglXBindHyperpipeSGIX != null, "pglXBindHyperpipeSGIX not implemented");
			retValue = Delegates.pglXBindHyperpipeSGIX(dpy, hpId);
			LogCommand("glXBindHyperpipeSGIX", retValue, dpy, hpId			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXQueryHyperpipeBestAttribSGIX: Binding for glXQueryHyperpipeBestAttribSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="timeSlice">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="attrib">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="attribList">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="returnAttribList">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int QueryHyperpipeBestAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr attribList, IntPtr returnAttribList)
		{
			int retValue;

			Debug.Assert(Delegates.pglXQueryHyperpipeBestAttribSGIX != null, "pglXQueryHyperpipeBestAttribSGIX not implemented");
			retValue = Delegates.pglXQueryHyperpipeBestAttribSGIX(dpy, timeSlice, attrib, size, attribList, returnAttribList);
			LogCommand("glXQueryHyperpipeBestAttribSGIX", retValue, dpy, timeSlice, attrib, size, attribList, returnAttribList			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXHyperpipeAttribSGIX: Binding for glXHyperpipeAttribSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="timeSlice">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="attrib">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="attribList">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int HyperpipeAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr attribList)
		{
			int retValue;

			Debug.Assert(Delegates.pglXHyperpipeAttribSGIX != null, "pglXHyperpipeAttribSGIX not implemented");
			retValue = Delegates.pglXHyperpipeAttribSGIX(dpy, timeSlice, attrib, size, attribList);
			LogCommand("glXHyperpipeAttribSGIX", retValue, dpy, timeSlice, attrib, size, attribList			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXQueryHyperpipeAttribSGIX: Binding for glXQueryHyperpipeAttribSGIX.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="timeSlice">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="attrib">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="returnAttribList">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		[RequiredByFeature("GLX_SGIX_hyperpipe")]
		public static int QueryHyperpipeAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr returnAttribList)
		{
			int retValue;

			Debug.Assert(Delegates.pglXQueryHyperpipeAttribSGIX != null, "pglXQueryHyperpipeAttribSGIX not implemented");
			retValue = Delegates.pglXQueryHyperpipeAttribSGIX(dpy, timeSlice, attrib, size, returnAttribList);
			LogCommand("glXQueryHyperpipeAttribSGIX", retValue, dpy, timeSlice, attrib, size, returnAttribList			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate IntPtr* glXQueryHyperpipeNetworkSGIX(IntPtr dpy, int* npipes);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXQueryHyperpipeNetworkSGIX pglXQueryHyperpipeNetworkSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXHyperpipeConfigSGIX(IntPtr dpy, int networkId, int npipes, IntPtr cfg, int* hpId);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXHyperpipeConfigSGIX pglXHyperpipeConfigSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate IntPtr glXQueryHyperpipeConfigSGIX(IntPtr dpy, int hpId, int* npipes);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXQueryHyperpipeConfigSGIX pglXQueryHyperpipeConfigSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXDestroyHyperpipeConfigSGIX(IntPtr dpy, int hpId);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXDestroyHyperpipeConfigSGIX pglXDestroyHyperpipeConfigSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXBindHyperpipeSGIX(IntPtr dpy, int hpId);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXBindHyperpipeSGIX pglXBindHyperpipeSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXQueryHyperpipeBestAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr attribList, IntPtr returnAttribList);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXQueryHyperpipeBestAttribSGIX pglXQueryHyperpipeBestAttribSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXHyperpipeAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr attribList);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXHyperpipeAttribSGIX pglXHyperpipeAttribSGIX;

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXQueryHyperpipeAttribSGIX(IntPtr dpy, int timeSlice, int attrib, int size, IntPtr returnAttribList);

			[RequiredByFeature("GLX_SGIX_hyperpipe")]
			internal static glXQueryHyperpipeAttribSGIX pglXQueryHyperpipeAttribSGIX;

		}
	}

}
