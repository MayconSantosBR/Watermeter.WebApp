using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using System;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Interfaces;

namespace Watermetter.Controllers
{
    public class LoginController : Controller
    {
        private readonly IGeneralService loginService;
        public LoginController(IGeneralService loginService)
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

                byte[] isLogin = { 1 };
                byte[] notLogin = { 0 };
                HttpContext.Session.Set("Logado", notLogin);

                var id = await loginService.ValidarLogin(login);
                if (id != 0)
                {
                    byte[] user = { Convert.ToByte(id) };
                    HttpContext.Session.Set("User", user);
                    HttpContext.Session.Set("Logado", isLogin);
                    return RedirectToAction("Index", "Home");
                }
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
