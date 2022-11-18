using Microsoft.AspNetCore.Mvc;

namespace Watermetter.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
