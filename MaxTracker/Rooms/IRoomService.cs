using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms
{
	public interface IRoomService
	{
		bool RoomIsIntersectedWithOtherMapObjects(Room room);

		bool StairsAreIntersectedWithOtherMapObjects(Domain.Rooms.Stairs stairs);
	}
}
