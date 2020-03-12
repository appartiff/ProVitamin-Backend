namespace Provitamin.Persistence.Configurations
{
    public interface IProvitaminDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

    public class ProvitaminDatabaseSettings : IProvitaminDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}