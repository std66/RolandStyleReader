using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using TomiSoft.RolandStyleReader;
using Midi;

namespace StyleDemo {
	public partial class frmMainWindow : Form {
		private RolandStyleData data;

		private bool IsBasic = true;
		private StylePart Part = StylePart.Intro;
		private TomiSoft.RolandStyleReader.Instrument instr = TomiSoft.RolandStyleReader.Instrument.Drum;
		private ChordType ctype = ChordType.Major;
		OutputDevice dev = OutputDevice.InstalledDevices[0];

		public frmMainWindow() {
			InitializeComponent();

			this.comboBox1.SelectedIndex = 0;
			this.comboBox2.SelectedIndex = 0;
			this.comboBox3.SelectedIndex = 0;
			this.comboBox4.SelectedIndex = 0;

			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Roland style (*.stl, *.sth)|*.stl;*.sth";

			if (dlg.ShowDialog() == DialogResult.OK) {
				#region Do some WinForms shit
				this.btnPlay.Enabled = true;
				this.comboBox1.Enabled = true;
				this.comboBox2.Enabled = true;
				this.comboBox3.Enabled = true;
				this.comboBox4.Enabled = true;
				#endregion

				IStyleReader_2variation Reader;
				string Ext = Path.GetExtension(dlg.FileName);

				if (Ext.ToLower().Contains("stl"))
					Reader = new Reader_STL_2var(dlg.FileName);
				else
					Reader = new Reader_STH(dlg.FileName);

				this.data = RolandStyleData.CreateFromReader(Reader);

				this.lStyleName.Text = this.data.Name;
				this.lSignature.Text = Reader.Signature.ToString() + " format style";
				this.lMetronomeMark.Text = this.data.Measure.ToString();
				this.lTempo.Text = this.data.Tempo + " BPM";

				this.pbBeat.Maximum = this.data.Measure.Numerator;

				this.RenderMessages();
			}
		}

