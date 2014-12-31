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
		private ChordType chordType;
		private StylePart part;
		private Arrangement arrangement;
		private MidiMessage message;

		/// <summary>
		/// Gets the instrument associated to this entry
		/// </summary>
		public Instrument Instrument {
			get { return instrument; }
		}

		/// <summary>
		/// Gets the chord type associated to this entry
		/// </summary>
		public ChordType ChordType {
			get { return chordType; }
		}

		/// <summary>
		/// Gets or sets the style part associated to this entry
		/// </summary>
		public StylePart Part {
			get { return part; }
			set { part = value; }
		}

		/// <summary>
		/// Gets the arrangement associated to this entry
		/// </summary>
		public Arrangement Arrangement {
			get { return arrangement; }
			set { arrangement = value; }
		}
		
		/// <summary>
		/// Gets the message associated to this entry
		/// </summary>
		public MidiMessage Message {
			get { return message; }
		}

		/// <summary>
		/// Constructs a new instance of the StyleEntry class.
		/// </summary>
		/// <param name="Arrange">The arrangement</param>
		/// <param name="Part">The style part</param>
		/// <param name="Instrument">The instrument</param>
		/// <param name="ChordType">The chord family</param>
		/// <param name="Message">The message</param>
		public StyleEntry(Arrangement Arrange, StylePart Part, Instrument Instrument, ChordType ChordType, MidiMessage Message) {
			this.arrangement = Arrange;
			this.part = Part;
			this.instrument = Instrument;
			this.chordType = ChordType;
			this.message = Message;
		}
		
	}
}
