using MaxTracker.Domain.Users.Authentication;

namespace MaxTracker.Users.Commands
{
	public class UnbanUserCommand : IUnbanUserCommand
	{
		private readonly IUserRepository userRepository;

		public UnbanUserCommand(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public string Email { get; set; }

		public void Execute()
		{
			this.userRepository.UnbanUser(this.Email);
		}
	}
}
