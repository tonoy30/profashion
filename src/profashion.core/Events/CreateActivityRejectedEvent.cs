namespace profashion.core.Events
{
    public class CreateActivityRejectedEvent : IRejectedEvent
    {
        public string Id { get; set; }
        public string Message { get; }
        public string Code { get; }

        protected CreateActivityRejectedEvent()
        {
        }

        public CreateActivityRejectedEvent(string id, string message, string code)
        {
            Id = id;
            Message = message;
            Code = code;
        }
    }
}