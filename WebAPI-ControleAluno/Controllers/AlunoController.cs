using Microsoft.AspNetCore.Mvc;
using WebAPI_ControleAluno.Models.Request;

namespace WebAPI_ControleAluno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AlunoViewModel alunoViewModel)
        {
            return Ok();
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(AlunoViewModel alunoViewModel)
        {
            return Ok();
        }


        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            return Ok();
        }
    }
}
