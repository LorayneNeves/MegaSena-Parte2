using MegaSena.API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MegaSena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : PrincipalController
    {
        #region Metodos Arquivo Json
        private readonly string jogoCaminhoArquivo;
        public JogoController()
        {
            jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogo.json");
        }

        private List<JogoViewModel> LerAlunosArquivo()
        {
            if (!System.IO.File.Exists(jogoCaminhoArquivo))
            {
                return new List<JogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(jogoCaminhoArquivo);
            if (string.IsNullOrEmpty(json))
            {
                return new List<JogoViewModel>();
            }
            return JsonConvert.DeserializeObject<List<JogoViewModel>>(json);
        }
       
        private void EscreverAlunosNoArquivo(List<JogoViewModel> jogo)
        {
            string json = JsonConvert.SerializeObject(jogo);
            System.IO.File.WriteAllText(jogoCaminhoArquivo, json);
        }
        #endregion
        #region CRUD
        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            List<JogoViewModel> listaJogos = LerAlunosArquivo();
            var jogoProcurado = listaJogos.Where(p => p.CPF == codigo);

            if (!jogoProcurado.Any()) return NotFound();
            return Ok(jogoProcurado.First());
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<JogoViewModel> listaJogos = LerAlunosArquivo();
            return Ok(listaJogos);
        }

        [HttpPost]
        public IActionResult Post(NovoJogoViewModel novoJogoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);
            }

            if (novoAlunoViewModel == null)
            {
                return BadRequest();
            }

            List<JogoViewModel> jogo = LerAlunosArquivo();

            JogoViewModel novoJogo = new JogoViewModel()
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

            return CreatedAtAction(nameof(Get), new { codigo = novoAluno.Codigo }, novoAluno);
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo, EditaAlunoViewModel editaAlunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);
            }

            if (editaAlunoViewModel == null)
            {
                return BadRequest();
            }

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
}
