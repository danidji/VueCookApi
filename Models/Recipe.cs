using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueCookApi.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public List<string> Ingredients { get; set; } = new();

        [Required]
        public List<string> Steps { get; set; } = new();

        public string? PreparationTime { get; set; }

        public string? CookingTime { get; set; }

        public int? PersNb { get; set; }
    }
}