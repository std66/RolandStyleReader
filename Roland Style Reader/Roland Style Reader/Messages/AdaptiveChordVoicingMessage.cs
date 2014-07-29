using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public enum AlterationMode {
		Degree,
		Nearest
	}

	class AdaptiveChordVoicingMessage : MidiMessage {
		public AdaptiveChordVoicingMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
