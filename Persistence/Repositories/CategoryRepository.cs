using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
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
        public async Task<Category> Get(string title) => await _categories.FindAsync(brand => brand.Title == title).Result.FirstOrDefaultAsync();
        public Category Create(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }
        public void Remove(string title) => _categories.DeleteOne(book => book.Title == title);
    }
}