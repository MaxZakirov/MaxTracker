namespace MaxTracker.Rooms.Commands
{
	public interface IDeleteRoomCommand
	{
		int Number { get; set; }

		void Execute();
	}
}
