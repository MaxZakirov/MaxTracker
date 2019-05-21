using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Rooms.Exceptions;
using MaxTracker.Domain.Users;
using MaxTracker.Rooms.Exceptions;
using MaxTracker.Rooms.Stairs.Commands;
using MaxTracker.Rooms.Stairs.Models;
using MaxTracker.Rooms.Stairs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxTracker.Controllers
{
	[EnableCors]
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(Roles = Roles.Admin)]
	public class StairsController : ControllerBase
	{
		private readonly IGetAllStairsQuery getAllStairsQuery;
		private readonly ICreateStairsCommand createStairs;
		private readonly IUpdateStairsCommand updateStairsCommand;
		private readonly IDeleteStairsCommand deleteStairsCommand;

		public StairsController(
			IGetAllStairsQuery getAllStairsQuery,
			ICreateStairsCommand createStairs,
			IUpdateStairsCommand updateStairsCommand,
			IDeleteStairsCommand deleteStairsCommand)
		{
			this.getAllStairsQuery = getAllStairsQuery;
			this.createStairs = createStairs;
			this.updateStairsCommand = updateStairsCommand;
			this.deleteStairsCommand = deleteStairsCommand;
		}

		[HttpGet]
		public IEnumerable<StairsViewModel> GetAll()
		{
			var stairs = this.getAllStairsQuery.Execute();
			return stairs.Select(r => Mapper.Map<StairsViewModel>(r));
		}

		[HttpPost]
		public IActionResult Create([FromBody] StairsViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
				return this.BadRequest("Model is not valid");
			try
			{
				this.createStairs.StairsToCreate = Mapper.Map<Stairs>(viewModel);
				this.createStairs.Execute();
				return this.Ok();
			}
			catch (RoomIsIntersectedWithExisting)
			{
				return this.BadRequest("Stairs conflicts with other objects");
			}
			catch (InvalidStairsFloorsException)
			{
				return this.BadRequest("End floor con not be bigger then start floor");
			}
		}

		[HttpPut]
		public IActionResult Update([FromBody] StairsViewModel viewModel)
		{
			if (!this.ModelState.IsValid ||
				!viewModel.Id.HasValue)
				return this.BadRequest("Model is not valid");

			try
			{
				var domainModel = new Stairs(
					viewModel.Coordinates,
					viewModel.Width,
					viewModel.Length,
					viewModel.Id.Value,
					viewModel.StartFloor,
					viewModel.EndFloor);

				this.updateStairsCommand.StairsToUpdate = domainModel;
				this.updateStairsCommand.Execute();
				return this.Ok();
			}
			catch (RoomIsIntersectedWithExisting)
			{
				return this.BadRequest("Stairs conflicts with other objects");
			}
			catch (InvalidStairsFloorsException)
			{
				return this.BadRequest("Stairs floors are invalid");
			}
		}

		[HttpDelete("{stairsId}")]
		public IActionResult Delete(string stairsId)
		{
			Guid stairsDomainId = Guid.Parse(stairsId);
			this.deleteStairsCommand.StairsId = stairsDomainId;
			this.deleteStairsCommand.Execute();
			return this.Ok();
		}
	}
}
