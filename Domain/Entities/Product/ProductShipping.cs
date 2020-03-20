using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Product
{
    
    [BsonIgnoreExtraElements]
    public class ProductShipping
    {
        
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("dimensions")]
        public ProductShippingDimensions Dimensions { get; set; }
        
    }
}