namespace WebAPI_ControleAluno.Models.Request
{
    public class AlunoViewModel
    {
        public string Nome { get; set; }
        public int RA { get; set; }
        public string email { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
