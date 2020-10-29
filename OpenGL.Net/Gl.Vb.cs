
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

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Khronos;


namespace OpenGL
{
	/// <summary>
	/// Class for scoping those methods conflicting with other fields/enums.
	/// </summary>
	public partial class Gl
	{
		public static class VB
		{
			/// <summary>
			/// <para>
			/// [GL4|GLES3.2] glClear: clear buffers to preset values
			/// </para>
			/// </summary>
			/// <param name="mask">
			/// Bitwise OR of masks that indicate the buffers to be cleared. The three masks are Gl.COLOR_BUFFER_BIT, 
			/// Gl.DEPTH_BUFFER_BIT, and Gl.STENCIL_BUFFER_BIT.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
			[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
			public static void Clear(ClearBufferMask mask)
			{
				Debug.Assert(Delegates.pglClear != null, "pglClear not implemented");
				Delegates.pglClear((uint)mask);
				LogCommand("glClear", null, mask				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// <para>
			/// [GL2.1|GLES1.1] glViewport: set the viewport
			/// </para>
			/// </summary>
			/// <param name="x">
			/// Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).
			/// </param>
			/// <param name="y">
			/// Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).
			/// </param>
			/// <param name="width">
			/// Specify the width and height of the viewport. When a GL context is first attached to a window, <paramref name="width"/> 
			/// and <paramref name="height"/> are set to the dimensions of that window.
			/// </param>
			/// <param name="height">
			/// Specify the width and height of the viewport. When a GL context is first attached to a window, <paramref name="width"/> 
			/// and <paramref name="height"/> are set to the dimensions of that window.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
			[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
			public static void Viewport(int x, int y, int width, int height)
			{
				Debug.Assert(Delegates.pglViewport != null, "pglViewport not implemented");
				Delegates.pglViewport(x, y, width, height);
				LogCommand("glViewport", null, x, y, width, height				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glBitmap: draw a bitmap
			/// </summary>
			/// <param name="width">
			/// Specify the pixel width and height of the bitmap image.
			/// </param>
			/// <param name="height">
			/// Specify the pixel width and height of the bitmap image.
			/// </param>
			/// <param name="xorig">
			/// Specify the location of the origin in the bitmap image. The origin is measured from the lower left corner of the bitmap, 
			/// with right and up being the positive axes.
			/// </param>
			/// <param name="yorig">
			/// Specify the location of the origin in the bitmap image. The origin is measured from the lower left corner of the bitmap, 
			/// with right and up being the positive axes.
			/// </param>
			/// <param name="xmove">
			/// Specify the x and y offsets to be added to the current raster position after the bitmap is drawn.
			/// </param>
			/// <param name="ymove">
			/// Specify the x and y offsets to be added to the current raster position after the bitmap is drawn.
			/// </param>
			/// <param name="bitmap">
			/// Specifies the address of the bitmap image.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Bitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap)
			{
				unsafe {
					fixed (byte* p_bitmap = bitmap)
					{
						Debug.Assert(Delegates.pglBitmap != null, "pglBitmap not implemented");
						Delegates.pglBitmap(width, height, xorig, yorig, xmove, ymove, p_bitmap);
						LogCommand("glBitmap", null, width, height, xorig, yorig, xmove, ymove, bitmap						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glIndexd: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(double c)
			{
				Debug.Assert(Delegates.pglIndexd != null, "pglIndexd not implemented");
				Delegates.pglIndexd(c);
				LogCommand("glIndexd", null, c				);
			}

			/// <summary>
			/// [GL2.1] glIndexdv: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(double[] c)
			{
				Debug.Assert(c.Length >= 1);
				unsafe {
					fixed (double* p_c = c)
					{
						Debug.Assert(Delegates.pglIndexdv != null, "pglIndexdv not implemented");
						Delegates.pglIndexdv(p_c);
						LogCommand("glIndexdv", null, c						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glIndexf: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(float c)
			{
				Debug.Assert(Delegates.pglIndexf != null, "pglIndexf not implemented");
				Delegates.pglIndexf(c);
				LogCommand("glIndexf", null, c				);
			}

			/// <summary>
			/// [GL2.1] glIndexfv: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(float[] c)
			{
				Debug.Assert(c.Length >= 1);
				unsafe {
					fixed (float* p_c = c)
					{
						Debug.Assert(Delegates.pglIndexfv != null, "pglIndexfv not implemented");
						Delegates.pglIndexfv(p_c);
						LogCommand("glIndexfv", null, c						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glIndexi: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(int c)
			{
				Debug.Assert(Delegates.pglIndexi != null, "pglIndexi not implemented");
				Delegates.pglIndexi(c);
				LogCommand("glIndexi", null, c				);
			}

			/// <summary>
			/// [GL2.1] glIndexiv: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(int[] c)
			{
				Debug.Assert(c.Length >= 1);
				unsafe {
					fixed (int* p_c = c)
					{
						Debug.Assert(Delegates.pglIndexiv != null, "pglIndexiv not implemented");
						Delegates.pglIndexiv(p_c);
						LogCommand("glIndexiv", null, c						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glIndexs: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(short c)
			{
				Debug.Assert(Delegates.pglIndexs != null, "pglIndexs not implemented");
				Delegates.pglIndexs(c);
				LogCommand("glIndexs", null, c				);
			}

			/// <summary>
			/// [GL2.1] glIndexsv: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(short[] c)
			{
				Debug.Assert(c.Length >= 1);
				unsafe {
					fixed (short* p_c = c)
					{
						Debug.Assert(Delegates.pglIndexsv != null, "pglIndexsv not implemented");
						Delegates.pglIndexsv(p_c);
						LogCommand("glIndexsv", null, c						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// <para>
			/// [GL2.1|GLES1.1] glFogf: specify fog parameters
			/// </para>
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, Gl.FOG_END, Gl.FOG_INDEX, and 
			/// Gl.FOG_COORD_SRC are accepted.
			/// </param>
			/// <param name="param">
			/// Specifies the value that <paramref name="pname"/> will be set to.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Fog(FogParameter pname, float param)
			{
				Debug.Assert(Delegates.pglFogf != null, "pglFogf not implemented");
				Delegates.pglFogf((int)pname, param);
				LogCommand("glFogf", null, pname, param				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// <para>
			/// [GL2.1|GLES1.1] glFogfv: specify fog parameters
			/// </para>
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, Gl.FOG_END, Gl.FOG_INDEX, and 
			/// Gl.FOG_COORD_SRC are accepted.
			/// </param>
			/// <param name="params">
			/// A <see cref="T:float[]"/>.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Fog(FogParameter pname, float[] @params)
			{
				unsafe {
					fixed (float* p_params = @params)
					{
						Debug.Assert(Delegates.pglFogfv != null, "pglFogfv not implemented");
						Delegates.pglFogfv((int)pname, p_params);
						LogCommand("glFogfv", null, pname, @params						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glFogi: specify fog parameters
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, Gl.FOG_END, Gl.FOG_INDEX, and 
			/// Gl.FOG_COORD_SRC are accepted.
			/// </param>
			/// <param name="param">
			/// Specifies the value that <paramref name="pname"/> will be set to.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Fog(FogParameter pname, int param)
			{
				Debug.Assert(Delegates.pglFogi != null, "pglFogi not implemented");
				Delegates.pglFogi((int)pname, param);
				LogCommand("glFogi", null, pname, param				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glFogiv: specify fog parameters
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, Gl.FOG_END, Gl.FOG_INDEX, and 
			/// Gl.FOG_COORD_SRC are accepted.
			/// </param>
			/// <param name="params">
			/// A <see cref="T:int[]"/>.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Fog(FogParameter pname, int[] @params)
			{
				unsafe {
					fixed (int* p_params = @params)
					{
						Debug.Assert(Delegates.pglFogiv != null, "pglFogiv not implemented");
						Delegates.pglFogiv((int)pname, p_params);
						LogCommand("glFogiv", null, pname, @params						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glAccum: operate on the accumulation buffer
			/// </summary>
			/// <param name="op">
			/// Specifies the accumulation buffer operation. Symbolic constants Gl.ACCUM, Gl.LOAD, Gl.ADD, Gl.MULT, and Gl.RETURN are 
			/// accepted.
			/// </param>
			/// <param name="value">
			/// Specifies a floating-point value used in the accumulation buffer operation. <paramref name="op"/> determines how 
			/// <paramref name="value"/> is used.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Accum(AccumOp op, float value)
			{
				Debug.Assert(Delegates.pglAccum != null, "pglAccum not implemented");
				Delegates.pglAccum((int)op, value);
				LogCommand("glAccum", null, op, value				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glIndexub: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_1")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(byte c)
			{
				Debug.Assert(Delegates.pglIndexub != null, "pglIndexub not implemented");
				Delegates.pglIndexub(c);
				LogCommand("glIndexub", null, c				);
			}

			/// <summary>
			/// [GL2.1] glIndexubv: set the current color index
			/// </summary>
			/// <param name="c">
			/// Specifies the new value for the current color index.
			/// </param>
			[RequiredByFeature("GL_VERSION_1_1")]
			[RemovedByFeature("GL_VERSION_3_2", Profile = "core")]
			public static void Index(byte[] c)
			{
				Debug.Assert(c.Length >= 1);
				unsafe {
					fixed (byte* p_c = c)
					{
						Debug.Assert(Delegates.pglIndexubv != null, "pglIndexubv not implemented");
						Delegates.pglIndexubv(p_c);
						LogCommand("glIndexubv", null, c						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GLES1.1] glFogx: specify fog parameters
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, and Gl.FOG_END are accepted.
			/// </param>
			/// <param name="param">
			/// Specifies the value that <paramref name="pname"/> will be set to.
			/// </param>
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			public static void Fog(FogPName pname, IntPtr param)
			{
				Debug.Assert(Delegates.pglFogx != null, "pglFogx not implemented");
				Delegates.pglFogx((int)pname, param);
				LogCommand("glFogx", null, pname, param				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GLES1.1] glFogxv: specify fog parameters
			/// </summary>
			/// <param name="pname">
			/// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, and Gl.FOG_END are accepted.
			/// </param>
			/// <param name="param">
			/// Specifies the value that <paramref name="pname"/> will be set to.
			/// </param>
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			public static void Fog(FogPName pname, IntPtr[] param)
			{
				unsafe {
					fixed (IntPtr* p_param = param)
					{
						Debug.Assert(Delegates.pglFogxv != null, "pglFogxv not implemented");
						Delegates.pglFogxv((int)pname, p_param);
						LogCommand("glFogxv", null, pname, param						);
					}
				}
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glHistogram: define histogram table
			/// </summary>
			/// <param name="target">
			/// The histogram whose parameters are to be set. Must be one of Gl.HISTOGRAM or Gl.PROXY_HISTOGRAM.
			/// </param>
			/// <param name="width">
			/// The number of entries in the histogram table. Must be a power of 2.
			/// </param>
			/// <param name="internalformat">
			/// The format of entries in the histogram table. Must be one of Gl.ALPHA, Gl.ALPHA4, Gl.ALPHA8, Gl.ALPHA12, Gl.ALPHA16, 
			/// Gl.LUMINANCE, Gl.LUMINANCE4, Gl.LUMINANCE8, Gl.LUMINANCE12, Gl.LUMINANCE16, Gl.LUMINANCE_ALPHA, Gl.LUMINANCE4_ALPHA4, 
			/// Gl.LUMINANCE6_ALPHA2, Gl.LUMINANCE8_ALPHA8, Gl.LUMINANCE12_ALPHA4, Gl.LUMINANCE12_ALPHA12, Gl.LUMINANCE16_ALPHA16, 
			/// Gl.R3_G3_B2, Gl.RGB, Gl.RGB4, Gl.RGB5, Gl.RGB8, Gl.RGB10, Gl.RGB12, Gl.RGB16, Gl.RGBA, Gl.RGBA2, Gl.RGBA4, Gl.RGB5_A1, 
			/// Gl.RGBA8, Gl.RGB10_A2, Gl.RGBA12, or Gl.RGBA16.
			/// </param>
			/// <param name="sink">
			/// If Gl.TRUE, pixels will be consumed by the histogramming process and no drawing or texture loading will take place. If 
			/// Gl.FALSE, pixels will proceed to the minmax process after histogramming.
			/// </param>
			[RequiredByFeature("GL_ARB_imaging", Profile = "compatibility")]
			[RequiredByFeature("GL_EXT_histogram")]
			public static void Histogram(HistogramTarget target, int width, InternalFormat internalformat, bool sink)
			{
				Debug.Assert(Delegates.pglHistogram != null, "pglHistogram not implemented");
				Delegates.pglHistogram((int)target, width, (int)internalformat, sink);
				LogCommand("glHistogram", null, target, width, internalformat, sink				);
				DebugCheckErrors(null);
			}

			/// <summary>
			/// [GL2.1] glMinmax: define minmax table
			/// </summary>
			/// <param name="target">
			/// The minmax table whose parameters are to be set. Must be Gl.MINMAX.
			/// </param>
			/// <param name="internalformat">
			/// The format of entries in the minmax table. Must be one of Gl.ALPHA, Gl.ALPHA4, Gl.ALPHA8, Gl.ALPHA12, Gl.ALPHA16, 
			/// Gl.LUMINANCE, Gl.LUMINANCE4, Gl.LUMINANCE8, Gl.LUMINANCE12, Gl.LUMINANCE16, Gl.LUMINANCE_ALPHA, Gl.LUMINANCE4_ALPHA4, 
			/// Gl.LUMINANCE6_ALPHA2, Gl.LUMINANCE8_ALPHA8, Gl.LUMINANCE12_ALPHA4, Gl.LUMINANCE12_ALPHA12, Gl.LUMINANCE16_ALPHA16, 
			/// Gl.R3_G3_B2, Gl.RGB, Gl.RGB4, Gl.RGB5, Gl.RGB8, Gl.RGB10, Gl.RGB12, Gl.RGB16, Gl.RGBA, Gl.RGBA2, Gl.RGBA4, Gl.RGB5_A1, 
			/// Gl.RGBA8, Gl.RGB10_A2, Gl.RGBA12, or Gl.RGBA16.
			/// </param>
			/// <param name="sink">
			/// If Gl.TRUE, pixels will be consumed by the minmax process and no drawing or texture loading will take place. If 
			/// Gl.FALSE, pixels will proceed to the final conversion process after minmax.
			/// </param>
			[RequiredByFeature("GL_ARB_imaging", Profile = "compatibility")]
			[RequiredByFeature("GL_EXT_histogram")]
			public static void Minmax(MinmaxTarget target, InternalFormat internalformat, bool sink)
			{
				Debug.Assert(Delegates.pglMinmax != null, "pglMinmax not implemented");
				Delegates.pglMinmax((int)target, (int)internalformat, sink);
				LogCommand("glMinmax", null, target, internalformat, sink				);
				DebugCheckErrors(null);
			}

		}

		public static class VBEnum
		{
			/// <summary>
			/// [GL] Value of GL_CLEAR symbol.
			/// </summary>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			public const int CLEAR = 0x1500;

			/// <summary>
			/// <para>
			/// [GL4] Gl.Get: When used with non-indexed variants of glGet (such as glGetIntegerv), data returns four values: the x and 
			/// y window coordinates of the viewport, followed by its width and height. Initially the x and y window coordinates are 
			/// both set to 0, and the width and height are set to the width and height of the window into which the GL will do its 
			/// rendering. See Gl.Viewport. When used with indexed variants of glGet (such as glGetIntegeri_v), data returns four 
			/// values: the x and y window coordinates of the indexed viewport, followed by its width and height. Initially the x and y 
			/// window coordinates are both set to 0, and the width and height are set to the width and height of the window into which 
			/// the GL will do its rendering. See glViewportIndexedf.
			/// </para>
			/// <para>
			/// [GLES3.2] Gl.Get: data returns four values: the x and y window coordinates of the viewport, followed by its width and 
			/// height. Initially the x and y window coordinates are both set to 0, and the width and height are set to the width and 
			/// height of the window into which the GL will do its rendering. See Gl.Viewport.
			/// </para>
			/// </summary>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			[RequiredByFeature("GL_ES_VERSION_2_0", Api = "gles2")]
			[RequiredByFeature("GL_SC_VERSION_2_0", Api = "glsc2")]
			[RequiredByFeature("GL_ARB_viewport_array", Api = "gl|glcore")]
			[RequiredByFeature("GL_NV_viewport_array", Api = "gles2")]
			[RequiredByFeature("GL_OES_viewport_array", Api = "gles2")]
			public const int VIEWPORT = 0x0BA2;

			/// <summary>
			/// [GL] Value of GL_BITMAP symbol (DEPRECATED).
			/// </summary>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2")]
			public const int BITMAP = 0x1A00;

			/// <summary>
			/// [GL] Value of GL_INDEX symbol (DEPRECATED).
			/// </summary>
			[RequiredByFeature("GL_VERSION_3_0")]
			[RequiredByFeature("GL_ARB_framebuffer_object", Api = "gl|glcore")]
			[RemovedByFeature("GL_VERSION_3_2")]
			public const int INDEX = 0x8222;

			/// <summary>
			/// <para>
			/// [GL2.1] Gl.Enable: If enabled and no fragment shader is active, blend a fog color into the post-texturing color. See 
			/// Gl.Fog.
			/// </para>
			/// <para>
			/// [GL2.1] Gl.Get: params returns a single boolean value indicating whether fogging is enabled. The initial value is 
			/// Gl.FALSE. See Gl.Fog.
			/// </para>
			/// <para>
			/// [GLES1.1] Gl.Enable: If enabled, blend a fog color into the posttexturing color. See Gl.Fog.
			/// </para>
			/// <para>
			/// [GLES1.1] Gl.Get: params returns a single boolean value indicating whether fog is enabled. The initial value is 
			/// Gl.FALSE. See Gl.Fog.
			/// </para>
			/// </summary>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
			[RequiredByFeature("GL_NV_register_combiners")]
			[RemovedByFeature("GL_VERSION_3_2")]
			public const int FOG = 0x0B60;

			/// <summary>
			/// [GL2.1] Gl.Accum: Obtains R, G, B, and A values from the buffer currently selected for reading (see Gl.ReadBuffer). Each 
			/// component value is divided by 2n-1, where n is the number of bits allocated to each color component in the currently 
			/// selected buffer. The result is a floating-point value in the range 01, which is multiplied by value and added to the 
			/// corresponding pixel component in the accumulation buffer, thereby updating the accumulation buffer.
			/// </summary>
			[RequiredByFeature("GL_VERSION_1_0")]
			[RemovedByFeature("GL_VERSION_3_2")]
			public const int ACCUM = 0x0100;

			/// <summary>
			/// <para>
			/// [GL2.1] Gl.Enable: If enabled, histogram incoming RGBA color values. See Gl.Histogram.
			/// </para>
			/// <para>
			/// [GL2.1] Gl.Get: params returns a single boolean value indicating whether histogram is enabled. The initial value is 
			/// Gl.FALSE. See Gl.Histogram.
			/// </para>
			/// </summary>
			[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
			[RequiredByFeature("GL_EXT_histogram")]
			public const int HISTOGRAM = 0x8024;

			/// <summary>
			/// <para>
			/// [GL2.1] Gl.Enable: If enabled, compute the minimum and maximum values of incoming RGBA color values. See Gl.Minmax.
			/// </para>
			/// <para>
			/// [GL2.1] Gl.Get: params returns a single boolean value indicating whether pixel minmax values are computed. The initial 
			/// value is Gl.FALSE. See Gl.Minmax.
			/// </para>
			/// </summary>
			[RequiredByFeature("GL_ARB_imaging", Api = "gl|glcore")]
			[RequiredByFeature("GL_EXT_histogram")]
			public const int MINMAX = 0x802E;

		}
}

}
