using API.CartinhasParaNoel.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.CartinhasParaNoel.Controllers
{
    public class PrincipalController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(T data, string message)
        {
            var response = new RetornoCustomizado<T>
            {
                Sucesso = true,
                Menssagem = message,
                Dados = data,
                Status = 200
            };

            return Ok(response);
        }
        protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados invalidos!")
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            var response = new RetornoCustomizado<object>
            {
                Sucesso = false,
                Menssagem = message,
                Dados = erros.Select(n => n.ErrorMessage).ToArray(),
                Status = 400
            };
            return BadRequest(response);
        }

    }
}
