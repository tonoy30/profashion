using profashion.core.Events;
using System;
using System.Threading.Tasks;

namespace profashion.api.Handlers
{
    public class ActivityCreatedEventHandler : IEventHandler<ActivityCreatedEvent>
    {
        public async Task HandleAsync(ActivityCreatedEvent @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"ActivityCreatedEventHandler:: {@event.Name}");
        }
    }
}