using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public interface ICreateItemTypeCommand
	{
		ItemType ItemTypeToCreate { get; set; }

		void Execute();
	}
}
