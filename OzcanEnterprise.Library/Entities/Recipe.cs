using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }  // Dakika
        public int CookingTime { get; set; }  // Dakika
        public int ServingSize { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }

}
