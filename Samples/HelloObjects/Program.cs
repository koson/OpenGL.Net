<<<<<<< HEAD
﻿
// Copyright (C) 2016-2017 Luca Piccioni
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
// USA

using System;
using System.Windows.Forms;

using Khronos;
using OpenGL.Objects;

namespace HelloObjects
{
	/// <summary>
	/// OpenGL.Objects sample application.
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			string envDebug = Environment.GetEnvironmentVariable("DEBUG");

			switch (envDebug) {
				case "GL":
					KhronosApi.Log += delegate(object sender, KhronosLogEventArgs e) {
						Console.WriteLine(e.ToString());
					};
					KhronosApi.LogEnabled = true;
					break;
				case "OBJECTS":
					Resource.RegisterApplicationLogDelegate(Console.WriteLine);
					KhronosApi.LogEnabled = false;
					break;
			}

			Application.ThreadException += Application_ThreadException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SampleForm());
			
			Resource.CheckResourceLeaks();
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			
		}
	}
}
=======
﻿
// Copyright (C) 2016-2017 Luca Piccioni
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
// USA

using System;
using System.Diagnostics;
using System.Windows.Forms;

using Khronos;
using OpenGL.Objects;

namespace HelloObjects
{
	/// <summary>
	/// OpenGL.Objects sample application.
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			string envDebug = Environment.GetEnvironmentVariable("DEBUG");

			switch (envDebug) {
				case "GL":
					KhronosApi.Log += delegate(object sender, KhronosLogEventArgs e) {
						Console.WriteLine(e.ToString());
					};
					KhronosApi.LogEnabled = true;
					break;
				case "OBJECTS":
					Resource.RegisterApplicationLogDelegate(Console.WriteLine);
					KhronosApi.LogEnabled = false;
					break;
			}

			Application.ThreadException += Application_ThreadException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SampleForm());
			
			Resource.CheckResourceLeaks();
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
#if DEBUG
			Debugger.Break();
#endif
		}
	}
}
>>>>>>> 540aacd305c7bd2e6b7148cadc6574b49fe9a458
