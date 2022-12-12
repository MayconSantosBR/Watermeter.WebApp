using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Watermetter.Services.Interfaces;

namespace Watermetter.Controllers
{
    public class ArduinoController : Controller
    {
        private readonly IArduinoService service;
        public ArduinoController(IArduinoService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Arduino()
        {
            ViewBag.Arduinos = await service.PegarArduinos(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()));
            return View();
        }
        public IActionResult ArduinoCreate()
        {
            return View("CadastroArduino");
        }
        public async Task<IActionResult> CriarArduino(string name)
        {
            try
            {
                if (await service.CriarArduino(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()), name))
                    return View("Arduino");
                else
                    return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Arduino");
            }
        }
    }
}
