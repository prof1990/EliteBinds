using System;

namespace EliteBinds
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class InputWidget : Gtk.Bin
    {
        public InputWidget() {
            this.Build();
        }

        public static InputWidget GenField (BindEntry entry){
            var w =  new InputWidget();
            w.FieldName.Text = entry.name;
            w.FieldValue.Text = entry.value.ToString();
            return w;

        }
    }
}

