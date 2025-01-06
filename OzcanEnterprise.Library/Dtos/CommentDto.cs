using OzcanEnterprise.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzcanEnterprise.Library.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
