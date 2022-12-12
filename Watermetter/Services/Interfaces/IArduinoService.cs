using System.Collections.Generic;
using System.Threading.Tasks;
using Watermetter.Models;

namespace Watermetter.Services.Interfaces
{
    public interface IArduinoService
    {
        Task<bool> CriarArduino(int idOwner, string name);
        Task<List<Arduino>> PegarArduinos(int idOwner);
    }
}