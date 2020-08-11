using System;

namespace profashion.business.Models
{
    public abstract class BaseModel
    {
        public string Id { get; protected set; }

        protected BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}