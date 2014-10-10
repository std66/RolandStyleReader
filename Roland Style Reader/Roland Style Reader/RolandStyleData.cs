using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class RolandStyleData {
		private string name;

		public string Name {
			get { return name; }
			set { name = value; }
		}

		private int tempo;

		public int Tempo {
			get { return tempo; }
			set { tempo = value; }
		}

		private Measure measure;

		public Measure Measure {
			get { return measure; }
			set { measure = value; }
		}

		public List<StyleEntry> data;

		public RolandStyleData(string Name, int Tempo, Measure Measure) {
			this.name = Name;
			this.tempo = Tempo;
			this.measure = Measure;

			this.data = new List<StyleEntry>();
		}

		public static RolandStyleData CreateFromReader(RolandStyleReader Reader) {
			RolandStyleData Result = new RolandStyleData(Reader.Name, Reader.Tempo, Reader.Measure);

			Result.data.AddRange(
				from Arrange in new Arrangement[] { Arrangement.Basic, Arrangement.Advanced }.Cast<Arrangement>()
				from Part    in Enum.GetValues(typeof(StylePart)).Cast<StylePart>()
				from Instr   in Enum.GetValues(typeof(Instrument)).Cast<Instrument>()
				from CType   in Enum.GetValues(typeof(ChordType)).Cast<ChordType>()
				from Message in Reader[Arrange == Arrangement.Basic, Part, Instr, CType]

				select new StyleEntry(
					Arrange,
					Part,
					Instr,
					CType,
					Message
				)
			);

			return Result;
		}
	}
}
