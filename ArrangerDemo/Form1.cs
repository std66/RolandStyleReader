using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArrangerDemo {
	public partial class frmMain : Form {
		private PlaybackManager Playback;
		private bool IsStyleLoaded = false;

		public frmMain() {
			InitializeComponent();
		}

		private void btnOpenStyle_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Roland style (*.STL) | *.stl";

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				this.Playback = new PlaybackManager(dlg.FileName);

				lTempo.Text = String.Format("{0} BPM", this.Playback.Tempo);
				lStyleName.Text = this.Playback.StyleName;
				lMeasure.Text = this.Playback.Measure.ToString();

				this.EnableUI();
				this.IsStyleLoaded = true;
			}
		}

		private void EnableUI() {
			if (this.IsStyleLoaded)
				return;

			this.btnAdvanced.Enabled = true;
			this.btnBasic.Enabled = true;
			this.btnPartEnding.Enabled = true;
			this.btnPartFill.Enabled = true;
			this.btnPartIntro.Enabled = true;
			this.btnPartOriginal.Enabled = true;
			this.btnPartVariation.Enabled = true;
			this.btnPlaybackStart.Enabled = true;
			this.btnPlaybackStop.Enabled = true;

			this.btnPartIntro.Click += (o, e) => this.Playback.CurrentPart = TomiSoft.RolandStyleReader.StylePart.Intro;
			this.btnPartEnding.Click += (o, e) => this.Playback.CurrentPart = TomiSoft.RolandStyleReader.StylePart.Ending;
			this.btnPartOriginal.Click += (o, e) => this.Playback.CurrentPart = TomiSoft.RolandStyleReader.StylePart.Original;
			this.btnPartVariation.Click += (o, e) => this.Playback.CurrentPart = TomiSoft.RolandStyleReader.StylePart.Variation;
			this.btnPartFill.Click += (o, e) => this.Playback.Fill();
			this.btnBasic.Click += (o, e) => this.Playback.Arrangement = TomiSoft.RolandStyleReader.Arrangement.Basic;
			this.btnAdvanced.Click += (o, e) => this.Playback.Arrangement = TomiSoft.RolandStyleReader.Arrangement.Advanced;
			this.btnPlaybackStart.Click += (o, e) => this.Playback.Start();
			this.btnPlaybackStop.Click += (o, e) => this.Playback.Stop();
		}
	}
}
