using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Interfaces;

namespace Watermetter.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IGeneralService service;
        public CadastroController(IGeneralService service)
        {
            this.service = service;
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public async Task<IActionResult> Cadastrar(string name, string lastname, string email, string senha, string telefone)
        {
            Perfil perfil = new Perfil()
            {
                Name = name,
                LastName = lastname,
                Email = email,
                Password = senha,
                Cellphone = telefone
            };

            if (await service.SalvarCadastro(perfil))
                return View("Login");
            else
                return View("Cadastro");
        }
    }
}
