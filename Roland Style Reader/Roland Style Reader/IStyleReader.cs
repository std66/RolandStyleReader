using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	public interface IStyleReader_2variation {
		string Name { get;}
		int Tempo { get; }
		Measure Measure { get; }
		StyleSignature Signature { get; }

		IEnumerable<MidiMessage> this[bool IsBasic, StylePart Part, Instrument Instr, ChordType CType] { get; }
	}
}
