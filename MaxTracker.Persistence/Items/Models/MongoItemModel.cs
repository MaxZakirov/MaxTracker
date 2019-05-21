using System;
using MaxTracker.Persistence.Authentication.Modelds;
using MaxTracker.Persistence.Rooms.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace MaxTracker.Persistence.Items.Models
{
	public class MongoItemModel
	{
		[BsonId]
		public Guid Id { get; set; }

		public int TypeId { get; set; }

		[BsonIgnore]
		public MongoItemType Type { get; set; }

		public string Name { get; set; }

		public int RoomNumber { get; set; }

		[BsonIgnore]
		public MongoRoomModel Room { get; set; }

		public string CurrentUserEmail { get; set; }

		[BsonIgnore]
		public MongoUserModel CurrentUser { get; set; }

		public string ResponsibleEmail { get; set; }

		[BsonIgnore]
		public MongoUserModel ResponsibleUser { get; set; }
	}
}
