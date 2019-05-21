using MaxTracker.Domain.Rooms.Exceptions;
using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public class Doors
	{
		public Doors()
		{

		}

		public Point StartPoint { get; private set; }

		public Point EndPoint { get; private set; }

		public void SetStartPoint(Point point)
		{
			if(EndPoint == null || PointsAreInStraightLine(EndPoint, point))
			{
				StartPoint = point;
				return;
			}

			throw new DoorsCoorinatesAreInvalidException();
		}

		public void SetEndPoint(Point point)
		{
			if (StartPoint == null || PointsAreInStraightLine(StartPoint, point))
			{
				EndPoint = point;
				return;
			}

			throw new DoorsCoorinatesAreInvalidException();
		}

		private bool PointsAreInStraightLine(Point p1, Point p2)
		{
			if(p1.X == p2.X && p2.Y != p1.Y)
				return true;
			if (p1.X != p2.X && p2.Y == p1.Y)
				return true;

			return false;
		}
	}
}
