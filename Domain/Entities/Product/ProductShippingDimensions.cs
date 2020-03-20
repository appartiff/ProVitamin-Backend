using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Product
{
    public class ProductShippingDimensions
    {
        
        [BsonElement("height")]
        public int Height { get; set; }
        [BsonElement("width")]
        public int Width { get; set; }
        [BsonElement("depth")]
        public int Depth { get; set; }
    }
}