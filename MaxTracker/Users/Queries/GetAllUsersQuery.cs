using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaxTracker.Domain.Users.Authentication;
using MaxTracker.Users.Models;

namespace MaxTracker.Users.Queries
{
	public class GetAllUsersQuery : IGetAllUsersQuery
	{
		private readonly IUserRepository userRepository;

		public GetAllUsersQuery(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public IEnumerable<UserViewModel> Execute()
		{
			var users = userRepository.GetAll();
			return users.Select(u => Mapper.Map<UserViewModel>(u));
		}
	}
}
