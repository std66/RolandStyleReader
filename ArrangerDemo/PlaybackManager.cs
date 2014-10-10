using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TomiSoft.RolandStyleReader;

namespace ArrangerDemo {
	class PlaybackManager {

		private RolandStyleData StyleData;

		public Measure Measure {
			get {
				return this.StyleData.Measure;
			}
		}

		public string StyleName {
			get {
				return this.StyleData.Name;
			}
		}

		public int Tempo {
			get {
				return this.StyleData.Tempo;
			}
		}

		private ChordType ctype;

		public ChordType ChordFamily {
			get { return ctype; }
			set {
				ctype = value;
				this.OnStateChange();
			}
		}

		private StylePart? nextPart;

		public StylePart? NextPart {
			get { return nextPart; }
		}
		
		private StylePart currentPart;

		public StylePart CurrentPart {
			get { return currentPart; }
			set {
				currentPart = value;
				this.OnStateChange();
			}
		}

		private Arrangement arrangement;

		public Arrangement Arrangement {
			get { return arrangement; }
			set {
				arrangement = value;
				this.OnStateChange();
			}
		}
		
		public PlaybackManager(string Filename) {
			this.StyleData = RolandStyleData.CreateFromReader(
				new RolandStyleReader(Filename)
			);

			this.arrangement = TomiSoft.RolandStyleReader.Arrangement.Advanced;
			this.ctype = ChordType.Major;
			this.currentPart = StylePart.Original;
			this.nextPart = null;
		}

		public void Fill(bool KeepOnCurrentPart = false) {
			if (currentPart != StylePart.Original || currentPart != StylePart.Variation)
				return;

			if (this.currentPart == StylePart.Original) {
				if (KeepOnCurrentPart) {
					this.currentPart = StylePart.FillToOriginal;
					this.nextPart = StylePart.Original;
				}
				else {
					this.nextPart = StylePart.Variation;
					this.currentPart = StylePart.FillToVariation;
				}

				this.OnStateChange();
			}
			else if (this.currentPart == StylePart.Variation) {
				if (KeepOnCurrentPart) {
					this.currentPart = StylePart.FillToVariation;
					this.nextPart = StylePart.Variation;
				}
				else {
					this.nextPart = StylePart.Original;
					this.currentPart = StylePart.FillToOriginal;
				}

				this.OnStateChange();
			}
		}

		public void Start() {

		}

		public void Stop() {

		}

		private void OnStateChange() {

		}
	}
}
