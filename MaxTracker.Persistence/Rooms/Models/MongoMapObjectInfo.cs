using MaxTracker.Domain.Shared;

namespace MaxTracker.Persistence.Rooms.Models
{
	public abstract class MongoMapObjectInfo
	{
		public int Width { get; set; }

		public int Length { get; set; }

		public Point Coordinates { get; set; }
	}
}
