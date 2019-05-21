using System;
using System.Linq;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public class CreateItemCommand : ICreateItemCommand
	{
		private readonly IItemRepository itemRepository;

		public CreateItemCommand(IItemRepository itemRepository)
		{
			this.itemRepository = itemRepository;
		}

		public Item ItemToCreate { get; set; }

		public void Execute()
		{
			this.ItemToCreate.Id = Guid.NewGuid();
			this.itemRepository.Create(this.ItemToCreate);
		}
	}
}
