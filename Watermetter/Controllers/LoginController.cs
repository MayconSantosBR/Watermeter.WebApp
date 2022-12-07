using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services;

namespace Watermetter.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                var login = new Login() { Email = email, Password = senha };

                if(await loginService.ValidarLogin(login))
                    return View("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
