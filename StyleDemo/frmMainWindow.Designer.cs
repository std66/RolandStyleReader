namespace StyleDemo {
	partial class frmMainWindow {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mIDISettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lStyleName = new System.Windows.Forms.Label();
			this.lSignature = new System.Windows.Forms.Label();
			this.lMetronomeMark = new System.Windows.Forms.Label();
			this.lTempo = new System.Windows.Forms.Label();
			this.gbStyleInfo = new System.Windows.Forms.GroupBox();
			this.lwMessages = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.btnPlay = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lTotalTime = new System.Windows.Forms.Label();
			this.lFriendlyTime = new System.Windows.Forms.Label();
			this.pbPlaybackPosition = new StyleDemo.CustomProgressBar();
			this.pbBeat = new StyleDemo.CustomProgressBar();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.gbStyleInfo.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(616, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mIDISettingsToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// mIDISettingsToolStripMenuItem
			// 
			this.mIDISettingsToolStripMenuItem.Name = "mIDISettingsToolStripMenuItem";
			this.mIDISettingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.mIDISettingsToolStripMenuItem.Text = "MIDI settings";
			this.mIDISettingsToolStripMenuItem.Click += new System.EventHandler(this.mIDISettingsToolStripMenuItem_Click);
			// 
			// lStyleName
			// 
			this.lStyleName.AutoSize = true;
			this.lStyleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lStyleName.Location = new System.Drawing.Point(6, 15);
			this.lStyleName.Name = "lStyleName";
			this.lStyleName.Size = new System.Drawing.Size(187, 20);
			this.lStyleName.TabIndex = 1;
			this.lStyleName.Text = "No style has been loaded";
			// 
			// lSignature
			// 
			this.lSignature.AutoSize = true;
			this.lSignature.Location = new System.Drawing.Point(6, 39);
			this.lSignature.Name = "lSignature";
			this.lSignature.Size = new System.Drawing.Size(99, 13);
			this.lSignature.TabIndex = 2;
			this.lSignature.Text = "Unknown signature";
			// 
			// lMetronomeMark
			// 
			this.lMetronomeMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lMetronomeMark.Location = new System.Drawing.Point(525, 13);
			this.lMetronomeMark.Name = "lMetronomeMark";
			this.lMetronomeMark.Size = new System.Drawing.Size(61, 13);
			this.lMetronomeMark.TabIndex = 3;
			this.lMetronomeMark.Text = "0/0";
			this.lMetronomeMark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lTempo
			// 
			this.lTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lTempo.Location = new System.Drawing.Point(522, 30);
			this.lTempo.Name = "lTempo";
			this.lTempo.Size = new System.Drawing.Size(64, 13);
			this.lTempo.TabIndex = 4;
			this.lTempo.Text = "0 BPM";
			this.lTempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbStyleInfo
			// 
			this.gbStyleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbStyleInfo.Controls.Add(this.lStyleName);
			this.gbStyleInfo.Controls.Add(this.lTempo);
			this.gbStyleInfo.Controls.Add(this.lSignature);
			this.gbStyleInfo.Controls.Add(this.lMetronomeMark);
			this.gbStyleInfo.Location = new System.Drawing.Point(12, 27);
			this.gbStyleInfo.Name = "gbStyleInfo";
			this.gbStyleInfo.Size = new System.Drawing.Size(592, 65);
			this.gbStyleInfo.TabIndex = 5;
			this.gbStyleInfo.TabStop = false;
			this.gbStyleInfo.Text = "Style info";
			// 
			// lwMessages
			// 
			this.lwMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lwMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lwMessages.FullRowSelect = true;
			this.lwMessages.Location = new System.Drawing.Point(12, 167);
			this.lwMessages.Name = "lwMessages";
			this.lwMessages.Size = new System.Drawing.Size(592, 226);
			this.lwMessages.TabIndex = 6;
			this.lwMessages.UseCompatibleStateImageBehavior = false;
			this.lwMessages.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Time";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Message";
			this.columnHeader1.Width = 88;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Channel";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Data1";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Data2";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Data3";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Intro",
            "Original",
            "Variation",
            "Variation2",
            "Fill to Variation",
            "Fill to Variation2",
            "Fill to Original",
            "Ending"});
			this.comboBox1.Location = new System.Drawing.Point(119, 25);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 7;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Enabled = false;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "Basic",
            "Advanced"});
			this.comboBox2.Location = new System.Drawing.Point(6, 25);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(107, 21);
			this.comboBox2.TabIndex = 8;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Enabled = false;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "Drum",
            "Bass",
            "Acc1",
            "Acc2",
            "Acc3",
            "Acc4",
            "Acc5",
            "Acc6"});
			this.comboBox3.Location = new System.Drawing.Point(246, 25);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(68, 21);
			this.comboBox3.TabIndex = 9;
			// 
			// comboBox4
			// 
			this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox4.Enabled = false;
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Items.AddRange(new object[] {
            "Major",
            "Minor",
            "7th"});
			this.comboBox4.Location = new System.Drawing.Point(320, 25);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(73, 21);
			this.comboBox4.TabIndex = 10;
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPlay.Enabled = false;
			this.btnPlay.Location = new System.Drawing.Point(104, 17);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 11;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.comboBox4);
			this.groupBox1.Location = new System.Drawing.Point(12, 98);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(401, 63);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Part select";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.pbPlaybackPosition);
			this.groupBox2.Controls.Add(this.lTotalTime);
			this.groupBox2.Controls.Add(this.lFriendlyTime);
			this.groupBox2.Controls.Add(this.btnPlay);
			this.groupBox2.Controls.Add(this.pbBeat);
			this.groupBox2.Location = new System.Drawing.Point(419, 98);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(185, 63);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Playback";
			// 
			// lTotalTime
			// 
			this.lTotalTime.AutoSize = true;
			this.lTotalTime.Location = new System.Drawing.Point(6, 29);
			this.lTotalTime.Name = "lTotalTime";
			this.lTotalTime.Size = new System.Drawing.Size(13, 13);
			this.lTotalTime.TabIndex = 16;
			this.lTotalTime.Text = "0";
			// 
			// lFriendlyTime
			// 
			this.lFriendlyTime.AutoSize = true;
			this.lFriendlyTime.Location = new System.Drawing.Point(6, 16);
			this.lFriendlyTime.Name = "lFriendlyTime";
			this.lFriendlyTime.Size = new System.Drawing.Size(31, 13);
			this.lFriendlyTime.TabIndex = 16;
			this.lFriendlyTime.Text = "0.0.0";
			// 
			// pbPlaybackPosition
			// 
			this.pbPlaybackPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbPlaybackPosition.BackColor = System.Drawing.Color.White;
			this.pbPlaybackPosition.ForeColor = System.Drawing.Color.Green;
			this.pbPlaybackPosition.Location = new System.Drawing.Point(8, 46);
			this.pbPlaybackPosition.Maximum = 100;
			this.pbPlaybackPosition.Minimum = 0;
			this.pbPlaybackPosition.Name = "pbPlaybackPosition";
			this.pbPlaybackPosition.Size = new System.Drawing.Size(75, 10);
			this.pbPlaybackPosition.TabIndex = 17;
			this.pbPlaybackPosition.Value = 0;
			// 
			// pbBeat
			// 
			this.pbBeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pbBeat.BackColor = System.Drawing.Color.White;
			this.pbBeat.ForeColor = System.Drawing.Color.Green;
			this.pbBeat.Location = new System.Drawing.Point(104, 46);
			this.pbBeat.Maximum = 100;
			this.pbBeat.Minimum = 0;
			this.pbBeat.Name = "pbBeat";
			this.pbBeat.Size = new System.Drawing.Size(75, 10);
			this.pbBeat.TabIndex = 13;
			this.pbBeat.Value = 0;
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// frmMainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(616, 405);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lwMessages);
			this.Controls.Add(this.gbStyleInfo);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMainWindow";
			this.Text = "TomiSoft Roland Style Reader";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbStyleInfo.ResumeLayout(false);
			this.gbStyleInfo.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Label lStyleName;
		private System.Windows.Forms.Label lSignature;
		private System.Windows.Forms.Label lMetronomeMark;
		private System.Windows.Forms.Label lTempo;
		private System.Windows.Forms.GroupBox gbStyleInfo;
		private System.Windows.Forms.ListView lwMessages;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button btnPlay;
		private CustomProgressBar pbBeat;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mIDISettingsToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lTotalTime;
		private System.Windows.Forms.Label lFriendlyTime;
		private CustomProgressBar pbPlaybackPosition;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
	}
}

