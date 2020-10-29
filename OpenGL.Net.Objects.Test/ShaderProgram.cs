<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL.Objects.Test
{
	class ShaderProgramTest
	{
		public void ExampleCreateShaderProgram(GraphicsContext ctx, IEnumerable<Shader> shaderObjects)
		{
			ShaderProgram shaderProgram = new ShaderProgram("SampleProgram");

			foreach (Shader shader in shaderObjects)
				shaderProgram.AttachShader(shader);

			shaderProgram.Create(ctx);
		}

		public void ExampleSetShaderProgramUniform(GraphicsContext ctx, ShaderProgram shaderProgram)
		{
			// uniform vec4 my_Vec4Uniform;
			shaderProgram.SetUniform(ctx, "my_Vec4Uniform", new Vertex4f(1.0f));
			// uniform int my_IntUniform;
			shaderProgram.SetUniform(ctx, "my_IntUniform", 255);
			// uniform int my_BoolUniform;
			shaderProgram.SetUniform(ctx, "my_BoolUniform", false);
			// uniform int my_ArrayUniform[4];
			shaderProgram.SetUniform(ctx, "my_ArrayUniform", new int[] { 1, 2, 3, 4 });
			// uniform mat4 my_Mat4Uniform;
			shaderProgram.SetUniform(ctx, "my_Mat4Uniform", Matrix4x4d.Identity);
		}
	}
}
=======
﻿
// Copyright (C) 2019 Luca Piccioni
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NUnit.Framework;

namespace OpenGL.Objects.Test
{
	[TestFixture]
	class ShaderProgramTest : TestBase
	{
		[Test]
		public void ShaderProgram_CreateSimple()
		{
			using (ShaderProgram shaderProgram = new ShaderProgram("OpenGL.Objects.Test.ShaderProgram.Link"))
			using (Shader vertexShader = new Shader(ShaderType.VertexShader))
			using (Shader fragmentShader = new Shader(ShaderType.FragmentShader))
			{
				// Create shaders
				vertexShader.LoadSource(new[] {
					"#version 150",
					"void main() {",
					"	gl_Position = vec4(0.0, 0.0, 0.0, 1.0);",
					"}",
				});
				Assert.IsFalse(vertexShader.Exists(_Context));

				fragmentShader.LoadSource(new[] {
					"#version 150",
					"out vec4 test_Output;",
					"void main() {",
					"	test_Output = vec4(0.0, 0.0, 0.0, 1.0);",
					"}",
				});
				

				// Attach shaders
				Assert.DoesNotThrow(() => { shaderProgram.Attach(vertexShader); });
				Assert.DoesNotThrow(() => { shaderProgram.Attach(fragmentShader); });
				// Attachment does not create resources
				Assert.IsFalse(vertexShader.Exists(_Context));
				Assert.IsFalse(fragmentShader.Exists(_Context));
				
				// Compile and link
				Assert.IsFalse(shaderProgram.IsLinked);
				shaderProgram.Create(_Context);
				Assert.IsTrue(shaderProgram.IsLinked);
				Assert.IsTrue(vertexShader.Exists(_Context));
				Assert.IsTrue(fragmentShader.Exists(_Context));
			}
		}

		[Test]
		public void ShaderProgram_SaveBinary()
		{
			if (!_Context.IsProgramBinarySupported)
				Assert.Inconclusive();

			byte[] programBinary = null;
			int programBinaryFormat = 0;

			// Save program to binary format
			using (ShaderProgram shaderProgram = new ShaderProgram("OpenGL.Objects.Test.ShaderProgram.Link"))
			using (Shader vertexShader = new Shader(ShaderType.VertexShader))
			using (Shader fragmentShader = new Shader(ShaderType.FragmentShader))
			{
				vertexShader.LoadSource(new[] {
					"#version 150",
					"in vec4 vPosition;",
					"void main() {",
					"	gl_Position = vPosition;",
					"}",
				});

				fragmentShader.LoadSource(new[] {
					"#version 150",
					"out vec4 test_Output;",
					"void main() {",
					"	test_Output = vec4(0.0, 0.0, 0.0, 1.0);",
					"}",
				});
				

				shaderProgram.Attach(vertexShader);
				shaderProgram.Attach(fragmentShader);
				shaderProgram.Create(_Context);

				Assert.IsTrue(shaderProgram.IsLinked);
				Assert.AreEqual("vPosition", shaderProgram.ActiveAttributes.First());

				Assert.DoesNotThrow(() => {
					using (MemoryStream memoryStream = new MemoryStream()) {
						shaderProgram.GetBinary(_Context, memoryStream, out programBinaryFormat);

						programBinary = memoryStream.ToArray();
					}
				});
			}

			// Save program to binary format
			using (ShaderProgram shaderProgram = new ShaderProgram("OpenGL.Objects.Test.ShaderProgram.Link"))
			{
				shaderProgram.Create(_Context, programBinary, programBinaryFormat);

				Assert.IsTrue(shaderProgram.IsLinked);
				Assert.AreEqual("vPosition", shaderProgram.ActiveAttributes.First());
			}
		}

		#region Examples

		public void ExampleCreateShaderProgram(GraphicsContext ctx, IEnumerable<Shader> shaderObjects)
		{
			ShaderProgram shaderProgram = new ShaderProgram("SampleProgram");

			foreach (Shader shader in shaderObjects)
				shaderProgram.Attach(shader);

			shaderProgram.Create(ctx);
		}

		public void ExampleSetShaderProgramUniform(GraphicsContext ctx, ShaderProgram shaderProgram)
		{
			// uniform vec4 my_Vec4Uniform;
			shaderProgram.SetUniform(ctx, "my_Vec4Uniform", new Vertex4f(1.0f));
			// uniform int my_IntUniform;
			shaderProgram.SetUniform(ctx, "my_IntUniform", 255);
			// uniform int my_BoolUniform;
			shaderProgram.SetUniform(ctx, "my_BoolUniform", false);
			// uniform int my_ArrayUniform[4];
			shaderProgram.SetUniform(ctx, "my_ArrayUniform", new int[] { 1, 2, 3, 4 });
			// uniform mat4 my_Mat4Uniform;
			shaderProgram.SetUniform(ctx, "my_Mat4Uniform", Matrix4x4d.Identity);
		}

		#endregion
	}
}
>>>>>>> 540aacd305c7bd2e6b7148cadc6574b49fe9a458
