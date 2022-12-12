using System.Threading.Tasks;
using Watermetter.Models;

namespace Watermetter.Services.Interfaces
{
    public interface IPerfilService
    {
        Task<Perfil> GetPerfilModelAsync(int id);
        Task<bool> UpdatePerfilModelAsync(int id, Perfil model);
    }
}