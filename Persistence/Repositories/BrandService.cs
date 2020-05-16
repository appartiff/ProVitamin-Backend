using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Product;
using MongoDB.Driver;
using Persistence.Configurations;

namespace Persistence.Repositories
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brands;
        
        public BrandService(IProvitaminDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _brands = database.GetCollection<Brand>(settings.BrandsCollectionName);
            var notificationLogBuilder = Builders<Brand>.IndexKeys;
            var indexModel = new CreateIndexModel<Brand>(notificationLogBuilder.Ascending(x => x.Title),new CreateIndexOptions(){Unique = true});
            _brands.Indexes.CreateOne(indexModel);
        }
        
        public async Task<List<Brand>> Get() => await _brands.FindAsync(brand => true).Result.ToListAsync();
        public async Task<Brand> Get(string title) => await _brands.FindAsync(brand => brand.Title == title).Result.FirstOrDefaultAsync();
        public Brand Create(Brand brand)
        {
            _brands.InsertOne(brand);
            return brand;
        }
        public void Remove(string title) => _brands.DeleteOne(book => book.Title == title);
    }
}