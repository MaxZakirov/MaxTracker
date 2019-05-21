using System.Collections.Generic;
using MaxTracker.Domain.Rooms;

namespace MaxTracker.Rooms.Stairs.Queries
{
	public class GetAllStairsQuery : IGetAllStairsQuery
	{
		private readonly IStairsRepository stairsRepository;

		public GetAllStairsQuery(IStairsRepository stairsRepository)
		{
			this.stairsRepository = stairsRepository;
		}

		public IEnumerable<Domain.Rooms.Stairs> Execute()
		{
			return this.stairsRepository.GetAll();
		}
	}
}
