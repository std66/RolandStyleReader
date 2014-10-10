using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This exception occures when a part of the style is not defined.
	/// </summary>
	public class StylePartNotFoundException : Exception {
		/// <summary>
		/// Initializes a new instance of the StylePartNotFoundException class
		/// </summary>
		public StylePartNotFoundException() : base("The requested style part not found") {

		}
	}
}
