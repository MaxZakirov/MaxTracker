using MaxTracker.Domain.Items;
using MaxTracker.Persistence.Items.Models;

namespace MaxTracker.Persistence.Items
{
	public class MongoItemTypeRepository : MongoRepository<ItemType, MongoItemType>, IItemTypeRepository
	{
		public MongoItemTypeRepository(IDbContext dbContext) : base(dbContext)
		{
		}
	}
}
