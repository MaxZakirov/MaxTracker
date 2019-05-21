using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Shared;
using MongoDB.Driver;

namespace MaxTracker.Persistence
{
	public abstract class MongoRepository<R, T> : IRepository<R>
	{
		protected readonly IMongoCollection<T> entities;

		public MongoRepository(
			IDbContext dbContext)
		{
			this.entities = dbContext.GetByType<T>();
		}

		public virtual void Create(R entity)
		{
			T mongoModel = Mapper.Map<T>(entity);
			this.entities.InsertOne(mongoModel);
		}

		public virtual IEnumerable<R> GetAll()
		{
			try
			{
				var queryResult = this.entities.Find(u => true).ToList();
				return queryResult.Select(mongoModel => Mapper.Map<R>(mongoModel));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
