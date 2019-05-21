using System;

namespace MaxTracker.Items.Commands
{
	public interface IDeleteItemCommand
	{
		Guid ItemId { get; set; }

		void Execute();
	}
}
