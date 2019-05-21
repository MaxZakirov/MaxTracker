using MaxTracker.Authentication.Exceptions;
using MaxTracker.Authentication.Helpers;
using MaxTracker.Authentication.Models;
using MaxTracker.Domain.Users.Authentication;
using MaxTracker.Settings;
using Microsoft.Extensions.Options;

namespace MaxTracker.Authentication.Queries
{
	public class AuthenticateQuery : IAuthenticateQuery
	{
		private readonly IUserRepository userRepository;
		private readonly AppSettings appSettings;

		public UserLoginModel UserLoginInfo { get; set; }

		public AuthenticateQuery(IUserRepository userRepository, 
			IOptions<AppSettings> appSettings)
		{
			this.userRepository = userRepository;
			this.appSettings = appSettings.Value;
		}


		public UserAuthenticationInfoViewModel Execute()
		{
			Domain.Users.Authentication.User domainUser = this.userRepository.GetByCredentials(this.UserLoginInfo.Email, this.UserLoginInfo.Password);

			if (domainUser.IsBanned)
				throw new UserIsBannedException();

			if (domainUser == null)
				throw new UserNotFoundException();

			var userViewModel = new UserAuthenticationInfoViewModel
			{
				Name = domainUser.FirstName,
				Email = this.UserLoginInfo.Email,
				Role = domainUser.Role.ToString()
			};

			userViewModel.CreateToken(this.appSettings.Secret);

			return userViewModel;
		}
	}
}
