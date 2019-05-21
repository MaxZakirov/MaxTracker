using System;

namespace MaxTracker.Shared
{
	public class DuplicatedKeyException : Exception
	{
		public DuplicatedKeyException(string msg)
			: base(msg)
		{

		}
	}
}
