using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This exception occures when a note's value is less than 0 or larger than 127
	/// </summary>
	class NoteValueOutOfRangeException : Exception {
		private int noteValue;

		/// <summary>
		/// Gets the Note value associated with the exception
		/// </summary>
		public int NoteValue {
			get { return noteValue; }
		}
		
		/// <summary>
		/// Initializes a new instance of the NoteValueOutOfRangeException
		/// </summary>
		/// <param name="NoteValue">The value of the note</param>
		public NoteValueOutOfRangeException(int NoteValue) : base("Note value out of range") {
			this.noteValue = NoteValue;
		}
	}
}
