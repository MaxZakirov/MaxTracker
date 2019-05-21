using System;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public interface IStairsRepository : IRepository<Stairs>
	{
		void Delete(Guid id);

		void Update(Stairs room);
	}
}
