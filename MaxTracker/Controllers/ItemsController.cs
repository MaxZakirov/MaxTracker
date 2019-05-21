using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Items;
using MaxTracker.Domain.Users;
using MaxTracker.Items.Commands;
using MaxTracker.Items.Exceptions;
using MaxTracker.Items.Models;
using MaxTracker.Items.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxTracker.Controllers
{
	[EnableCors]
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(Roles = Roles.Admin)]
	public class ItemsController : ControllerBase
	{
		private readonly IGetAllItemsQuery getAllItemsQuery;
		private readonly ICreateItemCommand createItemCommand;
		private readonly IUpdateItemCommand updateItemCommand;
		private readonly IDeleteItemCommand deleteItemCommand;
		private readonly IToggleItemCommand toggleItemCommand;

		public ItemsController(
			IGetAllItemsQuery getAllItemsQuery,
			ICreateItemCommand createItemCommand,
			IUpdateItemCommand updateItemCommand,
			IDeleteItemCommand deleteItemCommand,
			IToggleItemCommand toggleItemCommand)
		{
			this.getAllItemsQuery = getAllItemsQuery;
			this.createItemCommand = createItemCommand;
			this.updateItemCommand = updateItemCommand;
			this.deleteItemCommand = deleteItemCommand;
			this.toggleItemCommand = toggleItemCommand;
		}

		[HttpGet]
		public IEnumerable<ItemViewModelInfo> GetAll()
		{
			IEnumerable<Item> items = this.getAllItemsQuery.Execute();
			return items.Select(i => Mapper.Map<ItemViewModel>(i));
		}

		[HttpPost]
		public IActionResult Create([FromBody] CreateItemViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
				return this.BadRequest("Model is not valid");

			this.createItemCommand.ItemToCreate = new Item() { 
				TypeId = viewModel.TypeId,
				Name = viewModel.Name,
				RoomNumber = viewModel.RoomNumber,
				ResponsibleEmail = viewModel.ResponsibleEmail
				};
			this.createItemCommand.Execute();
			return this.Ok();
		}

		[AllowAnonymous]
		[HttpPut]
		public IActionResult ToggleItemRoom([FromBody] ToggleItemRoomModel toggleModel)
		{
			if (!ModelState.IsValid)
				return BadRequest("Model is not valid");

			try
			{
				this.toggleItemCommand.ItemId = toggleModel.ItemId;
				this.toggleItemCommand.RoomNumber = toggleModel.RoomNumber;
				this.toggleItemCommand.Execute();
				return this.Ok();
			}
			catch(KeyNotFoundException)
			{
				return BadRequest("Wrong item Id");
			}
			catch (InvalidToggleRoomException)
			{
				return BadRequest("Wrong room number");
			}
		}

		[HttpPut]
		public IActionResult Update([FromBody] ItemViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return BadRequest("Model is not valid");

			this.updateItemCommand.ItemToUpdate = Mapper.Map<Item>(viewModel);
			this.updateItemCommand.Execute();
			return this.Ok();
		}

		[HttpDelete("{stringId}")]
		public IActionResult Delete(string stringId)
		{
			Guid itemId = Guid.Parse(stringId);
			if (itemId == Guid.Empty)
				return BadRequest("Model is not valid");

			this.deleteItemCommand.ItemId = itemId;
			this.deleteItemCommand.Execute();
			return this.Ok();
		}
	}
}