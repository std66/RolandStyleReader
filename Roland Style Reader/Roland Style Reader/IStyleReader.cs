using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This interface represents a style reader for 2 variation styles.
	/// </summary>
	public interface IStyleReader_2variation {
		/// <summary>
		/// Gets the style's name
		/// </summary>
		string Name { get;}

		/// <summary>
		/// Gets the style's tempo in BPM
		/// </summary>
		int Tempo { get; }

		/// <summary>
		/// Gets the style's measure
		/// </summary>
		Measure Measure { get; }

		/// <summary>
		/// Gets the style's signature
		/// </summary>
		StyleSignature Signature { get; }

		/// <summary>
		/// Gets the events from the given style part
		/// </summary>
		/// <param name="IsBasic">True if Basic, False if Advanced</param>
		/// <param name="Part">Part of the style</param>
		/// <param name="Instr">Track of the part</param>
		/// <param name="CType">Chord type</param>
		/// <returns>A list of the events</returns>
		IEnumerable<MidiMessage> this[bool IsBasic, StylePart Part, Instrument Instr, ChordType CType] { get; }
	}
}
