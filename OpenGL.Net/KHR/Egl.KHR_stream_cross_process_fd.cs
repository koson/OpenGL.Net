
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
	public partial class Egl
	{
		/// <summary>
		/// [EGL] Value of EGL_NO_FILE_DESCRIPTOR_KHR symbol.
		/// </summary>
		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		public const int NO_FILE_DESCRIPTOR_KHR = -1;

		/// <summary>
		/// [EGL] eglGetStreamFileDescriptorKHR: Binding for eglGetStreamFileDescriptorKHR.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="stream">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		public static int GetStreamFileDescriptorKHR(IntPtr dpy, IntPtr stream)
		{
			int retValue;

			Debug.Assert(Delegates.peglGetStreamFileDescriptorKHR != null, "peglGetStreamFileDescriptorKHR not implemented");
			retValue = Delegates.peglGetStreamFileDescriptorKHR(dpy, stream);
			LogCommand("eglGetStreamFileDescriptorKHR", retValue, dpy, stream			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [EGL] eglCreateStreamFromFileDescriptorKHR: Binding for eglCreateStreamFromFileDescriptorKHR.
		/// </summary>
		/// <param name="dpy">
		/// A <see cref="T:IntPtr"/>.
		/// </param>
		/// <param name="file_descriptor">
		/// A <see cref="T:int"/>.
		/// </param>
		[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
		public static IntPtr CreateStreamFromFileDescriptorKHR(IntPtr dpy, int file_descriptor)
		{
			IntPtr retValue;

			Debug.Assert(Delegates.peglCreateStreamFromFileDescriptorKHR != null, "peglCreateStreamFromFileDescriptorKHR not implemented");
			retValue = Delegates.peglCreateStreamFromFileDescriptorKHR(dpy, file_descriptor);
			LogCommand("eglCreateStreamFromFileDescriptorKHR", retValue, dpy, file_descriptor			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate int eglGetStreamFileDescriptorKHR(IntPtr dpy, IntPtr stream);

			[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
			internal static eglGetStreamFileDescriptorKHR peglGetStreamFileDescriptorKHR;

			[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate IntPtr eglCreateStreamFromFileDescriptorKHR(IntPtr dpy, int file_descriptor);

			[RequiredByFeature("EGL_KHR_stream_cross_process_fd")]
			internal static eglCreateStreamFromFileDescriptorKHR peglCreateStreamFromFileDescriptorKHR;

		}
	}

}
