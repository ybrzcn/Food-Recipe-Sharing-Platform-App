namespace OzcanEnterprise.Library.Dtos
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public Guid RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
