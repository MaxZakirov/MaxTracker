using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public class CreateItemTypeCommand : ICreateItemTypeCommand
	{
		private readonly IItemTypeRepository itemTypeRepository;

		public CreateItemTypeCommand(IItemTypeRepository itemTypeRepository)
		{
			this.itemTypeRepository = itemTypeRepository;
		}

		public ItemType ItemTypeToCreate { get; set; }

		public void Execute()
		{
			this.itemTypeRepository.Create(this.ItemTypeToCreate);
		}
	}
}
