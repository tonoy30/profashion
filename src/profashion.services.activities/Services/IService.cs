using System.Threading.Tasks;

namespace profashion.services.activities.Services
{
    public interface IService<in T> where T : class
    {
        Task AddAsync(T model);
    }
}