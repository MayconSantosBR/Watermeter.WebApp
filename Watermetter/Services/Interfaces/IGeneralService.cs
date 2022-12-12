using System.Collections.Generic;
using System.Threading.Tasks;
using Watermetter.Models;

namespace Watermetter.Services.Interfaces
{
    public interface IGeneralService
    {
        Task<bool> ValidarLogin(Login login);
        Task<List<History>> PegarHistorico(int idOwner);
    }
}