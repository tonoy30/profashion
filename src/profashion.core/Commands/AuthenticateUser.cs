namespace profashion.core.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}