using System.ComponentModel.DataAnnotations;

namespace MegaSena.API.Models.Request
{
    public class JogoViewModel
    {
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }
        [CpfValidation]
        public string CPF { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "A o nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public int PrimeiroNro { get; set; }
        public int SegundoNro { get; set; }
        public int TerceiroNro { get; set; }
        public int QuartoNro { get; set; }
        public int QuintoNro { get; set; }
        public int SextoNro { get; set; }
    }
}
