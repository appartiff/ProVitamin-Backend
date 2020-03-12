
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Provitamin.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Sku { get; set; }
        public decimal Title { get; set; }
        public string Category { get; set; }
    }
}