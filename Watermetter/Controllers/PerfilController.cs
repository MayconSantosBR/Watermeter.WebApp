using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Interfaces;

namespace Watermetter.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilService service;
        public PerfilController(IPerfilService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Perfil()
        {
            var response = HttpContext.Session.Get("Logado");

            if (response.FirstOrDefault().Equals(1))
            {
                ViewBag.Perfil = await service.GetPerfilModelAsync(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()));
                return View();
            }
            else
            {
                return View("Login");
            }      
        }
        public async Task<IActionResult> EditarPerfil(string name, string lastname, string email, string password, string number)
        {
            try
            {
                Perfil perfil = new Perfil()
                {
                    Name = name,
                    LastName = lastname,
                    Email = email,
                    Password= password,
                    Cellphone = number
                };

                if (await service.UpdatePerfilModelAsync(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()), perfil))
                    return RedirectToAction("Index", "Home");
                else
                    return View("Perfil");
            }
            catch
            {
                return View("Perfil");
            }
        }
    }
}
