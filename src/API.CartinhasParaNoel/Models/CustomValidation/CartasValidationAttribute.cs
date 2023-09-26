using System.ComponentModel.DataAnnotations;

namespace API.CartinhasParaNoel.Models.CustomValidation
{
    public class CartasValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int idade)
            {
                if (value == null)
                {
                    return new ValidationResult("Idade obrigatoria");
                }
                if (idade >= 15)
                {
                    return new ValidationResult("Somente menores de 15 anos");
                }
            }
            return ValidationResult.Success;
        }
    }
}
