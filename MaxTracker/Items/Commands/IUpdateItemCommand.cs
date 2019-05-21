using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public interface IUpdateItemCommand
	{
		Item ItemToUpdate { get; set; }

		void Execute();
	}
}
