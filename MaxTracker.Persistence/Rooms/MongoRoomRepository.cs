using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Rooms;
using MaxTracker.Persistence.Rooms.Models;
using MongoDB.Driver;

namespace MaxTracker.Persistence.Rooms
{
	public class MongoRoomRepository : IRoomRepository
	{
		private readonly IMongoCollection<MongoRoomModel> rooms;

		public MongoRoomRepository(IDbContext dbContext)
		{
			this.rooms = dbContext.GetByType<MongoRoomModel>();
		}

		public virtual void Create(Room entity)
		{
			MongoRoomModel mongoModel = Mapper.Map<MongoRoomModel>(entity);
			this.rooms.InsertOne(mongoModel);
		}

		public virtual IEnumerable<Room> GetAll()
		{
			try
			{
				var queryResult = this.rooms.Find(u => true).ToList();
				return queryResult.Select(mongoModel => RoomBuilder.BuildFromInfo(mongoModel));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Delete(int number)
		{
			var filter = Builders<MongoRoomModel>.Filter.Eq(r => r.Number, number);
			this.rooms.DeleteOne(filter);
		}

		public void Update(Room room)
		{
			var mongoModel = Mapper.Map<MongoRoomModel>(room);
			this.rooms.ReplaceOne(entities => entities.Number == mongoModel.Number, mongoModel);
		}
	}
}
