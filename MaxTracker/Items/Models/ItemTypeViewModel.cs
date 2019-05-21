using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Items.Models
{
	public class ItemTypeViewModel
	{
		public int? Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
