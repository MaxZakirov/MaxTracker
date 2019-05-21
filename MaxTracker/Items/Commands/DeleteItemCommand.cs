using System;
using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public class DeleteItemCommand : IDeleteItemCommand
	{
		private readonly IItemRepository itemRepository;

		public DeleteItemCommand(IItemRepository itemRepository)
		{
			this.itemRepository = itemRepository;
		}

		public Guid ItemId { get; set; }

		public void Execute()
		{
			this.itemRepository.Delete(this.ItemId);
		}
	}
}
