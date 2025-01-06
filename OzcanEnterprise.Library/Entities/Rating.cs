using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class Rating : BaseEntity
    {
        public int Score { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

}
