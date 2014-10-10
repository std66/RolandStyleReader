using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This class can parse a Roland style file
	/// </summary>
	public class RolandStyleReader {
		private StyleSignature _signature;

		/// <summary>
		/// Gets the style's signature (G8 or EV)
		/// </summary>
		public StyleSignature Signature {
			get { return _signature; }
		}

		private string _name;

		/// <summary>
		/// Gets the style's name
		/// </summary>
		public string Name {
			get { return _name; }
		}

		private int _tempo;

		/// <summary>
		/// Gets the style's tempo in BPM
		/// </summary>
		public int Tempo {
			get { return _tempo; }
		}

		private Measure _measure;

		/// <summary>
		/// Gets the style's metronome mark
		/// </summary>
		public Measure Measure {
			get { return _measure; }
		}

		/// <summary>
		/// Gets the events from the given style part
		/// </summary>
		/// <param name="IsBasic">True if Basic, False if Advanced</param>
		/// <param name="Part">Part of the style</param>
		/// <param name="Instr">Track of the part</param>
		/// <param name="CType">Chord type</param>
		/// <returns>A list of the events</returns>
		public IEnumerable<MidiMessage> this[bool IsBasic, StylePart Part, Instrument Instr, ChordType CType] {
			get {
				Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> Source =
					IsBasic ? this.BasicAddresses : this.AdvancedAddresses;

				InstrumentAddress addr = Source[Instr][Part];

				return this.GetMidiMessages(addr, CType);
			}
		}
		
		private byte[] FileContents;

		/// <summary>
		/// Addresses of the style's Basic part
		/// </summary>
		private Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> BasicAddresses;

		/// <summary>
		/// Addresses of the style's Advanced part
		/// </summary>
		private Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> AdvancedAddresses;

		/// <summary>
		/// Loads the given Roland style file
		/// </summary>
		/// <param name="Filename">The path to the file</param>
		public RolandStyleReader(string Filename) {
			this.FileContents = File.ReadAllBytes(Filename);

			this.ReadFile();
		}

		/// <summary>
		/// Loads the Roland style from the given stream
		/// </summary>
		/// <param name="File">A stream that contains the file</param>
		public RolandStyleReader(Stream File) {
			using (BinaryReader reader = new BinaryReader(File)) {
				this.FileContents = reader.ReadBytes((int)File.Length);
			}

			this.ReadFile();
		}

		/// <summary>
		/// Reads up the whole file
		/// </summary>
		private void ReadFile() {
			this.GetStyleSignature();
			this.GetStyleName();
			this.GetTempo();
			this.GetMeasure();

			this.BasicAddresses = new Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>>();
			this.AdvancedAddresses = new Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>>();
			for (int i = 0; i < 8; i++) {
				this.BasicAddresses.Add((Instrument)i, new Dictionary<StylePart, InstrumentAddress>());
				this.AdvancedAddresses.Add((Instrument)i, new Dictionary<StylePart, InstrumentAddress>());
			}

			this.ReadAddresses();
		}

		/// <summary>
		/// Reads the style's signature (0x0 - 0x1)
		/// </summary>
		private void GetStyleSignature() {
			string SignatureText = Encoding.ASCII.GetString(this.FileContents, 0x0, 2);

			switch (SignatureText) {
				case "G8": this._signature = StyleSignature.G8; break;
				case "EV": this._signature = StyleSignature.EV; break;
				default: throw new Exception("Nem támogatott fájlformátum");
			}
		}

		/// <summary>
		/// Reads the style's name (0x2 - 0x11)
		/// </summary>
		private void GetStyleName() {
			this._name = Encoding.ASCII.GetString(this.FileContents, 0x2, 16);
		}

		/// <summary>
		/// Reads the style's tempo (0x14 - 0x15)
		/// </summary>
		private void GetTempo() {
			int DivBy = System.Net.IPAddress.HostToNetworkOrder(BitConverter.ToInt16(this.FileContents, 0x14));
			this._tempo = 500000 / DivBy;
		}

		/// <summary>
		/// Reads the metronome mark of the style.
		/// 
		/// Numerator: 0x18
		/// Denominator: 0x19 (2^value)
		/// </summary>
		private void GetMeasure() {
			int BeatsInMeasure = (int)this.FileContents[0x18];
			int BeatLength = (int)Math.Pow(2, this.FileContents[0x19]);

			this._measure = new Measure(BeatsInMeasure, BeatLength);
		}

		/// <summary>
		/// Reads the addresses from the file (0x3A - 0x639)
		/// </summary>
		private void ReadAddresses() {
			Instrument CurrentInstrument = 0;
			for (int StartOffset = 0x3A; StartOffset <= 0x639; StartOffset += 192, CurrentInstrument++) {
				this.ReadInstrumentAddress(StartOffset, CurrentInstrument, BasicAddresses);
				this.ReadInstrumentAddress(StartOffset + 96, CurrentInstrument, AdvancedAddresses);
			}
		}

		private void ReadInstrumentAddress(int InstrStartOffset, Instrument Instr, Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> TargetDict) {
			for (int CurrentPart = 0; CurrentPart < 8; CurrentPart++) {
				int PartStart = CurrentPart * 12;

				int Major = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart);
				int Minor = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart + 4);
				int Seventh = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart + 8);

				TargetDict[Instr].Add(
					(StylePart)CurrentPart,
					new InstrumentAddress(Major, Minor, Seventh)
				);
			}
		}

		private IEnumerable<MidiMessage> GetMidiMessages(InstrumentAddress Address, ChordType CType) {
			int Addr;

			if (Address.IsAvailable(CType) && Address[CType] < this.FileContents.Length) {
				Addr = Address[CType];
			}
			else
				yield break;

			int Time = 0;
			for (int Offset = Addr; true; Offset += 6) {
				if (this.FileContents[Offset + 1] == 0x8F)
					yield break;

				byte[] Data = new byte[6];
				Array.Copy(
					this.FileContents,
					Offset,
					Data,
					0,
					6
				);

				MidiMessage msg = MidiMessage.CreateFromData(Data, Time);
				Time += this.FileContents[Offset];				
				
				yield return msg;
			}
		}
	}
}
