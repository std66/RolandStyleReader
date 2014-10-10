using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class UnknownMessage : MidiMessage {
		public UnknownMessage(byte[] Data, int TotalTime) : base(Data, TotalTime) {

		}
	}
}
