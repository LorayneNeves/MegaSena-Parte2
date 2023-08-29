using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebAPI_ControleAluno.Models.Request;

namespace WebAPI_ControleAluno.Models.CustomValidation
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public Boolean EmailRequerido { get; set; }

        public EmailValidationAttribute()
        {
            this.ErrorMessage = "E-mail inválido.";
            this.EmailRequerido = false;

        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {

            // Verifica se o Valor é nulo
            if (value == null)
            {
                value = "";
            }

            // Retira espaços do final da literal
            value = value.ToString().TrimEnd();

            // Caso o valor informado seja nulo não é requerido retorna sem validar
            if (value == "" && EmailRequerido == false)
            {
                return ValidationResult.Success;
            }


            // Atribui expressao Regex
            Regex regExpEmail = new Regex(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$");


            // Valida a expressao
            Match match = regExpEmail.Match(value.ToString());

            if (match.Success)
            {
                return ValidationResult.Success; ;
            }

            // Devolve o erro padrao se a expressao nao for valida.
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }

        // Diretivas para validação do lado do Cliente, implementa com jquery.validate
       
    }
}

