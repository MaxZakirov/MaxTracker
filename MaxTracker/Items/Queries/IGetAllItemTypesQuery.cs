using System.Collections.Generic;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Queries
{
	public interface IGetAllItemTypesQuery
	{
		IEnumerable<ItemType> Execute();
	}
}
