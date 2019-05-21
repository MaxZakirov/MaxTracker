using System;
using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Items.Models
{
	public class ToggleItemRoomModel
	{
		[Required]
		public Guid ItemId { get; set; }

		[Required]
		public int RoomNumber { get; set; }
	}
}
