using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace Watermetter.Services
{
    public class LoginService : ILoginService
    {
        private HttpClient client;

        public LoginService(HttpClient client)
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
    }
}
