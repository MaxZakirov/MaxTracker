namespace MaxTracker.Rooms.Stairs.Commands
{
	public interface IUpdateStairsCommand
	{
		Domain.Rooms.Stairs StairsToUpdate { get; set; }

		void Execute();
	}
}
