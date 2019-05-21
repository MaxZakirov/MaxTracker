using MaxTracker.Authentication.Models;

namespace MaxTracker.Authentication.Queries
{
	public interface IAuthenticateQuery
	{
		UserLoginModel UserLoginInfo { get; set; }

		UserAuthenticationInfoViewModel Execute();
	}
}
