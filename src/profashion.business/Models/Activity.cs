using System;

namespace profashion.business.Models
{
    public class Activity : BaseModel
    {
        public string UserId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Activity()
        {
        }

        public Activity(string userId, string category, string name, string description, DateTime createdAt)
        {
            UserId = userId;
            Category = new Category(category);
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}