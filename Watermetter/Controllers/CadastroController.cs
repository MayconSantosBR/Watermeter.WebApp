using Microsoft.AspNetCore.Mvc;

namespace Watermetter.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
