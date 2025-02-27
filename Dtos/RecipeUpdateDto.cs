namespace VueCookApi.Models
{
    public class RecipeUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public List<string>? Ingredients { get; set; }
        public List<string>? Steps { get; set; }
        public string? PreparationTime { get; set; }
        public string? CookingTime { get; set; }
        public int? PersNb { get; set; }
    }
}