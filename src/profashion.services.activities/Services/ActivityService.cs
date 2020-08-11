using System.Threading.Tasks;
using profashion.business.Models;
using profashion.business.Repositories;
using profashion.core.Exceptions;

namespace profashion.services.activities.Services
{
    public class ActivityService : IService<Activity>
    {
        private readonly IRepository<Activity> _activityRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ActivityService(IRepository<Activity> activityRepository, IRepository<Category> categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Activity model)
        {
            var category = await _categoryRepository.GetAsync(model.Category.Name);
            if (category == null)
            {
                throw new CommonException("category_not_found", $"Category: {model.Name} was not found");
            }

            var activity = new Activity(model.UserId, model.Category.Name, model.Name, model.Description,
                model.CreatedAt);
            await _activityRepository.SaveAsync(activity);
        }
    }
}