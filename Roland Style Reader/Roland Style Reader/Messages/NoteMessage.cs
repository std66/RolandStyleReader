using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class NoteMessage : MidiMessage {
		public int Note {
			get {
				return this.Data[1];
			}
		}

		public int Velocity {
			get {
				return this.Data[3];
			}
		}

		public int Length {
			get {
				return this.Data[5] + 1;
			}
		}

		public string Name {
			get {
				Dictionary<int, string> Names = new Dictionary<int, string>() {
					{0, "C"},
					{1, "C#"},
					{2, "D"},
					{3, "D#"},
					{4, "E"},
					{5, "F"},
					{6, "F#"},
					{7, "G"},
					{8, "G#"},
					{9, "A"},
					{10, "A#"},
					{11, "B"},
				};

				return Names[this.Note % 12];
			}
		}

		public int Octave {
			get {
				return this.Note / 12 - 2;
			}
		}

		public NoteMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {
				if (this.Note < 0 || this.Note > 127)
					throw new Exception("A hangjegynek 0 és 127 közé kell esnie");

				if (this.Velocity < 0 || this.Velocity > 127)
					throw new Exception("A dinamikának 0 és 127 közé kell esnie");
		}
	}
}
