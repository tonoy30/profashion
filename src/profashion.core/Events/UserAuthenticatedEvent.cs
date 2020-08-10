namespace profashion.core.Events
{
    public class UserAuthenticatedEvent : IEvent
    {
        public string Email { get; }

        protected UserAuthenticatedEvent()
        {
        }

        public UserAuthenticatedEvent(string email, string userName)
        {
            Email = email;
        }
    }
}