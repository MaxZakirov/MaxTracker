using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Commands
{
	public interface IUpdateRoomCommand
	{
		Room RoomModel { get; set; }

		void Execute();
	}
}