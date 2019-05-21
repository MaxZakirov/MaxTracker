using System;
using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Stairs.Commands
{
	public class DeleteStairsCommand : IDeleteStairsCommand
	{
		private readonly IStairsRepository stairsRepository;

		public DeleteStairsCommand(
			IStairsRepository stairsRepository)
		{
			this.stairsRepository = stairsRepository;
		}

		public Guid StairsId { get; set; }

		public void Execute()
		{
			this.stairsRepository.Delete(this.StairsId);
		}
	}
}
