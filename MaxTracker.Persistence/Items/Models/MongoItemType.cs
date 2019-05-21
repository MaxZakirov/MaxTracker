using MongoDB.Bson.Serialization.Attributes;

namespace MaxTracker.Persistence.Items.Models
{
	public class MongoItemType
	{
		[BsonId]
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
