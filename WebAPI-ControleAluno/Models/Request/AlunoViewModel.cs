using WebAPI_ControleAluno.Models.CustomValidation;

namespace WebAPI_ControleAluno.Models.Request
{
    public class AlunoViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int RA { get; set; }
        public string email { get; set; }

        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
