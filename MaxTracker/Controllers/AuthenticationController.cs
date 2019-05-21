using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxTracker.Authentication.Commands;
using MaxTracker.Authentication.Exceptions;
using MaxTracker.Authentication.Models;
using MaxTracker.Authentication.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxTracker.Controllers
{
	[EnableCors]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticateQuery authenticateQuery;
		private readonly ICheckInCommand checkInCommand;

		public AuthenticationController(
			IAuthenticateQuery authenticateQuery,
			ICheckInCommand checkInCommand)
		{
			this.authenticateQuery = authenticateQuery;
			this.checkInCommand = checkInCommand;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult Authenticate([FromBody]UserLoginModel userParam)
		{
			authenticateQuery.UserLoginInfo = userParam;
			try
			{
				var userViewModel = authenticateQuery.Execute();
				return Ok(userViewModel);
			}
			catch(UserNotFoundException ex)
			{
				return BadRequest("The creadentials are wrong."); 
			}
			catch (UserIsBannedException ex)
			{
				return BadRequest("Your account is banned");
			}
		}

		[AllowAnonymous]
		[HttpPost("checkin")]
		public IActionResult CheckIn([FromBody]UserCheckinModel userParam)
		{
			checkInCommand.CheckinModel = userParam;
			try
			{
				var userViewModel = checkInCommand.Execute();
				return Ok(userViewModel);
			}
			catch (DuplicateLoginException ex)
			{
				return BadRequest("User with this login already exists.");
			}
		}
	}
}
