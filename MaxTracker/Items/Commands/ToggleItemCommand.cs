using System;
using System.Collections.Generic;
using MaxTracker.Domain.Items;
using MaxTracker.Items.Exceptions;

namespace MaxTracker.Items.Commands
{
	public class ToggleItemCommand : IToggleItemCommand
	{
		private readonly IItemRepository itemRepository;

		public ToggleItemCommand(IItemRepository itemRepository)
		{
			this.itemRepository = itemRepository;
		}

		public Guid ItemId { get; set; }

		public int RoomNumber { get; set; }

		public void Execute()
		{
			var item = this.itemRepository.GetById(this.ItemId);

			if (item == null)
				throw new KeyNotFoundException();

			if (item.RoomNumber != -1)
			{
				if (item.RoomNumber != this.RoomNumber)
					throw new InvalidToggleRoomException();

				item.RoomNumber = -1;
			}
			else
			{
				item.RoomNumber = this.RoomNumber;
			}

			this.itemRepository.Update(item);
		}
	}
}
