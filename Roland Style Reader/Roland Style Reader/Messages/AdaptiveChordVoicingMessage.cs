using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents the Adaptive Chord Voicing (ACV) message's alteration mode.
	/// </summary>
	public enum AlterationMode {
		/// <summary>
		/// The old Degree alteration mode
		/// </summary>
		Degree,

		/// <summary>
		/// The new Nearest alteration mode
		/// </summary>
		Nearest
	}

	/// <summary>
	/// Represents an Adaptive Chord Voicing (ACV) message.
	/// </summary>
	class AdaptiveChordVoicingMessage : MidiMessage {
		/// <summary>
		/// Initializes a new instance of the AdaptiveChordVoicingMessage class.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public AdaptiveChordVoicingMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
