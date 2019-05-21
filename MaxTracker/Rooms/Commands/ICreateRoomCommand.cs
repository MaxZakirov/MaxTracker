using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Commands
{
	public interface ICreateRoomCommand
	{
		Room RoomModel { get; set; }

		void Execute();
	}
}