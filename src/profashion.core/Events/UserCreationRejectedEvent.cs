namespace profashion.core.Events
{
    public class UserCreationRejectedEvent : IRejectedEvent
    {
        public string Email { get; }
        public string Message { get; }
        public string Code { get; }

        protected UserCreationRejectedEvent()
        {
        }

        public UserCreationRejectedEvent(string email, string message, string code)
        {
            Email = email;
            Message = message;
            Code = code;
        }
    }
}