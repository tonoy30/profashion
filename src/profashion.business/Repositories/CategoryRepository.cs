using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using profashion.business.Models;

namespace profashion.business.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Category> GetAsync(string name)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task SaveAsync(Category category)
            => await Collection.InsertOneAsync(category);

        public async Task<bool> UpdateASync(Category category)
        {
            var result = await Collection.ReplaceOneAsync(x => x.Id == category.Id, category);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await Collection.DeleteOneAsync(x => x.Id == id);
            return result.IsAcknowledged;
        }

        private IMongoCollection<Category> Collection => _database.GetCollection<Category>(nameof(Category));
    }
}