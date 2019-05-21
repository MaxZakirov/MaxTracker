using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Rooms;
using MaxTracker.Rooms.Models;

namespace MaxTracker.Rooms.Queries
{
	public class GetAllRoomsQuery : IGetAllRoomsQuery
	{
		private readonly IRoomRepository roomRepository;

		public GetAllRoomsQuery(IRoomRepository roomRepository)
		{
			this.roomRepository = roomRepository;
		}

		public IEnumerable<Room> Execute()
		{
			var rooms = roomRepository.GetAll();
			return rooms;
		}
	}
}

