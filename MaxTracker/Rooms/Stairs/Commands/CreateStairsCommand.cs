using System;
using System.Collections.Generic;
using System.Linq;
using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Exceptions;
using MaxTracker.Rooms.Queries;
using MaxTracker.Rooms.Stairs.Queries;
using MongoDB.Driver;

namespace MaxTracker.Rooms.Stairs.Commands
{
	public class CreateStairsCommand : ICreateStairsCommand
	{
		private readonly IStairsRepository stairsRepository;
		private readonly IRoomService roomService;

		public CreateStairsCommand(
			IStairsRepository stairsRepository,
			IRoomService roomService)
		{
			this.stairsRepository = stairsRepository;
			this.roomService = roomService;
		}

		public Domain.Rooms.Stairs StairsToCreate { get; set; }


		public void Execute()
		{
			if (roomService.StairsAreIntersectedWithOtherMapObjects(StairsToCreate))
			{
				throw new RoomIsIntersectedWithExisting();
			}

			StairsToCreate.InitializeId();

			this.stairsRepository.Create(this.StairsToCreate);
		}
	}
}
