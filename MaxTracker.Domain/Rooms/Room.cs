using MaxTracker.Domain.Rooms.Exceptions;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public class Room : MapObject
	{
		internal Room(int number,
			int floor,
			Point coordinates,
			int length,
			int width)
			: base(coordinates,width,length)
		{
			this.Number = number;
			this.Floor = floor;
		}

		public int Number { get; private set; }

		public int Floor { get; private set; }

		public Doors Doors { get; private set; }

		public void SetDoors(Doors doors)
		{
			if (this.PointBelongToWalls(doors.StartPoint) &&
				this.PointBelongToWalls(doors.EndPoint))
			{
				this.Doors = doors;
			}
			else
			{
				throw new DoorsAreNotInWallsException();
			}
		}

		private bool PointBelongToWalls(Point p)
		{
			if (p.X == this.Coordinates.X || p.X == this.Coordinates.X + this.Width)
				return p.Y >= this.Coordinates.Y && p.Y <= this.Coordinates.Y + this.Length;

			if (p.Y == this.Coordinates.Y || p.Y == this.Coordinates.Y + this.Length)
				return p.X >= this.Coordinates.X && p.X <= this.Coordinates.X + this.Width;

			return false;
		}

		public bool RoomIsInterscted(Room room)
		{
			if (room.Floor != this.Floor)
				return false;

			return base.ObjectIsInterscted(room);
		}

		public bool RoomIsInterscted(Stairs stairs)
		{
			if (stairs.StartFloor > this.Floor || stairs.EndFloor < this.Floor)
				return false;

			return base.ObjectIsInterscted(stairs);
		}
	}
}
