using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Exceptions;

namespace MaxTracker.Rooms.Stairs.Commands
{
	public class UpdateStairsCommand : IUpdateStairsCommand
	{
		private readonly IStairsRepository stairsRepository;
		private readonly IRoomService roomService;

		public UpdateStairsCommand(
			IStairsRepository stairsRepository,
			IRoomService roomService)
		{
			this.stairsRepository = stairsRepository;
			this.roomService = roomService;
		}

		public Domain.Rooms.Stairs StairsToUpdate { get; set; }

		public void Execute()
		{
			if (this.roomService.StairsAreIntersectedWithOtherMapObjects(this.StairsToUpdate))
			{
				throw new RoomIsIntersectedWithExisting();
			}

			this.stairsRepository.Update(this.StairsToUpdate);
		}
	}
}
