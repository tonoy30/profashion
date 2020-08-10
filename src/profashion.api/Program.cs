using profashion.core.Events;
using profashion.core.Services;
using System.Threading.Tasks;

namespace profashion.api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreatedEvent>()
                .SubscribeToEvent<UserCreatedEvent>()
                .Build()
                .RunAsync();
        }
    }
}