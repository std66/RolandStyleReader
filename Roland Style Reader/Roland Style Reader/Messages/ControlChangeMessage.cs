using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public enum ControlType {
		Expression = 0xB,
		Reverb = 0x5B,
		Chorus = 0x5D,
		Pan = 0xA,
	}

	public class ControlChangeMessage : MidiMessage {
		public ControlType Control {
			get {
				return (ControlType)this.Data[4];
			}
		}

		public int Value {
			get {
				return this.Data[5];
			}
		}

		public ControlChangeMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
