using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public struct StyleTime {
		private int bar;
		private int beat;
		private int cpt;
		private int rawTime;

		public int RawTime {
			get { return rawTime; }
		}
		
		public int Bar {
			get { return bar; }
		}

		public int Beat {
			get { return beat; }
		}

		public int ClockPulseTime {
			get {
				return (int)Math.Round(this.cpt * 1.6f, 0);
			}
		}

		public StyleTime(int RawTime, int Bar, int Beat, int CPT) {
			this.rawTime = RawTime;
			this.bar = Bar;
			this.beat = Beat;
			this.cpt = CPT;
		}

		public override string ToString() {
			return this.bar + ":" + this.beat + ":" + this.ClockPulseTime + " (" + this.rawTime + ")";
		}

		public static StyleTime FromStyleMessage(MidiMessage Message, RolandStyle Style) {
			return StyleTime.FromStyleTimestamp(Message.TotalTime, Style);
		}

		public static StyleTime FromStyleTimestamp(int TotalTime, RolandStyle Style) {
			return new StyleTime(
				TotalTime,
				TotalTime / 120 / Style.Measure.Denominator + 1,
				(TotalTime % (120 * Style.Measure.Numerator)) / 120 + 1,
				TotalTime % 120
			);
		}
	}
}
