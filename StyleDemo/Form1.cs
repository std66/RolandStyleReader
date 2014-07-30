using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TomiSoft.RolandStyleReader;
using Midi;

namespace StyleDemo {
	public partial class Form1 : Form {
		private RolandStyle style;
		private bool IsBasic = true;
		private StylePart Part = StylePart.Intro;
		private TomiSoft.RolandStyleReader.Instrument instr = TomiSoft.RolandStyleReader.Instrument.Drum;
		private ChordType ctype = ChordType.Major;

		public Form1() {
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Roland style (*.stl)|*.stl";

			if (dlg.ShowDialog() == DialogResult.OK) {
				#region Do some WinForms shit
				this.btnPlay.Enabled = true;
				this.comboBox1.Enabled = true;
				this.comboBox2.Enabled = true;
				this.comboBox3.Enabled = true;
				this.comboBox4.Enabled = true;
				//this.comboBox1.SelectedIndex = 0;
				//this.comboBox2.SelectedIndex = 0;
				//this.comboBox3.SelectedIndex = 0;
				//this.comboBox4.SelectedIndex = 0;
				#endregion

				this.style = new RolandStyle(dlg.FileName);

				this.lStyleName.Text = this.style.Name;
				this.lSignature.Text = this.style.Signature.ToString() + " formátumú stílus";
				this.lMetronomeMark.Text = this.style.Measure.ToString();
				this.lTempo.Text = this.style.Tempo + " BPM";

				this.pbBeat.Maximum = this.style.Measure.Numerator;

				this.RenderMessages();
			}
		}

		private void RenderMessages() {
			lwMessages.Items.Clear();

			try {
				foreach (MidiMessage msg in this.style[this.IsBasic, this.Part, this.instr, this.ctype]) {
					ListViewItem lwi = new ListViewItem(StyleTime.FromStyleMessage(msg, this.style).ToString());
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
					"A hang számának 0 és 127 közé kell esnie",
					"Hiba",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			catch (NoteVelocityOutOfRangeException) {
				MessageBox.Show(
					"A hang dinamikájának 0 és 127 közé kell esnie",
					"Hiba",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			catch (Exception) {
				MessageBox.Show(
					"A kért rész nem létezik a fájlban",
					"Hiba",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private Midi.Message ToMessage(MidiMessage m, OutputDevice device, Clock clock, out float time) {
			float a = (this.style.Tempo * 120) / 60000f;
			
			TomiSoft.RolandStyleReader.NoteMessage msg = (TomiSoft.RolandStyleReader.NoteMessage)m;
			time = msg.TotalTime / 120f;

			return new NoteOnOffMessage(
				device,
				Channel.Channel10,
				(Pitch)((msg.Note < 128) ? msg.Note : 1),
				msg.Velocity,
				msg.TotalTime / 120f,
				clock,
				msg.Length
			);
			
		}

		private void btnPlay_Click(object sender, EventArgs e) {
			OutputDevice dev = OutputDevice.InstalledDevices[0];
			dev.Open();
			Clock clock = new Clock(this.style.Tempo);

			dev.SendProgramChange(Channel.Channel10, Midi.Instrument.SteelDrums);

			float LastMsgTime = 0;

			try {
				foreach (var CurrentMessage in this.style[this.IsBasic, this.Part, this.instr, this.ctype]) {
					if (CurrentMessage.MessageType == MidiMessageType.Note) {
						clock.Schedule(this.ToMessage(CurrentMessage, dev, clock, out LastMsgTime));
					}
				}
			}
			catch (Exception) {
				MessageBox.Show(
					"A kért rész nem létezik a fájlban",
					"Hiba",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return;
			}

			clock.Start();

			while (clock.Time <= LastMsgTime) {
				System.Threading.Thread.Sleep(50);
				StyleTime t = StyleTime.FromStyleTimestamp((int)(clock.Time * 120), this.style);
				label1.Text = t.ToString();
				pbBeat.Value = t.Beat;
				Application.DoEvents();
			}

			clock.Stop();
			dev.Close();

			pbBeat.Value = 0;
		}

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
	}
}
