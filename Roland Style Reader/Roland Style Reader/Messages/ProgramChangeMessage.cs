using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class ProgramChangeMessage : MidiMessage {
		public int MSB {
			get {
				return this.Data[4];
			}
		}

		public int LSB {
			get {
				return this.Data[5];
			}
		}

		public int Program {
			get {
				return this.Data[3];
			}
		}

		public ProgramChangeMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
