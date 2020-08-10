using System;
using System.Threading.Tasks;
using profashion.core.Commands;
using profashion.core.Events;
using RawRabbit;

namespace profashion.services.activities.Handlers
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IBusClient _busClient;

        public CreateActivityCommandHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateActivityCommand command)
        {
            Console.WriteLine($"{DateTime.Now} --> {nameof(ActivityCreatedEvent)}");
            await _busClient.PublishAsync(new ActivityCreatedEvent(command.Id, command.Id, command.Category,
                command.Name, command.Description, command.CreatedAt));
        }
    }
}