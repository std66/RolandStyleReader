using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class DataEntryMessage : MidiMessage {
		public DataEntryMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
