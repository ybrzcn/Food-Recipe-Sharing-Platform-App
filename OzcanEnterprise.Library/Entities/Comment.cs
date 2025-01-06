using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
