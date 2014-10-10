using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// An abstract class that is the base for all kind of message classes.
	/// </summary>
	public abstract class MidiMessage {
		/// <summary>
		/// Gets the channel of the message. For G-70-like styles, this value is 0x0.
		/// 
		/// <para>0x11 - Bass</para>
		/// <para>0x19 - Drum</para>
		/// <para>0x10 - Acc1</para>
		/// <para>0x12 - Acc2</para>
		/// <para>0x14 - Acc3</para>
		/// <para>0x16 - Acc4</para>
		/// <para>0x18 - Acc5</para>
		/// <para>0x20 - Acc6</para>
		/// </summary>
		public int Channel {
			get {
				return this.Data[2];
			}
		}

		/// <summary>
		/// Gets the type of the message
		/// </summary>
		public MidiMessageType MessageType {
			get {
				return MidiMessage.GetMessageType(this.Data[1]);
			}
		}

		/// <summary>
		/// Gets the delta time in ticks of the message.
		/// </summary>
		public int DeltaTime {
			get {
				return this.Data[0];
			}
		}

		private int totalTime;

		/// <summary>
		/// Gets the timestamp of the message in ticks. Use StyleTime.FromStyleMessage to get more information.
		/// </summary>
		public int TotalTime {
			get { return totalTime; }
		}

		/// <summary>
		/// This field stores the binary coded message data
		/// </summary>
		protected byte[] Data;

		/// <summary>
		/// Initializes a new instance of the MidiMessage class.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		public MidiMessage(byte[] Data, int TotalTime) {
			this.Data = Data;
			this.totalTime = TotalTime;
		}

		/// <summary>
		/// Constructs the type-specific message object using the given data. Use MessageType property
		/// to determine the type of the message.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <param name="TotalTime">The timestamp of the message in ticks</param>
		/// <returns>An object derived from MidiMessage class that represents the message</returns>
		public static MidiMessage CreateFromData(byte[] Data, int TotalTime) {
			MidiMessageType type = MidiMessage.GetMessageType(Data[1]);
			Type Class = Type.GetType("TomiSoft.RolandStyleReader." + type.ToString() + "Message", true);

			try {
				return (MidiMessage)Class.GetConstructor(
					new Type[] { 
						typeof(byte[]),
						typeof(int)
					}
				).Invoke(new object[] { Data, TotalTime });
			}
			catch (TargetInvocationException e) {
				throw e.InnerException;
			}
		}

		/// <summary>
		/// Determines the message type from the given data.
		/// </summary>
		/// <param name="Data">The binary coded data from the style file</param>
		/// <returns>The type of the message</returns>
		protected static MidiMessageType GetMessageType(int Data) {
			if (Enum.IsDefined(typeof(MidiMessageType), Data)) {
				return (MidiMessageType) Data;
			}

			if (Data >= 0 && Data <= 127)
				return MidiMessageType.Note;

			return MidiMessageType.Unknown;
			//throw new UnsupportedMessageException(Data);
		}

		/// <summary>
		/// Gets the string representation of the MidiMessage object.
		/// </summary>
		/// <returns>The string representation of this instance</returns>
		public override string ToString() {
			return String.Format("{0}:\t{1}", this.TotalTime, this.MessageType.ToString());
		}
	}
}
