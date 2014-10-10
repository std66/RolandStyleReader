using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This exception occures when a note's velocity value is less than 0 or larger than 127
	/// </summary>
	public class NoteVelocityOutOfRangeException : Exception {
		private int velocity;

		/// <summary>
		/// Gets the velocity value associated with the exception
		/// </summary>
		public int Velocity {
			get { return velocity; }
		}

		/// <summary>
		/// Initializes a new instance of the NoteVelocityOutOfRangeException.
		/// </summary>
		/// <param name="Velocity">The note's velocity value</param>
		public NoteVelocityOutOfRangeException(int Velocity) : base("Note velocity out of range") {
			this.velocity = Velocity;
		}
	}
}
