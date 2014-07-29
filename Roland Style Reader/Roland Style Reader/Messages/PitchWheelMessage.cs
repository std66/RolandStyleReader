using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class PitchWheelMessage : MidiMessage {
		public PitchWheelMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
