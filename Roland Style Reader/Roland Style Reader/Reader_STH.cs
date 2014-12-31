using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TomiSoft.RolandStyleReader {
	public class Reader_STH : IStyleReader_2variation {
		private string name;
		public string Name {
			get { return name; }
		}

		private int tempo;
		public int Tempo {
			get { return tempo; }
		}

		private Measure measure;
		public Measure Measure {
			get { return measure; }
		}

		public StyleSignature Signature {
			get {
				return StyleSignature.STH;
			}
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

		/// <summary>
		/// Addresses of the style's Basic part
		/// </summary>
		private Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> BasicAddresses;

		/// <summary>
		/// Addresses of the style's Advanced part
		/// </summary>
		private Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> AdvancedAddresses;

		private byte[] FileContents;

		public Reader_STH(string Filename) {
			this.FileContents = File.ReadAllBytes(Filename);

			this.ReadFile();
		}

		public Reader_STH(Stream File) {
			using (BinaryReader reader = new BinaryReader(File)) {
				this.FileContents = reader.ReadBytes((int)File.Length);
			}

			this.ReadFile();
		}

		private void ReadFile() {
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
		/// Reads the style's name
		/// </summary>
		private void GetStyleName() {
			this.name = Encoding.ASCII.GetString(this.FileContents, 0x2, 16);
		}

		/// <summary>
		/// Reads the style's tempo
		/// </summary>
		private void GetTempo() {
			int DivBy = System.Net.IPAddress.HostToNetworkOrder(BitConverter.ToInt16(this.FileContents, 0x684));
			this.tempo = 500000 / DivBy;
		}

		/// <summary>
		/// Reads the metronome mark of the style.
		/// </summary>
		private void GetMeasure() {
			int BeatsInMeasure = (int)this.FileContents[0x688];
			int BeatLength = (int)Math.Pow(2, this.FileContents[0x689]);

			this.measure = new Measure(BeatsInMeasure, BeatLength);
		}

		private void ReadAddresses() {
			Instrument CurrentInstrument = 0;
			for (int StartOffset = 0x6AA; StartOffset <= 0xCA9; StartOffset += 192, CurrentInstrument++) {
				Debug.WriteLine("\nBasic:");
				this.ReadInstrumentAddress(StartOffset, CurrentInstrument, BasicAddresses);
				Debug.WriteLine("Advanced:");
				this.ReadInstrumentAddress(StartOffset + 96, CurrentInstrument, AdvancedAddresses);
			}
		}

		private void ReadInstrumentAddress(int InstrStartOffset, Instrument Instr, Dictionary<Instrument, Dictionary<StylePart, InstrumentAddress>> TargetDict) {
			for (int CurrentPart = 0; CurrentPart < 8; CurrentPart++) {
				int PartStart = CurrentPart * 12;

				int Major = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart + 2) / 11;
				int Minor = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart + 6) / 11;
				int Seventh = BitConverter.ToInt16(this.FileContents, InstrStartOffset + PartStart + 10) / 11;

				Debug.WriteLine("Offset: {0}, Instrument: {1}, Maj: {2}, Min: {3}, 7th: {4}", new object[] {
					InstrStartOffset.ToString("X"), Instr, Major.ToString("X"), Minor.ToString("X"), Seventh.ToString("X")
				});

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

			Debug.WriteLine("Address: {0} Chord: {1}", new object[] {
				Address, CType
			});

			int Time = 0;
			for (int Offset = Addr - 1; true; Offset += 6) {
				if (this.FileContents[Offset + 1] == 0x8F) {
					Debug.WriteLine("Break\n");
					yield break;
				}

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

				Debug.WriteLine("Offset: {0}, Message: {1}", new object[] {
					Offset.ToString("X"),
					msg.MessageType.ToString()
				});

				yield return msg;
			}
		}
	}
}
