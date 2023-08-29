using System.ComponentModel.DataAnnotations;
using WebAPI_ControleAluno.Models.CustomValidation;

namespace WebAPI_ControleAluno.Models.Request
{
    public class NovoAlunoViewModel
    {
        [Required(ErrorMessage = "o nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        public int Codigo { get; set; }
        public int RA { get; set; }
        // [EmailValidation(ErrorMessage = "E-mail inválido.")]
        [EmailValidation(ErrorMessage = "E-mail inválido", EmailRequerido = false)]
        public string email { get; set; }

        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
