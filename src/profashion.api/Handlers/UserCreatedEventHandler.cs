using System;
using System.Threading.Tasks;
using profashion.core.Events;

namespace profashion.api.Handlers
{
    public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        public async Task HandleAsync(UserCreatedEvent @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"UserCreatedEventHandler :: {@event.Email}");
        }
    }
}