using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents the type of the midi message
	/// </summary>
	public enum MidiMessageType {
		/// <summary>
		/// Represents the control change message type
		/// </summary>
		ControlChange = 0xE6,

		/// <summary>
		/// Represents the program change message type
		/// </summary>
		ProgramChange = 0xE5,

		/// <summary>
		/// Represents the pitch wheel message type
		/// </summary>
		PitchWheel = 0xEB,

		/// <summary>
		/// Represents the data entry message type
		/// </summary>
		DataEntry = 0xEA,

		/// <summary>
		/// Represents the adaptive chord voicing (ACV) message type
		/// </summary>
		AdaptiveChordVoicing = 0x8A,

		/// <summary>
		/// Represents the note message type
		/// </summary>
		Note = -1
	}
}
