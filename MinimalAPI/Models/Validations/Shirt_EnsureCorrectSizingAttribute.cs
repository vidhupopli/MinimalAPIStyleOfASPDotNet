// Men's shirt size cannot be s
// Woman's shirt size cannot be xxl

using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        private static readonly ILogger<Shirt_EnsureCorrectSizingAttribute> _logger =
                LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Shirt_EnsureCorrectSizingAttribute>();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirtInstance = validationContext.ObjectInstance as Shirt; // We know this is Shirt because we have applied this attribute onto one of the properties of Shirt class.

            if (shirtInstance != null)
            {
                _logger.LogInformation("Instance exists");
               if (shirtInstance.Gender == "male" && shirtInstance.Size == "s")
               {
                    return new ValidationResult("Male shirts cannot be s");
               }
               else if (shirtInstance.Gender == "female" && shirtInstance.Size == "xxl")
               {
                    return new ValidationResult("Female shirts cannot be xxl");
               }
            }

            _logger.LogInformation("Validation was actually success");

            return ValidationResult.Success;
        }
    }
}
