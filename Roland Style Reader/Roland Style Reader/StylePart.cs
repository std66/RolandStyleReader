using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents the style parts
	/// </summary>
	public enum StylePart {
		Intro = 0,
		Original = 1,
		Variation = 2,
		Variation2 = 3,
		FillToOriginal = 4,
		FillToVariation = 5,
		FillToVariation2 = 6,
		Ending = 7
	}
}
