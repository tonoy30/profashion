namespace profashion.core.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Message { get; }
        string Code { get; }
    }
}