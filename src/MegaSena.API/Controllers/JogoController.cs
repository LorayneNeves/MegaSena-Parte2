using MegaSena.API.Models.Request;
using MegaSena.Application.Interfaces;
using MegaSena.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MegaSena.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : PrincipalController
    {
        private readonly IMegaSenaService _megaSenaService;

        public JogoController(IMegaSenaService jogoService)
        {
            _megaSenaService = jogoService;
        }

        [HttpPost(Name = "Adicionar")]
        public IActionResult Post(NovaMegaSenaViewModel novaMegaSenaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState);
            }

            if (novaMegaSenaViewModel == null)
            {
                return BadRequest();
            }
            _megaSenaService.Adicionar(novaMegaSenaViewModel);

            return Ok();
        }
        [HttpGet(Name = "ObterTodos")]
        public IActionResult Get()
        {
            return Ok(_megaSenaService.ObterTodos());
        }
    }
    
}

