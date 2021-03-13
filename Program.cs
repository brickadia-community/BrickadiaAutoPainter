using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickadiaAutoPainter {
	static class Program {
		private static IntPtr? brickadiaIntPtr = null;

		public static IntPtr GetBrickadiaIntPtr() {
			if (brickadiaIntPtr.HasValue) return brickadiaIntPtr.Value;

			List<Process> processes = Process.GetProcesses().ToList();
			Process brickadia = processes.Find((p) => p.ProcessName.Contains("Brickadia"));
			if (brickadia == null) {
				MessageBox.Show("Unable to find Brickadia!");
				Application.Exit();
				throw new Exception("Unable to find Brickadia process");
			}

			brickadiaIntPtr = brickadia.MainWindowHandle;
			return brickadia.MainWindowHandle;
		}

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
