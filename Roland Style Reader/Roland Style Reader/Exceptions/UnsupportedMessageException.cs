using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TomiSoft.RolandStyleReader {
	/// <summary>
	/// This exception is thrown when the parser founds an unknown message
	/// </summary>
	public class UnsupportedMessageException : Exception {
		private int messageCode;

		/// <summary>
		/// Gets the code of the unsupported message
		/// </summary>
		public int MessageCode {
			get { return messageCode; }
		}
		
		/// <summary>
		/// Initializes a new instance of the UnsupportedMessageException
		/// </summary>
		/// <param name="MessageCode">The code of the message</param>
		public UnsupportedMessageException(int MessageCode) : base("Unsupported message has been found") {
			this.messageCode = MessageCode;
		}
	}
}
