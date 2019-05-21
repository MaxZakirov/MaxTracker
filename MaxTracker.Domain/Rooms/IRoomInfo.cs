using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public interface IRoomInfo
	{
		int Number { get; }

		int Width { get; }

		int Length { get; }

		Point Coordinates { get; }

		int Floor { get; }

		IDoorsInfo Doors { get; }
	}
}
