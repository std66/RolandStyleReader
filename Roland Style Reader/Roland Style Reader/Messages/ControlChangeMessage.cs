using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Represents the type of a control change message.
	/// </summary>
	public enum ControlType {
		/// <summary>
		/// Represents the Expression control
		/// </summary>
		Expression = 0xB,

		/// <summary>
		/// Represents the Reverb control
		/// </summary>
		Reverb = 0x5B,

		/// <summary>
		/// Represents the Chorus control
		/// </summary>
		Chorus = 0x5D,

		/// <summary>
		/// Represents the PanPod control
		/// </summary>
		Pan = 0xA,
	}

	/// <summary>
	/// Represents a Control Change message
	/// </summary>
	public class ControlChangeMessage : MidiMessage {
		/// <summary>
		/// Gets the type of the control
		/// </summary>
		public ControlType Control {
			get {
				return (ControlType)this.Data[4];
			}
		}

		/// <summary>
		/// Gets the control's value
		/// </summary>
		public int Value {
			get {
				return this.Data[5];
			}
		}

		/// <summary>
		/// Initializes a new instance of the ControlChangeMessage class
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public ControlChangeMessage(byte[] Data, int TotalTime)
			: base(Data, TotalTime) {

		}
	}
}
