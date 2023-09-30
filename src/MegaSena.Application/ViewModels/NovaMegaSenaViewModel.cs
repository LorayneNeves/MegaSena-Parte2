using MegaSena.Application.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.ViewModels
{
    public class NovaMegaSenaViewModel
    {
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string Nome { get; set; }

        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public DateTime Data { get; set; }

        [JogoValidationAttribute(ErrorMessage = "Os 6 números do jogo devem ser diferentes e devem ser entre 1 e 60")]
        public int[] NumeroDoJogo { get; set; }
    }
}
