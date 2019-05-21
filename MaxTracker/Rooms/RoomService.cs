using System.Collections.Generic;
using System.Linq;
using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Queries;
using MaxTracker.Rooms.Stairs.Queries;

namespace MaxTracker.Rooms
{
	public class RoomService : IRoomService
	{
		private readonly IGetAllRoomsQuery getAllRooms;
		private readonly IGetAllStairsQuery getAllStairs;

		public RoomService(
			IGetAllRoomsQuery getAllRooms,
			IGetAllStairsQuery getAllStairs)
		{
			this.getAllRooms = getAllRooms;
			this.getAllStairs = getAllStairs;
		}

		public bool RoomIsIntersectedWithOtherMapObjects(Room room)
		{
			IEnumerable<Room> existingRooms = this.getAllRooms.Execute().Where(r => r.Number != room.Number);
			IEnumerable<Domain.Rooms.Stairs> existingStairs = this.getAllStairs.Execute();

			return existingRooms.Any(r => room.RoomIsInterscted(r))
				|| existingStairs.Any(s => room.RoomIsInterscted(s));
		}

		public bool StairsAreIntersectedWithOtherMapObjects(Domain.Rooms.Stairs stairs)
		{
			IEnumerable<Room> existingRooms = this.getAllRooms.Execute();
			IEnumerable<Domain.Rooms.Stairs> existingStairs = this.getAllStairs.Execute().Where(s => s.Id != stairs.Id);

			return existingRooms.Any(r => r.RoomIsInterscted(stairs))
				|| existingStairs.Any(s => stairs.StairsAreIntersected(s));
		}
	}
}
