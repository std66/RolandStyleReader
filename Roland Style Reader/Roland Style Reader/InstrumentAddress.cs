using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// Stores the Major, Minor and Seventh addresses of an instrument in a style part
	/// </summary>
	public struct InstrumentAddress {
		private int major;
		private int minor;
		private int seventh;

		/// <summary>
		/// Gets the major data address
		/// </summary>
		public int Major {
			get { return major; }
		}

		/// <summary>
		/// Gets the minor data address
		/// </summary>
		public int Minor {
			get { return minor; }
		}

		/// <summary>
		/// Gets the seventh data address
		/// </summary>
		public int Seventh {
			get { return seventh; }
		}

		/// <summary>
		/// If available, gets the address of the style part in the given chord family
		/// </summary>
		/// <param name="Type"></param>
		/// <returns></returns>
		public int this[ChordType Type] {
			get {
				if (this.IsAvailable(Type))
					return this.GetAddress(Type);
				else
					throw new Exception("Nincs ilyen bejegyzés a fájlban");
			}
		}

		/// <summary>
		/// Initializes a new instance of the InstrumentAddress struct
		/// </summary>
		/// <param name="Major">Address of the major part</param>
		/// <param name="Minor">Address of the minor part</param>
		/// <param name="Seventh">Address of the seventh part</param>
		public InstrumentAddress(int Major, int Minor, int Seventh) {
			this.major = Major;
			this.minor = Minor;
			this.seventh = Seventh;
		}

		/// <summary>
		/// Determines whether that the style part is available in the given chord family
		/// </summary>
		/// <param name="Type">The chord family</param>
		/// <returns></returns>
		public bool IsAvailable(ChordType Type) {
			return (this.GetAddress(Type) > 0);
		}

		/// <summary>
		/// Gets the address of the style part in the given chord family
		/// </summary>
		/// <param name="Type">The chord family</param>
		/// <returns>The address of the style part data</returns>
		private int GetAddress(ChordType Type) {
			switch (Type) {
				case ChordType.Major: return this.major;
				case ChordType.Minor: return this.minor;
				case ChordType.Seventh: return this.seventh;
			}

			throw new Exception("Ismeretlen paraméter");
		}
	}
}
