using System;

namespace profashion.core.Events
{
    public class ActivityCreatedEvent : IAuthenticatedEvent
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        protected ActivityCreatedEvent()
        {
        }

        public ActivityCreatedEvent(string id, string userId, string category, string name, string description,
            DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}