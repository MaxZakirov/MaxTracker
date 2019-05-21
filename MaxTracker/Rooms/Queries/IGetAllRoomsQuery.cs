using System.Collections.Generic;
using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Queries
{
	public interface IGetAllRoomsQuery
	{
		IEnumerable<Room> Execute();
	}
}
