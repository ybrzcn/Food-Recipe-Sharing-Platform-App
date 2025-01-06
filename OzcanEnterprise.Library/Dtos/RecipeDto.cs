using OzcanEnterprise.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzcanEnterprise.Library.Dtos
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int ServingSize { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
