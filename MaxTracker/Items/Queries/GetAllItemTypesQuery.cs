using System.Collections.Generic;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Queries
{
	public class GetAllItemTypesQuery : IGetAllItemTypesQuery
	{
		private readonly IItemTypeRepository itemTypeRepository;

		public GetAllItemTypesQuery(IItemTypeRepository itemTypeRepository)
		{
			this.itemTypeRepository = itemTypeRepository;
		}

		public IEnumerable<ItemType> Execute()
		{
			return this.itemTypeRepository.GetAll();
		}
	}
}
