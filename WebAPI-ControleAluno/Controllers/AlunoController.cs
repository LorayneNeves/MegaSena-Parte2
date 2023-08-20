using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebAPI_ControleAluno.Models.Request;

namespace WebAPI_ControleAluno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        #region Metodos Arquivo Json
        private readonly string alunoCaminhoArquivo;
        public AlunoController()
        {
            alunoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "aluno.json");
        }

        private List<AlunoViewModel> LerAlunosArquivo()
        {
            if (!System.IO.File.Exists(alunoCaminhoArquivo))
            {
                return new List<AlunoViewModel>();
            }

            string json = System.IO.File.ReadAllText(alunoCaminhoArquivo);
            if (string.IsNullOrEmpty(json))
            {
                return new List<AlunoViewModel>();
            }
            return JsonConvert.DeserializeObject<List<AlunoViewModel>>(json);
        }
        private int ObterProximoCodigoDisponivel()
        {
            List<AlunoViewModel> alunos = LerAlunosArquivo();
            if (alunos.Any())
            {
                return alunos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }
        private void EscreverAlunosNoArquivo(List<AlunoViewModel> alunos)
        {
            string json = JsonConvert.SerializeObject(alunos);
            System.IO.File.WriteAllText(alunoCaminhoArquivo, json);
        }
        #endregion

        #region CRUD
        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            List<AlunoViewModel> listaTodosAlunos = LerAlunosArquivo();
            var alunoProcurado = listaTodosAlunos.Where(p => p.Codigo == codigo);

            if(!alunoProcurado.Any()) return NotFound();
            return Ok(alunoProcurado.First());
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AlunoViewModel> listaTodosAlunos = LerAlunosArquivo();
            return Ok(listaTodosAlunos);
        }

        [HttpPost]
        public IActionResult Post(NovoAlunoViewModel novoAlunoViewModel)
        {
            if (novoAlunoViewModel == null)
            {
                return BadRequest();
            }

            List<AlunoViewModel> alunos = LerAlunosArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            AlunoViewModel novoAluno = new AlunoViewModel()
            {
                Codigo = proximoCodigo,
                RA = novoAlunoViewModel.RA,
                Nome = novoAlunoViewModel.Nome,
                CPF = novoAlunoViewModel.CPF,
                email = novoAlunoViewModel.email,
                Ativo = novoAlunoViewModel.Ativo

            }; 
            alunos.Add(novoAluno);
            EscreverAlunosNoArquivo(alunos);

            return CreatedAtAction(nameof(Get), new {codigo = novoAluno.Codigo}, novoAluno);
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo, EditaAlunoViewModel editaAlunoViewModel)
        {
            List<AlunoViewModel> listaTodosAlunos = LerAlunosArquivo();
            var alunoExistente = listaTodosAlunos.FirstOrDefault(p => p.Codigo == codigo);

            if (alunoExistente == null)
            {
                return NotFound();
            }
            
            alunoExistente.Nome = editaAlunoViewModel.Nome;
            alunoExistente.CPF = editaAlunoViewModel.CPF;
            alunoExistente.RA = editaAlunoViewModel.RA;
            alunoExistente.email = editaAlunoViewModel.email;
            alunoExistente.Ativo = editaAlunoViewModel.Ativo;

            EscreverAlunosNoArquivo(listaTodosAlunos);
            return Ok(alunoExistente);                    
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            List<AlunoViewModel> alunos = LerAlunosArquivo();
            var alunoExistente = alunos.FirstOrDefault(p => p.Codigo == codigo);

            if (alunoExistente == null)
            {
                return NotFound();
            }

            alunos.Remove(alunoExistente);
            EscreverAlunosNoArquivo(alunos);

            return NoContent();
        }
        #endregion
    }
}
