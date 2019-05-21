namespace MaxTracker.Domain.Rooms
{
	public static class RoomBuilder
	{
		public static Room BuildFromInfo(IRoomInfo roomInfo)
		{
			Room room = new Room(
				roomInfo.Number,
				roomInfo.Floor,
				roomInfo.Coordinates,
				roomInfo.Length,
				roomInfo.Width);

			Doors doors = new Doors();
			doors.SetStartPoint(roomInfo.Doors.StartPoint);
			doors.SetEndPoint(roomInfo.Doors.EndPoint);

			room.SetDoors(doors);

			return room;
		}
	}
}
