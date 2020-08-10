using profashion.core.Commands;
using profashion.core.Services;
using System.Threading.Tasks;

namespace profashion.services.identity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateUserCommand>()
                .Build()
                .RunAsync();
        }
    }
}