using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Rooms.Models
{
	public class DoorsViewModel : IDoorsInfo
	{
		public Point StartPoint { get; set; }

		public Point EndPoint { get; set; }
	}
}
