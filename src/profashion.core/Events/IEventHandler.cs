using System.Threading.Tasks;

namespace profashion.core.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}