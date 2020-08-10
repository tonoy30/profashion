using profashion.core.Commands;
using profashion.core.Services;
using System.Threading.Tasks;

namespace profashion.services.activities
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateActivityCommand>()
                .Build()
                .RunAsync();
        }
    }
}