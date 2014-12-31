using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public class RolandStyleData {
		private string name;

		/// <summary>
		/// The style's name with the length of maximum 16 characters.
		/// </summary>
		public string Name {
			get { return name; }
			set {
				if (value.Length > 16)
					throw new ArgumentOutOfRangeException("Name", "The style's name must be less than 16 characters");

				name = value;
			}
		}

		private int tempo;

		/// <summary>
		/// The style's tempo in BPM. Must be between 35 and 255.
		/// </summary>
		public int Tempo {
			get { return tempo; }
			set {
				if (value < 35 || value > 255)
					throw new ArgumentOutOfRangeException("Tempo", "The tempo must be between 35 and 255");

				tempo = value;
			}
		}

		private Measure measure;

		/// <summary>
		/// The style's measure.
		/// </summary>
		public Measure Measure {
			get { return measure; }
			set { measure = value; }
		}

		/// <summary>
		/// The contents of the style
		/// </summary>
		public List<StyleEntry> data;

		/// <summary>
		/// Creates an empty instance of this class.
		/// </summary>
		/// <param name="Name">The style's name. Must be less than 16 characters</param>
		/// <param name="Tempo">The tempo in BPM</param>
		/// <param name="Measure">The style's measure</param>
		public RolandStyleData(string Name, int Tempo, Measure Measure) {
			this.Name = Name;
			this.Tempo = Tempo;
			this.Measure = Measure;

			this.data = new List<StyleEntry>();
		}

		/// <summary>
		/// Creates an instance of this class and imports the style data from an existing source.
		/// </summary>
		/// <param name="Reader">A 2 variation Roland style reader class instance</param>
		/// <returns>The style data instance</returns>
		public static RolandStyleData CreateFromReader(IStyleReader_2variation Reader) {
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
