using Microsoft.AspNetCore.Mvc;
using Catalogo.Application.ViewModels;
using LOJAH1.Catalogo.Application.Interfaces;

namespace Loja.Catalogo.API.Controllers
{

    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;
        public ProdutoController(IProdutoService _produtoService)
        {
            produtoService = _produtoService;
        }
        [HttpPost(Name = "Adicionar")]
        public IActionResult Post(NovoProdutoViewModel novoProdutoViewModel)
        {
            produtoService.Adicionar(novoProdutoViewModel);
            return Ok("Registro adicionado com sucesso!");
        }
    }
}
