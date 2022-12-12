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
        [HttpGet("BuscarPerfil")]
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
        [HttpPatch("EditarPerfil")]
        public async Task<IActionResult> EditarPerfil(int id, Perfil model)
        {
            try
            {
                await service.UpdatePerfilModelAsync(id, model);
                return View("Index");
            }
            catch
            {
                return View("Perfil");
            }
        }
    }
}
