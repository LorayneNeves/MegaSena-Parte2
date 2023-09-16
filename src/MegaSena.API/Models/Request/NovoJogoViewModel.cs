using MegaSena.API.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MegaSena.API.Models.Request
{
    public class NovoJogoViewModel
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage ="O nome deve ter no maximo 255 caracteres")]
        public string Nome { get; set; }
        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public DateTime Data { get; set; }

        [NumerosValidation(ErrorMessage = "Os 6 números do jogo devem ser diferentes e devem ser entre 1 e 60")]
        public int[] NumeroDoJogo { get; set; }
      
        
    }
}
