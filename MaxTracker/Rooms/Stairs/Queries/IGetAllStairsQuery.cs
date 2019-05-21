using System.Collections.Generic;

namespace MaxTracker.Rooms.Stairs.Queries
{
	public interface IGetAllStairsQuery
	{
		IEnumerable<Domain.Rooms.Stairs> Execute();
	}
}
