using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using profashion.core.Commands;
using profashion.core.Events;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;

namespace profashion.core.RabbitMQ
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient busClient,
            ICommandHandler<TCommand> handler)
            where TCommand : ICommand => busClient.SubscribeAsync<TCommand>(handler.HandleAsync,
            ctx => ctx.UseConsumeConfiguration(cfg =>
                cfg.FromQueue(GetQueueName<TCommand>())));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient busClient, IEventHandler<TEvent> handler)
            where TEvent : IEvent => busClient.SubscribeAsync<TEvent>(handler.HandleAsync,
            ctx => ctx.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TEvent>())));

        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly()?.GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection(nameof(RabbitMqOptions));
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions {ClientConfiguration = options});
            service.AddSingleton<IBusClient>(_ => client);
        }
    }
}