using System;
using MaxTracker.Domain.Rooms.Exceptions;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public class Stairs : MapObject
	{
		public Stairs(
			Point coordinates,
			int width,
			int length,
			Guid id,
			int startFloor,
			int endFloor)
			: base(coordinates, width, length)
		{
			if (startFloor >= endFloor)
			{
				throw new InvalidStairsFloorsException();
			}

			this.Id = id;
			this.StartFloor = startFloor;
			this.EndFloor = endFloor;
		}

		public Guid Id { get; private set; }

		public int StartFloor { get; private set; }

		public int EndFloor { get; private set; }

		public bool StairsAreIntersected(Stairs stairs)
		{
			if (stairs.EndFloor < this.StartFloor
				|| stairs.StartFloor > this.EndFloor)
				return false;

			return base.ObjectIsInterscted(stairs);
		}

		public void InitializeId()
		{
			if (this.Id != Guid.Empty)
				throw new CanNotInitializeStairsIdException();

			this.Id = Guid.NewGuid();
		}
	}
}
