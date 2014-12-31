using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This struct gives more information about a timestamp that is represented in ticks.
	/// To get more information about the timestamp attached with a MidiMessage object, use
	/// the FromStyleMessage static method, or if you have the timestamp in ticks, use the
	/// FromStyleTimestamp static method.
	/// </summary>
	public struct StyleTime {
		private int bar;
		private int beat;
		private int cpt;
		private int rawTime;

		/// <summary>
		/// Gets the timestamp in ticks
		/// </summary>
		public int RawTime {
			get { return rawTime; }
		}
		
		/// <summary>
		/// Gets the bar position of the timestamp
		/// </summary>
		public int Bar {
			get { return bar; }
		}

		/// <summary>
		/// Gets the beat position in a bar of the timestamp
		/// </summary>
		public int Beat {
			get { return beat; }
		}

		/// <summary>
		/// Gets the Clock Pulse Time (CPT) position in a beat of the timestamp
		/// </summary>
		public int ClockPulseTime {
			get {
				return (int)Math.Round(this.cpt * 1.6f, 0);
			}
		}

		/// <summary>
		/// Initializes a new instance of the StyleTime struct
		/// </summary>
		/// <param name="RawTime">The timestamp in ticks</param>
		/// <param name="Bar">The bar value of the timestamp</param>
		/// <param name="Beat">The beat value of the timestamp</param>
		/// <param name="CPT">The Clock Pulse Time (CPT) value of the timestamp</param>
		public StyleTime(int RawTime, int Bar, int Beat, int CPT) {
			this.rawTime = RawTime;
			this.bar = Bar;
			this.beat = Beat;
			this.cpt = CPT;
		}

		/// <summary>
		/// Gets the string representation of an instance of the StyleTime struct
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return this.bar + ":" + this.beat + ":" + this.ClockPulseTime.ToString("D3");
		}

		/// <summary>
		/// Gets a StyleTime struct using a MidiMessage object.
		/// </summary>
		/// <param name="Message">An instance of the MidiMessage class</param>
		/// <param name="Style">An instance of the RolandStyle class</param>
		/// <returns>An instance of the StyleTime struct</returns>
		public static StyleTime FromStyleMessage(MidiMessage Message, Reader_STL_2var Style) {
			return StyleTime.FromStyleTimestamp(Message.TotalTime, Style);
		}

		public static StyleTime FromStyleMessage(MidiMessage Message, RolandStyleData StyleData) {
			return StyleTime.FromStyleTimestamp(Message.TotalTime, StyleData.Measure);
		}

		/// <summary>
		/// Gets a StyleTime struct using a timestamp that is represented in ticks
		/// </summary>
		/// <param name="TotalTime">The timestamp in ticks</param>
		/// <param name="Style">An instance of the RolandStyle class</param>
		/// <returns>An instance of the StyleTime struct</returns>
		public static StyleTime FromStyleTimestamp(int TotalTime, Reader_STL_2var Style) {
			return StyleTime.FromStyleTimestamp(TotalTime, Style.Measure);
		}

		/// <summary>
		/// Gets a StyleTime struct using a timestamp that is represented in ticks
		/// </summary>
		/// <param name="TotalTime">The timestamp in ticks</param>
		/// <param name="Measure">An instance of the Measure struct that represents the beat informations of the style</param>
		/// <returns>An instance of the StyleTime struct</returns>
		public static StyleTime FromStyleTimestamp(int TotalTime, Measure Measure) {
			return new StyleTime(
				TotalTime,
				TotalTime / 120 / Measure.Numerator + 1,
				(TotalTime % (120 * Measure.Numerator)) / 120 + 1,
				TotalTime % 120
			);
		}
	}
}
