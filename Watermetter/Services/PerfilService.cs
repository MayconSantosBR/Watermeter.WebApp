using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Helpers;
using Watermetter.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Watermetter.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IMapper mapper;
        private HttpClient client;
        public PerfilService(IMapper mapper, HttpClient httpClient)
        { 
            this.mapper = mapper;
            this.client = httpClient;
        }

        public async Task<Perfil> GetPerfilModelAsync(int id)
        {
            try
            {
                using var response = await client.GetAsync($"{EnvironmentConfig.Host.HostApi}/api/Owner/GetOwnerModel?id={id}");
       
                return mapper.Map<Perfil>(JsonConvert.DeserializeObject<Perfil>(await response.Content.ReadAsStringAsync()));
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> UpdatePerfilModelAsync(int id, Perfil model)
        {
            try
            {
                var body = GeneralHelper.GenerateBody(model);
                using var response = await client.PatchAsync($"{EnvironmentConfig.Host.HostApi}/api/owner/UpdateOwner?id={id}", body);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
