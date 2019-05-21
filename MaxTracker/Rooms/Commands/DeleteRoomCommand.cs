using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Commands
{
	public class DeleteRoomCommand : IDeleteRoomCommand
	{
		private readonly IRoomRepository roomRepository;

		public DeleteRoomCommand(IRoomRepository roomRepository)
		{
			this.roomRepository = roomRepository;
		}

		public int Number { get; set; }

		public void Execute()
		{
			this.roomRepository.Delete(this.Number);
		}
	}
}