using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents a Program Change message
	/// </summary>
	public class ProgramChangeMessage : MidiMessage {
		/// <summary>
		/// Gets the Bank Select MSB. See Roland GS standard for more details
		/// </summary>
		public int MSB {
			get {
				return this.Data[4];
			}
		}

		/// <summary>
		/// Gets the Bank Select LSB. See Roland GS standard for more details
		/// </summary>
		public int LSB {
			get {
				return this.Data[5];
			}
		}

		/// <summary>
		/// Gets the program number in the given bank. See Roland GS standard for more details
		/// </summary>
		public int Program {
			get {
				return this.Data[3];
			}
		}

		/// <summary>
		/// Initializes a new instance of the ProgramChangeMessage class.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public ProgramChangeMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
