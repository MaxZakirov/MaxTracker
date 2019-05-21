namespace MaxTracker.Users.Commands
{
	public interface ISetNewRoleToUserCommand
	{
		string NewRole { get; set; }

		string UserEmail { get; set; }

		void Execute();
	}
}
