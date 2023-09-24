using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace MegaSena.API.Models.CustomValidation
{
    public class JogoValidationAttribute : ValidationAttribute
    {
        public override bool  IsValid(object value)
        {
            if (value is int[] numeros)
            {
                // Verifique se há exatamente 6 números
               

                // Verifique se os números estão entre 1 e 60
                if (numeros.Any(numero => numero < 1 || numero > 61))
                {
                    return false;
                }

                // Verifique se os números são todos diferentes
                if (numeros.Distinct().Count() != 6)
                {
                    return false;
                }

                return true;
            }

            // Se o valor não for um array de inteiros, a validação falha
            return false;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is List<int> numeros)
            {
                foreach (var numero in numeros)
                {
                    if (numero < 1 || numero > 60)
                    {
                        return new ValidationResult("Os numeros devem ser entre 1 e 60");
                    }
                }

            }
            return ValidationResult.Success;
        }
    }
 
}