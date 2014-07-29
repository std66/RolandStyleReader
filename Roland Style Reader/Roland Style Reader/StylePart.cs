using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents the style parts
	/// </summary>
	public enum StylePart {
		/// <summary>
		/// Represents the Intro style part
		/// </summary>
		Intro = 0,

		/// <summary>
		/// Represents the Original style part
		/// </summary>
		Original = 1,

		/// <summary>
		/// Represents the Variation style part
		/// </summary>
		Variation = 2,

		/// <summary>
		/// Represents the Variation2 style part
		/// </summary>
		Variation2 = 3,

		/// <summary>
		/// Represents the Fill To Original style part
		/// </summary>
		FillToOriginal = 4,

		/// <summary>
		/// Represents the Fill To Variation style part
		/// </summary>
		FillToVariation = 5,

		/// <summary>
		/// Represents the Fill To Variation2 style part
		/// </summary>
		FillToVariation2 = 6,

		/// <summary>
		/// Represents the Ending style part
		/// </summary>
		Ending = 7
	}
}
