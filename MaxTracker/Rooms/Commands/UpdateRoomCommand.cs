using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Exceptions;

namespace MaxTracker.Rooms.Commands
{
	public class UpdateRoomCommand : IUpdateRoomCommand
	{
		private readonly IRoomRepository roomRepository;
		private readonly IRoomService roomService;

		public UpdateRoomCommand(
			IRoomRepository roomRepository,
			IRoomService roomService)
		{
			this.roomRepository = roomRepository;
			this.roomService = roomService;
		}

		public Room RoomModel { get; set; }

		public void Execute()
		{
			if (this.roomService.RoomIsIntersectedWithOtherMapObjects(this.RoomModel))
			{
				throw new RoomIsIntersectedWithExisting();
			}

			this.roomRepository.Update(this.RoomModel);
		}
	}
}
