using System.Threading.Tasks;
using Watermetter.Models;

namespace Watermetter.Services
{
    public interface ILoginService
    {
        Task<bool> ValidarLogin(Login login);
    }
}