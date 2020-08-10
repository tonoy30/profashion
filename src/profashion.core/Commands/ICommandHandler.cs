using System.Threading.Tasks;

namespace profashion.core.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}