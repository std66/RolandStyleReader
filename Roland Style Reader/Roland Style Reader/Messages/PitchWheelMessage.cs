using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents a Pitch Wheel message
	/// </summary>
	public class PitchWheelMessage : MidiMessage {
		/// <summary>
		/// Initializes a new instance of the PitchWheelMessage class
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public PitchWheelMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
