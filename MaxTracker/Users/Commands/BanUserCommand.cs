using MaxTracker.Domain.Users.Authentication;

namespace MaxTracker.Users.Commands
{
	public class BanUserCommand : IBanUserCommand
	{
		private readonly IUserRepository userRepository;

		public BanUserCommand(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public string Email { get; set; }

		public void Execute()
		{
			this.userRepository.BanUser(this.Email);
		}
	}
}
