using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Items;
using MaxTracker.Persistence.Items.Models;
using MongoDB.Driver;

namespace MaxTracker.Persistence.Items
{
	public class MongoItemRepository : MongoRepository<Item, MongoItemModel>, IItemRepository
	{
		private readonly IDbContext dbContext;

		public MongoItemRepository(IDbContext dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;
		}

		public override IEnumerable<Item> GetAll()
		{
			try
			{
				var queryResult = this.entities.Find(u => true).ToList();
				return queryResult.Select(mongoModel => Mapper.Map<Item>(mongoModel));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Delete(Guid itemId)
		{
			var filter = Builders<MongoItemModel>.Filter.Eq(r => r.Id, itemId);
			this.entities.DeleteOne(filter);
		}

		public void Update(Item item)
		{
			var mongoModel = Mapper.Map<MongoItemModel>(item);
			this.entities.ReplaceOne(entities => entities.Id == item.Id, mongoModel);
		}

		public Item GetById(Guid itemId)
		{
			var queryResult = this.entities.Find<MongoItemModel>(u => u.Id == itemId);

			if (!queryResult.Any())
				return null;

			var result = queryResult.Single();

			return Mapper.Map<Item>(result);
		}
	}
}
