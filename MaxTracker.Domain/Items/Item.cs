using System;
using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Users.Authentication;

namespace MaxTracker.Domain.Items
{
	public class Item
	{
		public Guid Id { get; set; }

		public int TypeId { get; set; }

		public ItemType Type { get; set; }

		public string Name { get; set; }

		public int RoomNumber { get; set; }

		public Room Room { get; set; }

		public User CurrentUser { get; set; }

		public string CurrentUserEmail { get; set; }

		public User Responsible { get; set; }

		public string ResponsibleEmail { get; set; }
	}
}
