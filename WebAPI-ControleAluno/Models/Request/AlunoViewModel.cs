using System.ComponentModel.DataAnnotations;
using WebAPI_ControleAluno.Models.CustomValidation;

namespace WebAPI_ControleAluno.Models.Request
{
    public class AlunoViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "A o nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [RaValidation]
        public string RA { get; set; }

        [EmailValidation]
        public string email { get; set; }

        [CpfValidation]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public bool Ativo { get; set; }
    }
}
