using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.ValidationAtributes
{
    public class FullNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var fullName = value as string;

            if (string.IsNullOrWhiteSpace(fullName))
                return new ValidationResult("Full name is required.");

            var parts = fullName.Trim().Split(' ');
            if (parts.Length < 2)
                return new ValidationResult("Full name must include at least first and last name.");

            return ValidationResult.Success;
        }
    }
}
