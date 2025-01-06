using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class User : PersonBaseEntity
    {
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
