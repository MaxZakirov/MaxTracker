using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public class UpdateItemCommand : IUpdateItemCommand
	{
		private readonly IItemRepository itemRepository;

		public UpdateItemCommand(IItemRepository itemRepository)
		{
			this.itemRepository = itemRepository;
		}

		public Item ItemToUpdate { get; set; }

		public void Execute()
		{
			itemRepository.Update(ItemToUpdate);
		}
	}
}
