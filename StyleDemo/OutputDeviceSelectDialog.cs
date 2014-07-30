using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Midi;

namespace StyleDemo {
	public partial class OutputDeviceSelectDialog : Form {
		private OutputDevice device;

		public OutputDevice Device {
			get { return device; }
		}
		
		public OutputDeviceSelectDialog() {
			InitializeComponent();

			foreach (OutputDevice dev in OutputDevice.InstalledDevices) {
				lbOutputDevices.Items.Add(dev.Name);
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if (lbOutputDevices.SelectedIndices.Count != 1) {
				MessageBox.Show(
					"Please select an item from the list",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			else {
				this.DialogResult = System.Windows.Forms.DialogResult.OK;

				this.device = OutputDevice.InstalledDevices[lbOutputDevices.SelectedIndices[0]];
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		protected override void OnClosing(CancelEventArgs e) {
			if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
	}
}
