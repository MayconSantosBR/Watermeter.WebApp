using System.Collections.Generic;
using System.Threading.Tasks;
using Watermetter.Models;

namespace Watermetter.Services.Interfaces
{
    public interface IGeneralService
    {
        Task<int> ValidarLogin(Login login);
        Task<List<History>> PegarHistorico(int idOwner);
        Task<Calcs> PegarCalculos(int idOwner);
        Task<bool> SalvarCadastro(Perfil perfil);
    }
}