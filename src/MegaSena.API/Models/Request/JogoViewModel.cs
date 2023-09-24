using MegaSena.API.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace MegaSena.API.Models.Request
{
    public class JogoViewModel
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string Nome { get; set; }
        [CpfValidation]
        public string CPF { get; set; }
        public DateTime Data { get; set; }

        [NumerosValidation]
        public int[] NumeroDoJogo { get; set; }
       
    }
}
