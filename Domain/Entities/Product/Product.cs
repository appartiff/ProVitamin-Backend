using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Product
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("sku")]
        public string Sku { get; set; }
        [BsonElement("pricing")]
        public ProductPricing Pricing { get; set; }
        [BsonElement("details")]
        public ProductDetails Details { get; set; }
    }
}