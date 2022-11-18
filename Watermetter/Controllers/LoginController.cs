using Microsoft.AspNetCore.Mvc;

namespace Watermetter.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
