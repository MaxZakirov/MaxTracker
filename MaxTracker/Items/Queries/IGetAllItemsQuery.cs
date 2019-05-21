using System.Collections.Generic;
using MaxTracker.Domain.Items;
using MaxTracker.Items.Models;

namespace MaxTracker.Items.Queries
{
	public interface IGetAllItemsQuery
	{
		IEnumerable<Item> Execute();
	}
}
