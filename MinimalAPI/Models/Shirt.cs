using System.ComponentModel.DataAnnotations;
using MinimalAPI.Models.Validations;


namespace MinimalAPI.Models
{
    public class Shirt
    {
        //public required int RandomNumber { get; set; } // If you put required then it is required.
        [Required]
        public int ShirtId { get; set; }
        [Required] // If you do not want to use the required keyword, you can use this attribute as well for Model validation.
        public string? Color { get; set; }
        [Shirt_EnsureCorrectSizing] // Custom Attribute
        public string? Size { get; set; }
        public string? Gender { get; set; }
        public double Price { get; set; }
    }
}

