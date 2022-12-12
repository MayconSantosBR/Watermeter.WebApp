using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Helpers;
using Watermetter.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Watermetter.Services
{
    public class GeneralService : IGeneralService
    {
        private HttpClient client;

        public GeneralService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<bool> ValidarLogin(Login login)
        {
            try
            {
                var body = GeneralHelper.GenerateBody(login);
                using var response = await client.PostAsync($"{EnvironmentConfig.Host.HostApi}/api/Owner/ValidateCredentials?system=FrontEndConsole", body);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<History>> PegarHistorico(int idOwner)
        {
            try
            {
                using var response = await client.GetAsync($"{EnvironmentConfig.Host.HostApi}/GetHistoriesById?idOwner={idOwner}");
                return JsonConvert.DeserializeObject<List<History>>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return null;
            }
        }
    }
}
