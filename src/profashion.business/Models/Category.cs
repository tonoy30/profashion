namespace profashion.business.Models
{
    public class Category : BaseModel
    {
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}