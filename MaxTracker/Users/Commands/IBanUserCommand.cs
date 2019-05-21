namespace MaxTracker.Users.Commands
{
	public interface IBanUserCommand
	{
		string Email { get; set; }

		void Execute();
	}
}
