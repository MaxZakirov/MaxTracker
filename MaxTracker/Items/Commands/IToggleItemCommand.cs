using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxTracker.Items.Commands
{
	public interface IToggleItemCommand
	{
		Guid ItemId { get; set; }

		int RoomNumber { get; set; }

		void Execute();
	}
}
