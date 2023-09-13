using Microsoft.AspNetCore.Mvc;

namespace MegaSena.API.Controllers
{
    public class PrincipalController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
