using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents a Data Entry message
	/// </summary>
	public class DataEntryMessage : MidiMessage {
		/// <summary>
		/// Initializes a new instance of the DataEntryMessage class.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public DataEntryMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
