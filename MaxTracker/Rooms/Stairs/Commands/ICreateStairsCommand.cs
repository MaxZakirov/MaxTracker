namespace MaxTracker.Rooms.Stairs.Commands
{
	public interface ICreateStairsCommand
	{
		Domain.Rooms.Stairs StairsToCreate { get; set; }

		void Execute();
	}
}
