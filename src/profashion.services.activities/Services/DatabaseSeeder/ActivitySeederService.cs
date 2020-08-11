using System.Threading.Tasks;
using MongoDB.Driver;
using profashion.business.Models;
using profashion.business.Repositories;
using profashion.core.Mongo;

namespace profashion.services.activities.Services.DatabaseSeeder
{
    public class ActivitySeederService : MongoSeeder
    {
        private readonly IRepository<Activity> _repository;

        public ActivitySeederService(IMongoDatabase database, IRepository<Activity> repository) : base(database)
        {
            _repository = repository;
        }

        protected override async Task CustomSeedAsync()
        {
            await base.CustomSeedAsync();
        }
    }
}