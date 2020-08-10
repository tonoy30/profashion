namespace profashion.core.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        string UserId { get; set; }
    }
}