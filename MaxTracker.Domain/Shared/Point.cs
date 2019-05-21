namespace MaxTracker.Domain.Shared
{
	public class Point
	{
		public Point()
		{
			this.X = 0;
			this.Y = 0;
		}

		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public int X { get; set; }

		public int Y { get; set; }
	}
}
