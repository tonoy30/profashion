using System.Collections.Generic;
using System.Threading.Tasks;
using profashion.business.Models;

namespace profashion.business.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync(T tModel);
        Task<bool> UpdateASync(T tModel);
        Task<bool> DeleteAsync(string id);
    }
}