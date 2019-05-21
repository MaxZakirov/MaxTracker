using MongoDB.Bson.Serialization.Attributes;

namespace MaxTracker.Persistence.Authentication.Modelds
{
	public class MongoUserModel
	{
		[BsonId]
		public string Email { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public string PhotoPath { get; set; }

		public bool IsBanned { get; set; }

		public string PhoneNumber { get; set; }
	}
}
