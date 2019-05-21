using System;
using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Items.Models
{
	public class ItemViewModel : ItemViewModelInfo
	{
		[Required]
		public Guid Id { get; set; }

		public string CurrentUserEmail { get; set; }
	}
}
