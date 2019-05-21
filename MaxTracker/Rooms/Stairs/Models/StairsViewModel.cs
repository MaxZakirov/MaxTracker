using System;
using System.ComponentModel.DataAnnotations;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Rooms.Stairs.Models
{
	public class StairsViewModel
	{
		public Guid? Id { get; set; }

		[Required]
		public int Width { get; set; }

		[Required]
		public int Length { get; set; }

		[Required]
		public Point Coordinates { get; set; }

		[Required]
		public int StartFloor { get; set; }

		[Required]
		public int EndFloor { get; set; }
	}
}
