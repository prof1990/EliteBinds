using System;
using Gtk;
using GLib;
using System.IO;

namespace EliteBinds
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}

	}
}
