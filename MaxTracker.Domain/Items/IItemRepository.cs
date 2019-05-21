using System;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Items
{
	public interface IItemRepository : IRepository<Item>
	{
		Item GetById(Guid itemId);

		void Delete(Guid itemId);

		void Update(Item item);
	}
}
