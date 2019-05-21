using System;
using AutoMapper;
using MaxTracker.Domain.Rooms;
using MaxTracker.Persistence.Rooms.Models;
using MongoDB.Driver;

namespace MaxTracker.Persistence.Rooms
{
	public class MongoStairsRepository : MongoRepository<Stairs, MongoStairsModel>, IStairsRepository
	{
		public MongoStairsRepository(IDbContext dbContext)
			: base(dbContext)
		{

		}

		public void Delete(Guid id)
		{
			var filter = Builders<MongoStairsModel>.Filter.Eq(r => r.Id, id);
			this.entities.DeleteOne(filter);
		}

		public void Update(Stairs room)
		{
			var mongoModel = Mapper.Map<MongoStairsModel>(room);
			this.entities.ReplaceOne(entities => entities.Id == mongoModel.Id, mongoModel);
		}
	}
}
