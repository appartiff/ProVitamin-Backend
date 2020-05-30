using System.Collections.Generic;
using System.Threading;
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
        
        public async Task<List<Product>> Get(CancellationToken cancellationToken)
        {
            return await _products.FindAsync(book => true).Result.ToListAsync();
        }

        public async Task<Product> Get(string id,CancellationToken cancellationToken) => await _products.FindAsync(book => book.Id == id).Result.FirstOrDefaultAsync();
        public async Task<Product> Create(Product book, CancellationToken cancellationToken)
        {
            await _products.InsertOneAsync(book,cancellationToken);
            return book;
        }
        public async Task<string> Update(Product productIn,CancellationToken cancellationToken)
        {
            await _products.ReplaceOneAsync(product => product.Id == productIn.Id, productIn);
            return productIn.Id;
        }

        public async Task<string> Remove(Product productIn,CancellationToken cancellationToken)
        {
            await _products.DeleteOneAsync(product => product.Id == productIn.Id,cancellationToken);
            return productIn.Id;
        }

        public async Task<string> Remove(string id,CancellationToken cancellationToken)
        {
           await _products.DeleteOneAsync(product => product.Id == id,cancellationToken);
           return id;
        }
    }
}