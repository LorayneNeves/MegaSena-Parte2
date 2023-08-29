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
        
        public int RA { get; set; }
        [EmailValidation]
        public string email { get; set; }

        [CpfValidation]
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
