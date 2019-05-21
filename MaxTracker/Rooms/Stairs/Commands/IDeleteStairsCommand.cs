using System;

namespace MaxTracker.Rooms.Stairs.Commands
{
	public interface IDeleteStairsCommand
	{
		Guid StairsId { get; set; }

		void Execute();
	}
}
