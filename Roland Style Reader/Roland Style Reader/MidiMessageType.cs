using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public enum MidiMessageType {
		ControlChange = 0xE6,
		ProgramChange = 0xE5,
		PitchWheel = 0xEB,
		DataEntry = 0xEA,
		AdaptiveChordVoicing = 0x8A,
		Note = -1
	}
}
