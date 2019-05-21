using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MaxTracker.Persistence.Rooms.Models
{
	public class MongoStairsModel : MongoMapObjectInfo
	{
		[BsonId]
		public Guid Id { get; set; }

		public int StartFloor { get; set; }

		public int EndFloor { get; set; }
	}
}
