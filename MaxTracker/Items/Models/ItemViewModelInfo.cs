using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Items.Models
{
	public abstract class ItemViewModelInfo
	{
		[Required]
		public int TypeId { get; set; }

		public ItemTypeViewModel Type { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int RoomNumber { get; set; }

		[Required]
		public string ResponsibleEmail { get; set; }
	}
}
