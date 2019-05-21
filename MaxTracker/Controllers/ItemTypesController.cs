using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Items;
using MaxTracker.Domain.Users;
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
	public class ItemTypesController : ControllerBase
	{
		private readonly IGetAllItemTypesQuery getAllItemTypesQuery;

		public ItemTypesController(
			IGetAllItemTypesQuery getAllItemTypesQuery)
		{
			this.getAllItemTypesQuery = getAllItemTypesQuery;
		}

		[HttpGet]
		public IEnumerable<ItemTypeViewModel> GetAll()
		{
			IEnumerable<ItemType> itemtypes = this.getAllItemTypesQuery.Execute();
			return itemtypes.Select(r => Mapper.Map<ItemTypeViewModel>(r));
		}
	}
}