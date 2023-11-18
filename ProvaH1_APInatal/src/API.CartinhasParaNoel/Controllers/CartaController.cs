using API.CartinhasParaNoel.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.CartinhasParaNoel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController : PrincipalController
    {
            #region Metodos Arquivo Json
            private readonly string cartaCaminhoArquivo;
            public CartaController()
            {
                cartaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "CartasNatal.json");
            }

            private List<CartaViewModel> LerCartasArquivo()
            {
                if (!System.IO.File.Exists(cartaCaminhoArquivo))
                {
                    return new List<CartaViewModel>();
                }

                string json = System.IO.File.ReadAllText(cartaCaminhoArquivo);
                if (string.IsNullOrEmpty(json))
                {
                    return new List<CartaViewModel>();
                }
                return JsonConvert.DeserializeObject<List<CartaViewModel>>(json);
            }
            private int ObterProximoCodigoDisponivel()
            {
                List<CartaViewModel> carta = LerCartasArquivo();
                if (carta.Any())
                {
                    return carta.Max(p => p.idCarta) + 1;
                }
                else
                {
                    return 1;
                }
            }
            private void EscreverCartasNoArquivo(List<CartaViewModel> carta)
            {
                string json = JsonConvert.SerializeObject(carta);
                System.IO.File.WriteAllText(cartaCaminhoArquivo, json);
            }
            #endregion
            #region CRUD
            [HttpGet("{codigo}")]
            public IActionResult ObterCartaEspecifica(int codigo) //dados de um jogo
            {
                List<CartaViewModel> listaCartas = LerCartasArquivo();
                var cartaProcurada = listaCartas.Where(p => p.idCarta == codigo);

                if (!cartaProcurada.Any()) return NotFound();
                return Ok(cartaProcurada.First());
            }

            [HttpGet]
            public IActionResult ObterTodasAsCartas() //dados de todos os jogos
            {
                List<CartaViewModel> listaCartas = LerCartasArquivo();
                return Ok(listaCartas);
            }

            [HttpPost]
            public IActionResult RegistrarCarta(NovaCartaViewModel novaCartaViewModel)
            {
                if (!ModelState.IsValid)
                {
                    return ApiBadRequestResponse(ModelState);
                }

                if (novaCartaViewModel == null)
                {
                    return BadRequest();
                }

                List<CartaViewModel> jogo = LerCartasArquivo();
                int proximoCodigo = ObterProximoCodigoDisponivel();

                CartaViewModel novaCarta = new CartaViewModel()
                {              
                    idCarta = proximoCodigo,
                    nome = novaCartaViewModel.nome,
                    descricao = novaCartaViewModel.descricao,
                    idade = novaCartaViewModel.idade,
                    cidade = novaCartaViewModel.cidade,
                    estado = novaCartaViewModel.estado,
                    rua = novaCartaViewModel.rua,
                    bairro = novaCartaViewModel.bairro,
                    numero = novaCartaViewModel.numero
                };
                jogo.Add(novaCarta);
                EscreverCartasNoArquivo(jogo);

                return ApiResponse(novaCarta, "Carta registrada com sucesso!");
            }
            #endregion
    }
}

