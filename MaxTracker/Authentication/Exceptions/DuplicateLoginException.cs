using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxTracker.Authentication.Exceptions
{
	public class DuplicateLoginException : Exception
	{
		public DuplicateLoginException(string message)
			: base(message)
		{

		}
	}
}
