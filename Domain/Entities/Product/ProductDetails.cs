using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Product
{
    [BsonIgnoreExtraElements]
    public class ProductDetails
    {
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }
    }
}