using System;
using System.Collections.Generic;
using System.Linq;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Queries
{
	public class GetAllItemsQuery : IGetAllItemsQuery
	{
		private readonly IItemRepository itemRepository;
		private readonly IGetAllItemTypesQuery getAllItemTypesQuery;

		public GetAllItemsQuery(
			IItemRepository itemRepository,
			IGetAllItemTypesQuery getAllItemTypesQuery)
		{
			this.itemRepository = itemRepository;
			this.getAllItemTypesQuery = getAllItemTypesQuery;
		}

		public IEnumerable<Item> Execute()
		{
			try
			{
				var result = this.itemRepository.GetAll().ToList();
				var itemTypes = getAllItemTypesQuery.Execute();

				result.ForEach(i => i.Type = itemTypes.First(it => it.Id == i.TypeId));

				return result;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
