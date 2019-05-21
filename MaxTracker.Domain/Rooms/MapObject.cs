using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public abstract class MapObject
	{
		public MapObject(Point coordinates, int width,
			int length)
		{
			this.Coordinates = coordinates;
			this.Width = width;
			this.Length = length;
		}

		public int Width { get; protected set; }

		public int Length { get; protected set; }

		public Point Coordinates { get; protected set; }

		protected bool ObjectIsInterscted(MapObject mapObject)
		{
			bool resultFlag = false;
			Point roomCoordinates = mapObject.Coordinates;
			if (this.Coordinates.X < roomCoordinates.X)
			{
				resultFlag = roomCoordinates.X < this.Coordinates.X + this.Width;
			}
			else
			{
				resultFlag = this.Coordinates.X < roomCoordinates.X + mapObject.Width;
			}

			if (resultFlag is true)
			{
				if (this.Coordinates.Y < roomCoordinates.Y)
				{
					resultFlag = roomCoordinates.Y < this.Coordinates.Y + this.Length;
				}
				else
				{
					resultFlag = this.Coordinates.Y < roomCoordinates.Y + mapObject.Length;
				}
			}

			return resultFlag;
		}
	}
}
