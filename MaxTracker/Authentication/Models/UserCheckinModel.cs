using System.ComponentModel.DataAnnotations;

namespace MaxTracker.Authentication.Models
{
	public class UserCheckinModel : UserBaseInfo
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		public string PhotoPath { get; set; }
	}
}
