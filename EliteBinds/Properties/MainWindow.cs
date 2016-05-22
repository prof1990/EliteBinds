using System;
using Gtk;
using EliteBinds;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.InteropServices;
using GLib;
using System.Reflection;

public partial class MainWindow: Gtk.Window
{
	private EliteBindsFile edditableBinds;
    private List<InputWidget> inpFields;
   

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//TODO: bind the tabs to inputfield container so they can be filled
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
		RebuildBindsView ();
	}

	protected virtual void OnButtonSaveClicked(object sender, EventArgs e){
		Console.Beep (1000, 10);
	}


	protected virtual void OnButtonApplyClicked (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}

	private void RebuildBindsView()
	{
		if (inpFields != null)
            foreach (InputWidget f in inpFields) {
				this.Remove (f);
			}
        inpFields = new List<InputWidget> ();
		foreach (var bindKV in edditableBinds.GetAllSettings) 
		{
            var field = InputWidget.GenField (bindKV.Value);
            FlightControlsBox.Add(field);
			field.Show();
		}
	}
}
