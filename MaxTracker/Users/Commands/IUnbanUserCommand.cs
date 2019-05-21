namespace MaxTracker.Users.Commands
{
	public interface IUnbanUserCommand
	{
		string Email { get; set; }

		void Execute();
	}
}
