namespace profashion.core.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}