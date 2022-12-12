using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
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

        public async Task<int> ValidarLogin(Login login)
        {
            try
            {
                var body = GeneralHelper.GenerateBody(login);
                using var response = await client.PostAsync($"{EnvironmentConfig.Host.HostApi}/api/Owner/ValidateCredentials?system=FrontEndConsole", body);

                if (response.IsSuccessStatusCode)
                {
                    return Convert.ToInt32(await response.Content.ReadAsStringAsync());
                }
                else
                    return 0;
            }
            catch
            {
                return 0;
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
        public async Task<Calcs> PegarCalculos(int idOwner)
        {
            try
            {
                using var response = await client.GetAsync($"{EnvironmentConfig.Host.HostApi}/GetCalculationsById?idOwner={idOwner}");
                return JsonConvert.DeserializeObject<Calcs>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> SalvarCadastro(Perfil perfil)
        {
            try
            {
                var body = GeneralHelper.GenerateBody(perfil);
                using var response = await client.PostAsync($"{EnvironmentConfig.Host.HostApi}/api/Owner/Create", body);

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
    }
}
