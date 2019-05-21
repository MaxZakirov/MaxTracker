using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Exceptions;
using MaxTracker.Shared;
using MongoDB.Driver;

namespace MaxTracker.Rooms.Commands
{
	public class CreateRoomCommand : ICreateRoomCommand
	{
		private readonly IRoomRepository roomRepository;
		private readonly IRoomService roomService;

		public CreateRoomCommand(
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

			try
			{
				this.roomRepository.Create(this.RoomModel);
			}
			catch (MongoWriteException ex)
			{
				throw new DuplicatedKeyException($"Room with number {this.RoomModel.Number} already exist.");
			}
		}
	}
}
