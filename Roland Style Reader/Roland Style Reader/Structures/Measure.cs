using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents a metronome mark
	/// </summary>
	public struct Measure {
		private int numerator;
		private int denominator;

		/// <summary>
		/// Gets the numerator (beats in a bar)
		/// </summary>
		public int Numerator {
			get { return numerator; }
		}

		/// <summary>
		/// Gets the denominator (beat length)
		/// </summary>
		public int Denominator {
			get { return denominator; }
		}

		/// <summary>
		/// Initializes a new instance of the Measure class
		/// </summary>
		/// <param name="Numerator">The numerator (beats in a bar)</param>
		/// <param name="Denominator">The denominator (beat length)</param>
		public Measure(int Numerator, int Denominator) {
			this.numerator = Numerator;
			this.denominator = Denominator;
		}

		/// <summary>
		/// Returns the string representation of the Measure object
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return this.numerator + "/" + this.denominator;
		}
	}
}
