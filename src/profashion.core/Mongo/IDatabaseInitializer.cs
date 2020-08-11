using System.Threading.Tasks;

namespace profashion.core.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}