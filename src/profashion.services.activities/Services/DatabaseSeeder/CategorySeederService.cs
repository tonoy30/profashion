using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using profashion.business.Models;
using profashion.business.Repositories;
using profashion.core.Mongo;

namespace profashion.services.activities.Services.DatabaseSeeder
{
    public class CategorySeederService : MongoSeeder
    {
        private readonly IRepository<Category> _repository;

        public CategorySeederService(IMongoDatabase database, IRepository<Category> repository) : base(database)
        {
            _repository = repository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string> {"work", "hobby", "sports"};
            await Task.WhenAll(categories.Select(x => _repository.SaveAsync(new Category(x))));
        }
    }
}