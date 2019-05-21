using System.Collections.Generic;
using MaxTracker.Domain.Users;
using MaxTracker.Users.Commands;
using MaxTracker.Users.Models;
using MaxTracker.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxTracker.Controllers
{
	[EnableCors]
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(Roles = Roles.Admin)]
	public class UsersController : ControllerBase
	{
		private readonly IGetAllUsersQuery getAllUsersQuery;
		private readonly IUnbanUserCommand unbanUserCommand;
		private readonly IBanUserCommand banUserCommand;
		private readonly ISetNewRoleToUserCommand setNewRoleToUserCommand;

		public UsersController(
			IGetAllUsersQuery getAllUsersQuery,
			IUnbanUserCommand unbanUserCommand,
			IBanUserCommand banUserCommand,
			ISetNewRoleToUserCommand setNewRoleToUserCommand)
		{
			this.getAllUsersQuery = getAllUsersQuery;
			this.unbanUserCommand = unbanUserCommand;
			this.banUserCommand = banUserCommand;
			this.setNewRoleToUserCommand = setNewRoleToUserCommand;
		}

		// GET: api/Users
		[HttpGet]
		public IEnumerable<UserViewModel> Get()
		{
			return this.getAllUsersQuery.Execute();
		}

		[HttpPut("{email}")]
		public void BanUser(string email)
		{
			this.banUserCommand.Email = email;
			this.banUserCommand.Execute();
		}

		[HttpPut("{email}")]
		public void PromoteToResponsible(string email)
		{
			this.setNewRoleToUserCommand.UserEmail = email;
			this.setNewRoleToUserCommand.NewRole = Roles.Responsible;
			this.setNewRoleToUserCommand.Execute();
		}

		[HttpPut("{email}")]
		public void DowngradeUserRole(string email)
		{
			this.setNewRoleToUserCommand.UserEmail = email;
			this.setNewRoleToUserCommand.NewRole = Roles.User;
			this.setNewRoleToUserCommand.Execute();
		}

		[HttpPut("{email}")]
		public void UnbanUser(string email)
		{
			this.unbanUserCommand.Email = email;
			this.unbanUserCommand.Execute();
		}
	}
}
