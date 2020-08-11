using System.Threading.Tasks;

namespace profashion.core.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}