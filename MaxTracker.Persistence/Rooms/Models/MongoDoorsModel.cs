using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Persistence.Rooms.Models
{
	public class MongoDoorsModel : IDoorsInfo
	{
		public MongoDoorsModel()
		{

		}

		public Point StartPoint { get; set; }

		public Point EndPoint { get; set; }
	}
}
