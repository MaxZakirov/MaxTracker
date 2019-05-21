using MaxTracker.Domain.Rooms;
using MongoDB.Bson.Serialization.Attributes;

namespace MaxTracker.Persistence.Rooms.Models
{
	public class MongoRoomModel : MongoMapObjectInfo, IRoomInfo
	{
		[BsonId]
		public int Number { get; set; }

		public int Floor { get; set; }

		public MongoDoorsModel Doors { get; set; }

		IDoorsInfo IRoomInfo.Doors => this.Doors;
	}
}
