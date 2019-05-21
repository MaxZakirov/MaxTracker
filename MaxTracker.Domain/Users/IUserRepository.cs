using MaxTracker.Domain.Shared;

namespace MaxTracker.Domain.Users.Authentication
{
	public interface IUserRepository : IRepository<User>
	{
		User GetByCredentials(string email, string password);

		void ChangeRole(string email, string newRole);

		void BanUser(string email);

		void UnbanUser(string email);
	}
}
