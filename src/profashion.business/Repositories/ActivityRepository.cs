using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using profashion.business.Models;

namespace profashion.business.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(string id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Activity>> GetAllAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task SaveAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task<bool> UpdateASync(Activity activity)
        {
            var result = await Collection.ReplaceOneAsync(x => x.Id == activity.Id, activity);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await Collection.DeleteOneAsync(x => x.Id == id);
            return result.IsAcknowledged;
        }

        private IMongoCollection<Activity> Collection => _database.GetCollection<Activity>(nameof(Activity));
    }
}