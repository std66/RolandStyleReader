using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents a Note message
	/// </summary>
	public class NoteMessage : MidiMessage {
		/// <summary>
		/// Gets the number of the note. See the documentation of the General MIDI standard
		/// </summary>
		public int Note {
			get {
				return this.Data[1];
			}
		}

		/// <summary>
		/// Gets the velocity of the note
		/// </summary>
		public int Velocity {
			get {
				return this.Data[3];
			}
		}

		/// <summary>
		/// Gets the length of the note in ticks
		/// </summary>
		public int Length {
			get {
				return this.Data[5] + 1;
			}
		}

		/// <summary>
		/// Gets the human-friendly name of the note from the Note property
		/// </summary>
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

		/// <summary>
		/// Gets the octave of the note from the Note property
		/// </summary>
		public int Octave {
			get {
				return this.Note / 12 - 2;
			}
		}

		/// <summary>
		/// Initializes a new instance of the NoteMessage class.
		/// 
		/// <para>
		/// Exceptions:
		/// <para>NoteValueOutOfRangeException</para>
		/// <para>NoteVelocityOutOfRangeException</para>
		/// </para>
		/// 
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public NoteMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {
				if (this.Note < 0 || this.Note > 127)
					throw new NoteValueOutOfRangeException(this.Note);

				if (this.Velocity < 0 || this.Velocity > 127)
					throw new NoteVelocityOutOfRangeException(this.Velocity);
		}
	}
}
