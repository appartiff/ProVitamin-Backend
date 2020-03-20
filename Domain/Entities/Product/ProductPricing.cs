using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Product
{
    
    [BsonIgnoreExtraElements]
    public class ProductPricing
    {
        [BsonElement("list")]
        public double List { get; set; }
        [BsonElement("retail")]
        public double Retail { get; set; }
        [BsonElement("savings")]
        public double Savings { get; set; }
        [BsonElement("pctSavings")]
        public int PctSavings { get; set; }
    }
}