using System.Linq;
using AutoMapper;
using MaxTracker.Domain.Users.Authentication;
using MaxTracker.Persistence.Authentication.Modelds;
using MongoDB.Driver;

namespace MaxTracker.Persistence.Authentication
{
	public class MongoUserRepository : MongoRepository<User, MongoUserModel>, IUserRepository
	{
		public MongoUserRepository(
			IDbContext dbContext)
			: base(dbContext)
		{

		}

		public void BanUser(string email)
		{
			var filter = Builders<MongoUserModel>.Filter.Eq(u => u.Email, email);
			var definition = Builders<MongoUserModel>.Update.Set(u => u.IsBanned, true);
			this.entities.UpdateOne(filter, definition);
		}

		public void ChangeRole(string email, string newRole)
		{
			var filter = Builders<MongoUserModel>.Filter.Eq(u => u.Email, email);
			var definition = Builders<MongoUserModel>.Update.Set(u => u.Role, newRole.ToString());
			this.entities.UpdateOne(filter, definition);
		}

		public User GetByCredentials(string login, string password)
		{
			var queryResult = this.entities.Find<MongoUserModel>(u => u.Email == login && u.Password == password);

			if (!queryResult.Any())
				return null;

			var userModel = queryResult.Single();

			return Mapper.Map<User>(userModel);
		}

		public void UnbanUser(string email)
		{
			var filter = Builders<MongoUserModel>.Filter.Eq(u => u.Email, email);
			var definition = Builders<MongoUserModel>.Update.Set(u => u.IsBanned, false);
			this.entities.UpdateOne(filter, definition);
		}
	}
}
