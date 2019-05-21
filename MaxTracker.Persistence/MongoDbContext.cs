using System;
using MaxTracker.Persistence.Authentication.Modelds;
using MaxTracker.Persistence.Items.Models;
using MaxTracker.Persistence.Rooms.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MaxTracker.Persistence
{
	public class MongoDbContext : IDbContext
	{
		private readonly IMongoDatabase maxTrackerDb;

		public MongoDbContext(IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("MaxTrackerMongoDb");
			var mongoClient = new MongoClient(connectionString);
			this.maxTrackerDb = mongoClient.GetDatabase("MaxTrackerDb");
		}

		public IMongoCollection<T> GetByType<T>()
		{
			string collectionName = this.GetCollectionFromType(typeof(T));
			return this.maxTrackerDb.GetCollection<T>(collectionName);
		}

		private string GetCollectionFromType(Type type)
		{
			if (type == typeof(MongoUserModel))
				return "UsersLoginInfo";

			if (type == typeof(MongoRoomModel))
				return "Rooms";

			if (type == typeof(MongoStairsModel))
				return "Stairs";

			if (type == typeof(MongoItemModel))
				return "Items";

			if (type == typeof(MongoItemType))
				return "ItemTypes";

			throw new Exception($"Can not find collection for type {type.ToString()}");
		}
	}
}
