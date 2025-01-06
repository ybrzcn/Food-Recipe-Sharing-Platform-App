using OzcanEnterprise.Library.Entities.BaseEntities;

namespace OzcanEnterprise.Library.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
