using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAPI_ControleAluno.Models.CustomValidation
{
    public class RaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("O valor não pode ser nulo."); 
            }

            string RA = value.ToString();

            // Verifica se o RA começa com "RA" e tem exatamente 8 caracteres (2 letras + 6 dígitos)
            if (Regex.IsMatch(RA, @"^RA\d{6}$", RegexOptions.IgnoreCase) && RA.StartsWith("RA", StringComparison.OrdinalIgnoreCase))
            {
                return ValidationResult.Success; // O RA está no formato correto
            }

            return new ValidationResult(" O RA não atende às regras especificadas."); 
        }
    }
}
