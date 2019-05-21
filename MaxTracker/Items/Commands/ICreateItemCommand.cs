using MaxTracker.Domain.Items;

namespace MaxTracker.Items.Commands
{
	public interface ICreateItemCommand
	{
		Item ItemToCreate { get; set; }

		void Execute();
	}
}
