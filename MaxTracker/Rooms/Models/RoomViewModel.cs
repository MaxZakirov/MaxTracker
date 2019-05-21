using System.ComponentModel.DataAnnotations;
using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Rooms.Models
{
	public class RoomViewModel : IRoomInfo
	{
		[Required]
		public int Number { get; set; }

		[Required]
		public int Width { get; set; }

		[Required]
		public int Length { get; set; }

		[Required]
		public Point Coordinates { get; set; }

		[Required]
		public int Floor { get; set; }

		[Required]
		public DoorsViewModel Doors { get; set; }

		IDoorsInfo IRoomInfo.Doors => this.Doors;
	}
}
