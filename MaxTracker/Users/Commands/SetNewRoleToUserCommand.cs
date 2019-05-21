using MaxTracker.Domain.Users.Authentication;

namespace MaxTracker.Users.Commands
{
	public class SetNewRoleToUserCommand : ISetNewRoleToUserCommand
	{
		private readonly IUserRepository userRepository;

		public SetNewRoleToUserCommand(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public string NewRole { get; set; }

		public string UserEmail { get; set; }

		public void Execute()
		{
			this.userRepository.ChangeRole(this.UserEmail, this.NewRole);
		}
	}
}