		private void RenderMessages() {
			lwMessages.Items.Clear();

			try {
				var Messages = from Current in this.data.data
							   where
								Current.Arrangement == (this.IsBasic ? Arrangement.Basic : Arrangement.Advanced) &&
								Current.Part == this.Part &&
								Current.Instrument == this.instr &&
								Current.ChordType == this.ctype
							   select Current;

				foreach (StyleEntry Entry in Messages) {
					var msg = Entry.Message;

					ListViewItem lwi = new ListViewItem(StyleTime.FromStyleMessage(msg, this.data).ToString());
					lwi.SubItems.Add(msg.MessageType.ToString());
					lwi.SubItems.Add(msg.Channel.ToString());

					switch (msg.MessageType) {
						case MidiMessageType.ControlChange:
							TomiSoft.RolandStyleReader.ControlChangeMessage ccm = (TomiSoft.RolandStyleReader.ControlChangeMessage)msg;
							lwi.SubItems.Add(ccm.Control.ToString());
							lwi.SubItems.Add(ccm.Value.ToString());
							break;

						case MidiMessageType.ProgramChange:
							TomiSoft.RolandStyleReader.ProgramChangeMessage pcm = (TomiSoft.RolandStyleReader.ProgramChangeMessage)msg;
							lwi.SubItems.Add(pcm.MSB.ToString());
							lwi.SubItems.Add(pcm.LSB.ToString());
							lwi.SubItems.Add(pcm.Program.ToString());
							break;

						case MidiMessageType.Note:
							TomiSoft.RolandStyleReader.NoteMessage nm = (TomiSoft.RolandStyleReader.NoteMessage)msg;
							lwi.SubItems.Add(nm.Name + " " + nm.Octave);
							lwi.SubItems.Add(nm.Velocity.ToString());
							lwi.SubItems.Add(nm.Length.ToString());
							break;
					}

					lwMessages.Items.Add(lwi);
				}
			}
			catch (NoteValueOutOfRangeException) {
				MessageBox.Show(
					"Note number must be in range 0-127",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			catch (NoteVelocityOutOfRangeException) {
				MessageBox.Show(
					"Note velocity must be in range 0-127",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			catch (Exception) {
				MessageBox.Show(
					"The style does not contain information for the selected part",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private Midi.Message ToMessage(MidiMessage m, OutputDevice device, Clock clock, out float time) {
			TomiSoft.RolandStyleReader.NoteMessage msg = (TomiSoft.RolandStyleReader.NoteMessage)m;
			time = msg.TotalTime / 120f;

			Channel ch;
			switch (this.instr) {
				case TomiSoft.RolandStyleReader.Instrument.Drum:
					ch = Channel.Channel10;
					break;

				case TomiSoft.RolandStyleReader.Instrument.Bass:
					ch = Channel.Channel2;
					break;

				default:
					ch = Channel.Channel4;
					break;
			}

			return new NoteOnOffMessage(
				device,
				ch,
				(Pitch)((msg.Note < 128) ? msg.Note : 1),
				msg.Velocity,
				msg.TotalTime / 120f,
				clock,
				msg.Length
			);
			
		}

		private void btnPlay_Click(object sender, EventArgs e) {
			dev.Open();
			Clock clock = new Clock(this.data.Tempo);

			bool ProgramSent = false;
			if (this.instr == TomiSoft.RolandStyleReader.Instrument.Drum) {
				dev.SendProgramChange(Channel.Channel10, Midi.Instrument.SteelDrums);
				ProgramSent = true;
			}
			else if (this.instr == TomiSoft.RolandStyleReader.Instrument.Bass) {
				dev.SendProgramChange(Channel.Channel2, Midi.Instrument.AcousticBass);
				ProgramSent = true;
			}

			float LastMsgTime = 0;
			int LastTime = 0;

			try {
				var Messages = from Current in this.data.data
							   where
								Current.Arrangement == (this.IsBasic ? Arrangement.Basic : Arrangement.Advanced) &&
								Current.Part == this.Part &&
								Current.Instrument == this.instr &&
								Current.ChordType == this.ctype
							   select Current;

				foreach (var Entry in Messages) {
					if (Entry.Message.MessageType == MidiMessageType.Note) {
						clock.Schedule(this.ToMessage(Entry.Message, dev, clock, out LastMsgTime));
						LastTime = Entry.Message.TotalTime + ((TomiSoft.RolandStyleReader.NoteMessage)Entry.Message).Length;
					}

					else if (Entry.Message.MessageType == MidiMessageType.ProgramChange) {
						if (!ProgramSent) {
							TomiSoft.RolandStyleReader.ProgramChangeMessage msg = (TomiSoft.RolandStyleReader.ProgramChangeMessage)Entry.Message;
							dev.SendProgramChange(Channel.Channel4, (Midi.Instrument)msg.Program);
						}
					}
				}
			}
			catch (NoteValueOutOfRangeException) {
				MessageBox.Show(
					"Note number must be in range 0-127",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}
			catch (NoteVelocityOutOfRangeException) {
				MessageBox.Show(
					"Note velocity must be in range 0-127",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}
			catch (Exception) {
				MessageBox.Show(
					"The style does not contain information for the selected part",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return;
			}

			pbPlaybackPosition.Maximum = LastTime;

			clock.Start();

			while (clock.Time <= LastMsgTime) {
				System.Threading.Thread.Sleep(50);

				StyleTime t = StyleTime.FromStyleTimestamp((int)(clock.Time * 120), this.data.Measure);
				lFriendlyTime.Text = String.Format("{0}.{1}.{2}", t.Bar, t.Beat, t.ClockPulseTime);
				lTotalTime.Text = t.RawTime.ToString();

				pbBeat.Value = t.Beat;
				pbPlaybackPosition.Value = (t.RawTime > pbPlaybackPosition.Maximum) ? pbPlaybackPosition.Maximum : t.RawTime;
				Application.DoEvents();
			}

			clock.Stop();
			dev.Close();

			pbBeat.Value = 0;
			pbPlaybackPosition.Value = 0;
			lFriendlyTime.Text = "0.0.0";
			lTotalTime.Text = "0";
		}

		#region Style Part Select Comboboxes
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			this.IsBasic = comboBox2.SelectedIndex == 0;
			this.RenderMessages();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			StylePart[] parts = new StylePart[] {
				StylePart.Intro,
				StylePart.Original,
				StylePart.Variation,
				StylePart.Variation2,
				StylePart.FillToVariation,
				StylePart.FillToVariation2,
				StylePart.FillToOriginal,
				StylePart.Ending
			};

			this.Part = parts[comboBox1.SelectedIndex];

			this.RenderMessages();
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			TomiSoft.RolandStyleReader.Instrument[] i = new TomiSoft.RolandStyleReader.Instrument[] {
				TomiSoft.RolandStyleReader.Instrument.Drum,
				TomiSoft.RolandStyleReader.Instrument.Bass,
				TomiSoft.RolandStyleReader.Instrument.Acc1,
				TomiSoft.RolandStyleReader.Instrument.Acc2,
				TomiSoft.RolandStyleReader.Instrument.Acc3,
				TomiSoft.RolandStyleReader.Instrument.Acc4,
				TomiSoft.RolandStyleReader.Instrument.Acc5,
				TomiSoft.RolandStyleReader.Instrument.Acc6
			};

			this.instr = i[comboBox3.SelectedIndex];

			this.RenderMessages();
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
			ChordType[] t = new ChordType[] {
				ChordType.Major,
				ChordType.Minor,
				ChordType.Seventh
			};

			this.ctype = t[comboBox4.SelectedIndex];

			this.RenderMessages();
		}
		#endregion

		private void mIDISettingsToolStripMenuItem_Click(object sender, EventArgs e) {
			OutputDeviceSelectDialog dlg = new OutputDeviceSelectDialog();

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				this.dev = dlg.Device;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "XML document|*.xml";
			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				XmlSerializer xml = new XmlSerializer(this.data.GetType());
				XmlWriter wrt = XmlWriter.Create(dlg.FileName);
				xml.Serialize(wrt, this.data);
			}
		}
	}
}
