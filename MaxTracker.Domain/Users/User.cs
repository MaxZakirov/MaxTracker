namespace MaxTracker.Domain.Users.Authentication
{
	public class User
	{
		public User()
		{
			this.Role = Roles.User;
		}

		public string Password { get; set; }

		public string Role { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public string PhotoPath { get; set; }

		public bool IsBanned { get; set; }
	}
}
