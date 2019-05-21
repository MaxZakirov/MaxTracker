using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Rooms
{
	public interface IDoorsInfo
	{
		Point StartPoint { get; set; }

		Point EndPoint { get; set; }
	}
}
