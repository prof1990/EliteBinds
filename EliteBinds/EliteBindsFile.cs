using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EliteBinds
{
	public enum Categorys {Flight,SRV,map,other};
	public class EliteBindsFile
	{
		private IDictionary<string,BindEntry> settings;
		private XDocument currentBinds;
		public IDictionary<string,BindEntry> GetAllSettings {get { return settings; }}

		/// <summary>
		/// initializes the class with the passed bindings file
		/// </summary>
		/// <param name="dotBindsFile">the .binds file to be loaded</param>
		public EliteBindsFile (XDocument dotBindsFile)
		{
			currentBinds = dotBindsFile;
			foreach (var xn in dotBindsFile.Root.Elements()) {
				if (!xn.HasElements) {
					var entry = new BindValueEntry (xn);
					settings.Add (entry.name, entry);
				} else {
					var entry = new BindCollectionEntry ();
					settings.Add (entry.name, entry);
				}
			}
		}
	}

	public interface BindEntry{
		string name { get; }
		object value { get;}
		bool SetValue (object value);
	}

	public class BindKeyEntry : BindEntry 
	{
		
		#region BindEntry implementation
		public bool SetValue (object value)
		{
			throw new NotImplementedException ();
		}
		public string name {
			get {
				throw new NotImplementedException ();
			}
		}
		public object value {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		
	}

	public class BindCollectionEntry : BindEntry
	{
		#region BindEntry implementation
		public bool SetValue (object value)
		{
			throw new NotImplementedException ();
		}
		public string name {
			get {
				throw new NotImplementedException ();
			}
		}
		public object value {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		
	}

	public class BindValueEntry : BindEntry
	{
		public String name { get; private set; }
		public object value { get; set; }
		public Type valueType { get; private set;}
		public Categorys category;

		public bool SetValue (object value)
		{
			if (value is ValueType) {
				this.value = value;
				return true;
			}
			return false;
		}

		public BindValueEntry (string name, object value, Categorys cat){
			this.name = name;
			this.value = value;
			valueType = value.GetType ();
			category = cat;
		}

		public BindValueEntry(XElement elem)
		{
			name = elem.Name.LocalName;
			value = elem.Attribute ("Value").Value;
			valueType = typeof(string);
		}
	}
}

