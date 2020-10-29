
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
		/// [GLX] Value of GLX_NUM_VIDEO_SLOTS_NV symbol.
		/// </summary>
		[RequiredByFeature("GLX_NV_present_video")]
		public const int NUM_VIDEO_SLOTS_NV = 0x20F0;

		/// <summary>
		/// [GLX] glXEnumerateVideoDevicesNV: Binding for glXEnumerateVideoDevicesNV.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="screen">
		/// A <see cref="T:int"/>.
		/// </param>
		/// <param name="nelements">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GLX_NV_present_video")]
		public static unsafe uint* EnumerateVideoDevicesNV(IntPtr dpy, int screen, int[] nelements)
		{
			uint* retValue;

			unsafe {
				fixed (int* p_nelements = nelements)
				{
					Debug.Assert(Delegates.pglXEnumerateVideoDevicesNV != null, "pglXEnumerateVideoDevicesNV not implemented");
					retValue = Delegates.pglXEnumerateVideoDevicesNV(dpy, screen, p_nelements);
					LogCommand("glXEnumerateVideoDevicesNV", new IntPtr(retValue), dpy, screen, nelements					);
				}
			}
			DebugCheckErrors(null);

			return (retValue);
		}

		/// <summary>
		/// [GLX] glXBindVideoDeviceNV: Binding for glXBindVideoDeviceNV.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="video_slot">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="video_device">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="attrib_list">
		/// A <see cref="T:int[]"/>.
		/// </param>
		[RequiredByFeature("GLX_NV_present_video")]
		public static int BindVideoDeviceNV(IntPtr dpy, uint video_slot, uint video_device, int[] attrib_list)
		{
			int retValue;

			unsafe {
				fixed (int* p_attrib_list = attrib_list)
				{
					Debug.Assert(Delegates.pglXBindVideoDeviceNV != null, "pglXBindVideoDeviceNV not implemented");
					retValue = Delegates.pglXBindVideoDeviceNV(dpy, video_slot, video_device, p_attrib_list);
					LogCommand("glXBindVideoDeviceNV", retValue, dpy, video_slot, video_device, attrib_list					);
				}
			}
			DebugCheckErrors(retValue);

			return (retValue);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GLX_NV_present_video")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate uint* glXEnumerateVideoDevicesNV(IntPtr dpy, int screen, int* nelements);

			[RequiredByFeature("GLX_NV_present_video")]
			internal static glXEnumerateVideoDevicesNV pglXEnumerateVideoDevicesNV;

			[RequiredByFeature("GLX_NV_present_video")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int glXBindVideoDeviceNV(IntPtr dpy, uint video_slot, uint video_device, int* attrib_list);

			[RequiredByFeature("GLX_NV_present_video")]
			internal static glXBindVideoDeviceNV pglXBindVideoDeviceNV;

		}
	}

}
