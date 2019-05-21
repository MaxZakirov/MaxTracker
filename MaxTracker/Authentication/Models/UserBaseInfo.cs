using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Authentication.Models
{
	public abstract class UserBaseInfo
	{
		[Required]
		public string Email { get; set; }
	}
}