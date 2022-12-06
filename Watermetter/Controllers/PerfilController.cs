using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services;

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
        public async Task<IActionResult> Perfil(int id)
        {
            ViewBag.Perfil = await service.GetPerfilModelAsync(id);
            return View();
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
