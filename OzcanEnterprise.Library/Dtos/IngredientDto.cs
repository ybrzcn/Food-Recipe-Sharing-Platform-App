using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.Dtos
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
