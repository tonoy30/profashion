namespace profashion.core.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        string UserId { get; set; }
    }
}