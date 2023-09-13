using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MegaSena.API.Models.Request
{
    public class NovoJogoViewModel
    {
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }
        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public DateTime Data { get; set; }
        public int PrimeiroNro { get; set; }
        public int SegundoNro { get; set; }
        public int TerceiroNro { get; set; }
        public int QuartoNro { get; set; }
        public int QuintoNro { get; set; }
        public int SextoNro { get; set; }
    }
}
