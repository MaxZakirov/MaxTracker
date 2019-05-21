using System.Collections.Generic;
using MaxTracker.Users.Models;

namespace MaxTracker.Users.Queries
{
	public interface IGetAllUsersQuery
	{
		IEnumerable<UserViewModel> Execute();
	}
}
