using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Interfaces;

namespace Watermetter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneralService service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGeneralService service)
        {
            this.service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = HttpContext.Session.Get("Logado");

            if (response.FirstOrDefault().Equals(1))
            {
                ViewBag.Histories = await service.PegarHistorico(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()));
                ViewBag.Calculations = await service.PegarCalculos(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()));
                return View();
            }
            else
                return View("Login");
        }
        public IActionResult Sair()
        {
            byte[] notLogin = { 0 };
            HttpContext.Session.Set("Logado", notLogin);
            return View("Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
