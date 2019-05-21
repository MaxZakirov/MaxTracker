using MaxTracker.Persistence.Authentication.Modelds;
using MongoDB.Driver;

namespace MaxTracker.Persistence
{
	public interface IDbContext
	{
		IMongoCollection<T> GetByType<T>();
	}
}
