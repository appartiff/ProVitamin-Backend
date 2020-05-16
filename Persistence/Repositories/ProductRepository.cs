using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using MongoDB.Driver;
using Persistence.Configurations;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IProvitaminDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductsCollectionName);
            var notificationLogBuilder = Builders<Product>.IndexKeys;
            var indexModel = new CreateIndexModel<Product>(notificationLogBuilder.Ascending(x => x.Sku),new CreateIndexOptions(){Unique = true});
            _products.Indexes.CreateOne(indexModel);
        }
        
        public async Task<List<Product>> Get() => await _products.FindAsync(book => true).Result.ToListAsync();
        public async Task<Product> Get(string id) => await _products.FindAsync(book => book.Details.Title == id).Result.FirstOrDefaultAsync();
        public Product Create(Product book)
        {
            _products.InsertOne(book);
            return book;
        }
        public void Update(string id, Product bookIn) => _products.ReplaceOne(book => book.Details.Title == id, bookIn);
        
        public void Remove(Product bookIn) => _products.DeleteOne(book => book.Details.Title == bookIn.Details.Title);
        public void Remove(string id) => _products.DeleteOne(book => book.Details.Title == id);
    }
}