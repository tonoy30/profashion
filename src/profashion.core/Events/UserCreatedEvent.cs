namespace profashion.core.Events
{
    public class UserCreatedEvent : IEvent
    {
        public string Email { get; }
        public string UserName { get; }

        protected UserCreatedEvent()
        {
        }

        public UserCreatedEvent(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}