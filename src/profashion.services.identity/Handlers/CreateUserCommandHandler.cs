using System;
using System.Threading.Tasks;
using profashion.core.Commands;
using profashion.core.Events;
using RawRabbit;

namespace profashion.services.identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IBusClient _busClient;

        public CreateUserCommandHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            Console.WriteLine($"{DateTime.Now} --> {nameof(UserCreatedEvent)}");
            await _busClient.PublishAsync(new UserCreatedEvent(command.Email, command.UserName));
        }
    }
}