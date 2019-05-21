using System;
using AutoMapper;
using MaxTracker.Authentication.Exceptions;
using MaxTracker.Authentication.Helpers;
using MaxTracker.Authentication.Models;
using MaxTracker.Domain.Users;
using MaxTracker.Domain.Users.Authentication;
using MaxTracker.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MaxTracker.Authentication.Commands
{
	public class CheckInCommand : ICheckInCommand
	{
		private readonly IUserRepository userRepository;
		private AppSettings appSettings;

		public UserCheckinModel CheckinModel { get; set; }

		public CheckInCommand(
			IUserRepository userRepository,
			IOptions<AppSettings> appSettings)
		{
			this.userRepository = userRepository;
			this.appSettings = appSettings.Value;
		}

		public UserAuthenticationInfoViewModel Execute()
		{
			User user = Mapper.Map<User>(this.CheckinModel);
			user.Role = Roles.User;
			user.IsBanned = false;

			try
			{
				this.userRepository.Create(user);
			}
			catch (MongoWriteException ex)
			{
				throw new DuplicateLoginException($"User with login {user.Email} already exist.");
			}

			var userViewModel = new UserAuthenticationInfoViewModel
			{
				Name = user.FirstName,
				Email = user.Email,
				Role = user.Role.ToString()
			};

			userViewModel.CreateToken(this.appSettings.Secret);

			return userViewModel;
		}
	}
}
