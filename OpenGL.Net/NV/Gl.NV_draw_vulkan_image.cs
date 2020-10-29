
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
		/// [GL] glDrawVkImageNV: Binding for glDrawVkImageNV.
		/// </summary>
		/// <param name="vkImage">
		/// A <see cref="T:ulong"/>.
		/// </param>
		/// <param name="sampler">
		/// A <see cref="T:uint"/>.
		/// </param>
		/// <param name="x0">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="y0">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="x1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="y1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="z">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="s0">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="t0">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="s1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="t1">
		/// A <see cref="T:float"/>.
		/// </param>
		[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
		public static void DrawVkImageNV(ulong vkImage, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1)
		{
			Debug.Assert(Delegates.pglDrawVkImageNV != null, "pglDrawVkImageNV not implemented");
			Delegates.pglDrawVkImageNV(vkImage, sampler, x0, y0, x1, y1, z, s0, t0, s1, t1);
			LogCommand("glDrawVkImageNV", null, vkImage, sampler, x0, y0, x1, y1, z, s0, t0, s1, t1			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glGetVkProcAddrNV: Binding for glGetVkProcAddrNV.
		/// </summary>
		/// <param name="name">
		/// A <see cref="T:string"/>.
		/// </param>
		[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
		public static VulkanProc GetVkProcAddrNV(string name)
		{
			VulkanProc retValue;

			Debug.Assert(Delegates.pglGetVkProcAddrNV != null, "pglGetVkProcAddrNV not implemented");
			retValue = Delegates.pglGetVkProcAddrNV(name);
			LogCommand("glGetVkProcAddrNV", retValue, name			);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// [GL] glWaitVkSemaphoreNV: Binding for glWaitVkSemaphoreNV.
		/// </summary>
		/// <param name="vkSemaphore">
		/// A <see cref="T:ulong"/>.
		/// </param>
		[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
		public static void WaitVkSemaphoreNV(ulong vkSemaphore)
		{
			Debug.Assert(Delegates.pglWaitVkSemaphoreNV != null, "pglWaitVkSemaphoreNV not implemented");
			Delegates.pglWaitVkSemaphoreNV(vkSemaphore);
			LogCommand("glWaitVkSemaphoreNV", null, vkSemaphore			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glSignalVkSemaphoreNV: Binding for glSignalVkSemaphoreNV.
		/// </summary>
		/// <param name="vkSemaphore">
		/// A <see cref="T:ulong"/>.
		/// </param>
		[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
		public static void SignalVkSemaphoreNV(ulong vkSemaphore)
		{
			Debug.Assert(Delegates.pglSignalVkSemaphoreNV != null, "pglSignalVkSemaphoreNV not implemented");
			Delegates.pglSignalVkSemaphoreNV(vkSemaphore);
			LogCommand("glSignalVkSemaphoreNV", null, vkSemaphore			);
			DebugCheckErrors(null);
		}

		/// <summary>
		/// [GL] glSignalVkFenceNV: Binding for glSignalVkFenceNV.
		/// </summary>
		/// <param name="vkFence">
		/// A <see cref="T:ulong"/>.
		/// </param>
		[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
		public static void SignalVkFenceNV(ulong vkFence)
		{
			Debug.Assert(Delegates.pglSignalVkFenceNV != null, "pglSignalVkFenceNV not implemented");
			Delegates.pglSignalVkFenceNV(vkFence);
			LogCommand("glSignalVkFenceNV", null, vkFence			);
			DebugCheckErrors(null);
		}

		internal static unsafe partial class Delegates
		{
			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glDrawVkImageNV(ulong vkImage, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1);

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glDrawVkImageNV pglDrawVkImageNV;

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate VulkanProc glGetVkProcAddrNV(string name);

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glGetVkProcAddrNV pglGetVkProcAddrNV;

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glWaitVkSemaphoreNV(ulong vkSemaphore);

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glWaitVkSemaphoreNV pglWaitVkSemaphoreNV;

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glSignalVkSemaphoreNV(ulong vkSemaphore);

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glSignalVkSemaphoreNV pglSignalVkSemaphoreNV;

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[SuppressUnmanagedCodeSecurity]
			internal delegate void glSignalVkFenceNV(ulong vkFence);

			[RequiredByFeature("GL_NV_draw_vulkan_image", Api = "gl|glcore|gles2")]
			[ThreadStatic]
			internal static glSignalVkFenceNV pglSignalVkFenceNV;

		}
	}

}
