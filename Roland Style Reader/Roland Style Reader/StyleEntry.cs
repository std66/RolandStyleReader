using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This class represents an entry in the style
	/// </summary>
	public class StyleEntry {
		private Instrument instrument;

		public Instrument Instrument {
			get { return instrument; }
		}

		private ChordType chordType;

		public ChordType ChordType {
			get { return chordType; }
		}

		private StylePart part;

		public StylePart Part {
			get { return part; }
			set { part = value; }
		}

		private Arrangement arrangement;

		public Arrangement Arrangement {
			get { return arrangement; }
			set { arrangement = value; }
		}
		

		private MidiMessage message;

		public MidiMessage Message {
			get { return message; }
		}

		public StyleEntry(Arrangement Arrange, StylePart Part, Instrument Instrument, ChordType ChordType, MidiMessage Message) {
			this.arrangement = Arrange;
			this.part = Part;
			this.instrument = Instrument;
			this.chordType = ChordType;
			this.message = Message;
		}
		
	}
}
