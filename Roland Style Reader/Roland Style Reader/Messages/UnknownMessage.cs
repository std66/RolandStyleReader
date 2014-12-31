using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This class represents an unknown message
	/// </summary>
	public class UnknownMessage : MidiMessage {
		/// <summary>
		/// Initializes a new instance of the UnknownMessage class
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public UnknownMessage(byte[] Data, int TotalTime) : base(Data, TotalTime) {

		}
	}
}
