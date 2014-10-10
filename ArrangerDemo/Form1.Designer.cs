namespace ArrangerDemo {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBasic = new System.Windows.Forms.Button();
			this.btnAdvanced = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPartIntro = new System.Windows.Forms.Button();
			this.btnPartEnding = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnPartVariation = new System.Windows.Forms.Button();
			this.btnPartOriginal = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnPartFill = new System.Windows.Forms.Button();
			this.cbAutoFill = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnPlaybackStop = new System.Windows.Forms.Button();
			this.btnPlaybackStart = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.lMeasure = new System.Windows.Forms.Label();
			this.btnOpenStyle = new System.Windows.Forms.Button();
			this.lStyleName = new System.Windows.Forms.Label();
			this.lTempo = new System.Windows.Forms.Label();
			this.pbBeatMeter = new ArrangerDemo.CustomProgressBar();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnAdvanced);
			this.groupBox1.Controls.Add(this.btnBasic);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 78);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Arrangement";
			// 
			// btnBasic
			// 
			this.btnBasic.Enabled = false;
			this.btnBasic.Location = new System.Drawing.Point(6, 19);
			this.btnBasic.Name = "btnBasic";
			this.btnBasic.Size = new System.Drawing.Size(75, 52);
			this.btnBasic.TabIndex = 1;
			this.btnBasic.Text = "Basic";
			this.btnBasic.UseVisualStyleBackColor = true;
			// 
			// btnAdvanced
			// 
			this.btnAdvanced.Enabled = false;
			this.btnAdvanced.Location = new System.Drawing.Point(87, 19);
			this.btnAdvanced.Name = "btnAdvanced";
			this.btnAdvanced.Size = new System.Drawing.Size(75, 52);
			this.btnAdvanced.TabIndex = 2;
			this.btnAdvanced.Text = "Advanced";
			this.btnAdvanced.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnPartEnding);
			this.groupBox2.Controls.Add(this.btnPartIntro);
			this.groupBox2.Location = new System.Drawing.Point(12, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(170, 78);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Lead-in / Lead-out";
			// 
			// btnPartIntro
			// 
			this.btnPartIntro.Enabled = false;
			this.btnPartIntro.Location = new System.Drawing.Point(6, 19);
			this.btnPartIntro.Name = "btnPartIntro";
			this.btnPartIntro.Size = new System.Drawing.Size(75, 52);
			this.btnPartIntro.TabIndex = 2;
			this.btnPartIntro.Text = "Intro";
			this.btnPartIntro.UseVisualStyleBackColor = true;
			// 
			// btnPartEnding
			// 
			this.btnPartEnding.Enabled = false;
			this.btnPartEnding.Location = new System.Drawing.Point(87, 19);
			this.btnPartEnding.Name = "btnPartEnding";
			this.btnPartEnding.Size = new System.Drawing.Size(75, 52);
			this.btnPartEnding.TabIndex = 3;
			this.btnPartEnding.Text = "Ending";
			this.btnPartEnding.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnPartVariation);
			this.groupBox3.Controls.Add(this.btnPartOriginal);
			this.groupBox3.Location = new System.Drawing.Point(188, 96);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(169, 78);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Main parts";
			// 
			// btnPartVariation
			// 
			this.btnPartVariation.Enabled = false;
			this.btnPartVariation.Location = new System.Drawing.Point(87, 19);
			this.btnPartVariation.Name = "btnPartVariation";
			this.btnPartVariation.Size = new System.Drawing.Size(75, 52);
			this.btnPartVariation.TabIndex = 5;
			this.btnPartVariation.Text = "Variation";
			this.btnPartVariation.UseVisualStyleBackColor = true;
			// 
			// btnPartOriginal
			// 
			this.btnPartOriginal.Enabled = false;
			this.btnPartOriginal.Location = new System.Drawing.Point(6, 19);
			this.btnPartOriginal.Name = "btnPartOriginal";
			this.btnPartOriginal.Size = new System.Drawing.Size(75, 52);
			this.btnPartOriginal.TabIndex = 4;
			this.btnPartOriginal.Text = "Original";
			this.btnPartOriginal.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbAutoFill);
			this.groupBox4.Controls.Add(this.btnPartFill);
			this.groupBox4.Location = new System.Drawing.Point(363, 96);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 78);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Fill in";
			// 
			// btnPartFill
			// 
			this.btnPartFill.Enabled = false;
			this.btnPartFill.Location = new System.Drawing.Point(7, 19);
			this.btnPartFill.Name = "btnPartFill";
			this.btnPartFill.Size = new System.Drawing.Size(75, 52);
			this.btnPartFill.TabIndex = 5;
			this.btnPartFill.Text = "Fill";
			this.btnPartFill.UseVisualStyleBackColor = true;
			// 
			// cbAutoFill
			// 
			this.cbAutoFill.AutoSize = true;
			this.cbAutoFill.Enabled = false;
			this.cbAutoFill.Location = new System.Drawing.Point(105, 38);
			this.cbAutoFill.Name = "cbAutoFill";
			this.cbAutoFill.Size = new System.Drawing.Size(60, 17);
			this.cbAutoFill.TabIndex = 4;
			this.cbAutoFill.Text = "Auto fill";
			this.cbAutoFill.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.btnPlaybackStop);
			this.groupBox5.Controls.Add(this.btnPlaybackStart);
			this.groupBox5.Location = new System.Drawing.Point(188, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(170, 78);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Playback";
			// 
			// btnPlaybackStop
			// 
			this.btnPlaybackStop.Enabled = false;
			this.btnPlaybackStop.Location = new System.Drawing.Point(87, 19);
			this.btnPlaybackStop.Name = "btnPlaybackStop";
			this.btnPlaybackStop.Size = new System.Drawing.Size(75, 52);
			this.btnPlaybackStop.TabIndex = 2;
			this.btnPlaybackStop.Text = "Stop";
			this.btnPlaybackStop.UseVisualStyleBackColor = true;
			// 
			// btnPlaybackStart
			// 
			this.btnPlaybackStart.Enabled = false;
			this.btnPlaybackStart.Location = new System.Drawing.Point(6, 19);
			this.btnPlaybackStart.Name = "btnPlaybackStart";
			this.btnPlaybackStart.Size = new System.Drawing.Size(75, 52);
			this.btnPlaybackStart.TabIndex = 1;
			this.btnPlaybackStart.Text = "Start";
			this.btnPlaybackStart.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.lTempo);
			this.groupBox6.Controls.Add(this.lStyleName);
			this.groupBox6.Controls.Add(this.btnOpenStyle);
			this.groupBox6.Controls.Add(this.pbBeatMeter);
			this.groupBox6.Controls.Add(this.lMeasure);
			this.groupBox6.Location = new System.Drawing.Point(364, 12);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(199, 78);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "OSD";
			// 
			// lMeasure
			// 
			this.lMeasure.AutoSize = true;
			this.lMeasure.Location = new System.Drawing.Point(6, 16);
			this.lMeasure.Name = "lMeasure";
			this.lMeasure.Size = new System.Drawing.Size(22, 13);
			this.lMeasure.TabIndex = 0;
			this.lMeasure.Text = "0.0";
			// 
			// btnOpenStyle
			// 
			this.btnOpenStyle.Location = new System.Drawing.Point(150, 16);
			this.btnOpenStyle.Name = "btnOpenStyle";
			this.btnOpenStyle.Size = new System.Drawing.Size(43, 23);
			this.btnOpenStyle.TabIndex = 6;
			this.btnOpenStyle.Text = "Open";
			this.btnOpenStyle.UseVisualStyleBackColor = true;
			this.btnOpenStyle.Click += new System.EventHandler(this.btnOpenStyle_Click);
			// 
			// lStyleName
			// 
			this.lStyleName.Location = new System.Drawing.Point(6, 58);
			this.lStyleName.Name = "lStyleName";
			this.lStyleName.Size = new System.Drawing.Size(127, 13);
			this.lStyleName.TabIndex = 7;
			this.lStyleName.Text = "Please open a style";
			// 
			// lTempo
			// 
			this.lTempo.Location = new System.Drawing.Point(132, 58);
			this.lTempo.Name = "lTempo";
			this.lTempo.Size = new System.Drawing.Size(61, 13);
			this.lTempo.TabIndex = 8;
			this.lTempo.Text = "0 BPM";
			this.lTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pbBeatMeter
			// 
			this.pbBeatMeter.BackColor = System.Drawing.Color.White;
			this.pbBeatMeter.ForeColor = System.Drawing.Color.Green;
			this.pbBeatMeter.Location = new System.Drawing.Point(9, 32);
			this.pbBeatMeter.Maximum = 100;
			this.pbBeatMeter.Minimum = 0;
			this.pbBeatMeter.Name = "pbBeatMeter";
			this.pbBeatMeter.Size = new System.Drawing.Size(71, 10);
			this.pbBeatMeter.TabIndex = 6;
			this.pbBeatMeter.Value = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 180);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 6;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 209);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "TomiSoft Roland Arranger Demo";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAdvanced;
		private System.Windows.Forms.Button btnBasic;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnPartEnding;
		private System.Windows.Forms.Button btnPartIntro;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnPartVariation;
		private System.Windows.Forms.Button btnPartOriginal;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox cbAutoFill;
		private System.Windows.Forms.Button btnPartFill;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button btnPlaybackStop;
		private System.Windows.Forms.Button btnPlaybackStart;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label lMeasure;
		private System.Windows.Forms.Label lTempo;
		private System.Windows.Forms.Label lStyleName;
		private System.Windows.Forms.Button btnOpenStyle;
		private CustomProgressBar pbBeatMeter;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}

