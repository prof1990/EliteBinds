using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EliteBinds
{
	public class EliteBindsFile
	{
		private IDictionary<string,string> settings;
		public IDictionary<string,string> GetAllSettings {get { return settings; }}

		/// <summary>
		/// initializes the class with the passed bindings file
		/// </summary>
		/// <param name="dotBindsFile">the .binds file to be loaded</param>
		public EliteBindsFile (XDocument dotBindsFile)
		{
		}
	}
}

