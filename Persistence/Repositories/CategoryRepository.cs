using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Persistence.Configurations;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;
        
        public CategoryRepository(IProvitaminDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _categories = database.GetCollection<Category>(settings.BrandsCollectionName);
            var notificationLogBuilder = Builders<Category>.IndexKeys;
            var indexModel = new CreateIndexModel<Category>(notificationLogBuilder.Ascending(x => x.Title),new CreateIndexOptions(){Unique = true});
            _categories.Indexes.CreateOne(indexModel);
        }
        
        public async Task<List<Category>> Get() => await _categories.FindAsync(brand => true).Result.ToListAsync();
        public async Task<Category> Get(string id) => await _categories.FindAsync(brand => brand.Id == id).Result.FirstOrDefaultAsync();
        public async Task<Category> Create(Category category)
        {
           await _categories.InsertOneAsync(category);
            return category;
        }
        public async Task<Category> Remove(Category category)
        {
            await _categories.DeleteOneAsync(book => book.Id == category.Id);
            return category;
        }
    }
}