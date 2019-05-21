using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Rooms.Exceptions;
using MaxTracker.Domain.Users;
using MaxTracker.Rooms.Commands;
using MaxTracker.Rooms.Exceptions;
using MaxTracker.Rooms.Models;
using MaxTracker.Rooms.Queries;
using MaxTracker.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxTracker.Controllers
{
	[EnableCors]
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(Roles = Roles.Admin)]
	public class RoomsController : ControllerBase
	{
		private readonly IGetAllRoomsQuery getAllRoomsQuery;
		private readonly ICreateRoomCommand createRoomCommand;
		private readonly IUpdateRoomCommand updateRoomCommand;
		private readonly IDeleteRoomCommand deleteRoomCommand;

		public RoomsController(
			IGetAllRoomsQuery getAllRoomsQuery,
			ICreateRoomCommand createRoomCommand,
			IUpdateRoomCommand updateRoomCommand,
			IDeleteRoomCommand deleteRoomCommand)
		{
			this.getAllRoomsQuery = getAllRoomsQuery;
			this.createRoomCommand = createRoomCommand;
			this.updateRoomCommand = updateRoomCommand;
			this.deleteRoomCommand = deleteRoomCommand;
		}

		[HttpGet]
		public IEnumerable<RoomViewModel> GetAll()
		{
			var rooms = this.getAllRoomsQuery.Execute();
			return rooms.Select(r => Mapper.Map<RoomViewModel>(r));
		}

		[HttpPost]
		public IActionResult Create([FromBody] RoomViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest("Model is not valid");
			try
			{
				this.createRoomCommand.RoomModel = RoomBuilder.BuildFromInfo(viewModel);
				this.createRoomCommand.Execute();
				return this.Ok();
			}
			catch(DoorsAreNotInWallsException)
			{
				return BadRequest("Doors coordinates are invalid");
			}
			catch (DuplicatedKeyException)
			{
				return BadRequest("Room with this number already exists");
			}
			catch (RoomIsIntersectedWithExisting)
			{
				return BadRequest("Room is interssected with other room on this floor");
			}
		}

		[HttpPut]
		public IActionResult Update([FromBody] RoomViewModel viewModel)
		{
			if(!ModelState.IsValid)
				return BadRequest("Model is not valid");

			try
			{
				this.updateRoomCommand.RoomModel = RoomBuilder.BuildFromInfo(viewModel);
				this.updateRoomCommand.Execute();
				return this.Ok();
			}
			catch (DoorsAreNotInWallsException)
			{
				return BadRequest("Doors coordinates are invalid");
			}
			catch (DuplicatedKeyException)
			{
				return BadRequest("Room with this number already exists");
			}
			catch (RoomIsIntersectedWithExisting)
			{
				return BadRequest("Room is interssected with other room on this floor");
			}
		}

		[HttpDelete("{number}")]
		public IActionResult Delete(int number)
		{
			this.deleteRoomCommand.Number = number;
			this.deleteRoomCommand.Execute();
			return this.Ok();
		}
	}
}