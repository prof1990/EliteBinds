using System;
using Gtk;
using EliteBinds;
using System.IO;
using System.Xml.Linq;
using System.Runtime.InteropServices;

public partial class MainWindow: Gtk.Window
{
	private EliteBindsFile edditableBinds;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnButtonOpenClicked(object sender, EventArgs e){
		var chooserDialog = new Gtk.FileChooserDialog ("Choose", this, FileChooserAction.Open,
			"Select",ResponseType.Ok,
			"Cancel",ResponseType.Close);
		chooserDialog.ShowHidden = true;
		var response = chooserDialog.Run();
		if (response != (int)ResponseType.Ok)
			return;
		var path = chooserDialog.Filename;
		XDocument settingsFile;
		if(File.Exists(path))
		{
			try {
			settingsFile = XDocument.Load (path);
			edditableBinds = new EliteBindsFile (settingsFile);
			}
			catch{}
		}
		chooserDialog.Destroy ();
	}

	protected virtual void OnButtonSaveClicked(object sender, EventArgs e){
		Console.Beep (1000, 10);
	}

	protected virtual void OnButtonApplyClicked (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
}
