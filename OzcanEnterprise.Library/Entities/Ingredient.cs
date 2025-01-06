using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }

}
