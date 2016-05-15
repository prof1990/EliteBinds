using System;
using Gtk;

namespace EliteBinds
{
	public class InputField : Gtk.Container
	{
		Label FieldName;
		Label FieldValue;
		public InputField (BindEntry data)
		{
			FieldName = new Label (data.name);
			FieldValue = new Label (data.value.ToString ());
		}

		public static InputField GenField(BindEntry entry){
			return new InputField (entry);
		}
	}
}

