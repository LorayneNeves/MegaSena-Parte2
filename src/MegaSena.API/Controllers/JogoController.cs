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
            jogoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");
        }

        private List<JogoViewModel> LerJogosArquivo()
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
        private int ObterProximoCodigoDisponivel()
        {
            List<JogoViewModel> jogo = LerJogosArquivo();
            if (jogo.Any())
            {
                return jogo.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }
        private void EscreverNumerosNoArquivo(List<JogoViewModel> jogo)
        {
            string json = JsonConvert.SerializeObject(jogo);
            System.IO.File.WriteAllText(jogoCaminhoArquivo, json);
        }
        #endregion
        #region CRUD
        [HttpGet("{codigo}")]
        public IActionResult ObterJogoEspecifico(int codigo) //dados de um jogo
        {
            List<JogoViewModel> listaJogos = LerJogosArquivo();
            var jogoProcurado = listaJogos.Where(p => p.Codigo == codigo);

            if (!jogoProcurado.Any()) return NotFound();
            return Ok(jogoProcurado.First());
        }

        [HttpGet]
        public IActionResult ObterTodosOsJogos() //dados de todos os jogos
        {
            List<JogoViewModel> listaJogos = LerJogosArquivo();
            return Ok(listaJogos);
        }

        [HttpPost]
        public IActionResult RegistrarJogo(NovoJogoViewModel novoJogoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);
            }
            
            if (novoJogoViewModel == null)
            {
                return BadRequest();
            }
            
            List<JogoViewModel> jogo = LerJogosArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            JogoViewModel novoJogo = new JogoViewModel()
            {             
                Codigo = proximoCodigo,
                Nome = novoJogoViewModel.Nome,
                Data = DateTime.Now,
                CPF = novoJogoViewModel.CPF,
                NumeroDoJogo = novoJogoViewModel.NumeroDoJogo
            };
            jogo.Add(novoJogo);
            EscreverNumerosNoArquivo(jogo);   

            return ApiResponse(novoJogo, "Jogo Registrado com sucesso!");
        }       
        #endregion
    }
}

