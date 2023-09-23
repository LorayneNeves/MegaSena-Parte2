using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace MegaSena.API.Models.CustomValidation
{
    public class NumerosValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int[] numeros)
            {
                // Verifica se tem exatamente 6 numeros
                if (numeros.Length != 6)
                {
                    return new ValidationResult("Deve haver exatamente 6 números na Mega Sena.");
                }

                // Verifica se os numeros estão entre 1 e 60
                if (numeros.Any(numero => numero < 1 || numero > 60))
                {
                    return new ValidationResult("Os números devem estar entre 1 e 60.");
                }

                // Verifica se os numeros são todos diferentes
                if (numeros.Distinct().Count() != 6)
                {
                    return new ValidationResult("Os 6 números devem ser diferentes.");
                }

                return ValidationResult.Success;
            }

            // Se o valor não for um array de inteiros, a validação falha
            return new ValidationResult("O valor fornecido não é um array de inteiros.");
        }
    }
}
