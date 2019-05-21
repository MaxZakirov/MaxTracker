namespace MaxTracker.Authentication.Models
{
	public class UserAuthenticationInfoViewModel : UserBaseInfo
	{
		public  string Name { get; set; }

		public string Token { get; set; }

		public string Role { get; set; }
	}
}
