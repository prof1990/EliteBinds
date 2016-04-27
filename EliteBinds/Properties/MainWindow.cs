using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
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
		var a = new Gtk.AboutDialog ();
		a.Show ();
	}

	protected virtual void OnButtonSaveClicked(object sender, EventArgs e){
		Console.Beep (1000, 10);
	}
	protected void OnSaveClicked (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}


	protected virtual void OnSaveButtonClicked (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
}
