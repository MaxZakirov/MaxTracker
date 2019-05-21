using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public interface IRoomRepository : IRepository<Room>
	{
		void Delete(int number);

		void Update(Room room);
	}
}
