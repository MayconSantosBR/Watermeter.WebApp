using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Watermetter.Models;
using Watermetter.Services.Helpers;
using Watermetter.Services.Interfaces;

namespace Watermetter.Services
{
    public class ArduinoService : IArduinoService
    {
        private HttpClient client { get; set; }
        public ArduinoService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<bool> CriarArduino(int idOwner, string name)
        {
            try
            {
                ArduinoCreateModel model = new ArduinoCreateModel() { Name = name, IdOwner = idOwner};
                var body = GeneralHelper.GenerateBody(model);

                using var response = await client.PostAsync($"{EnvironmentConfig.Host.HostApi}/CreateArduino", body);

                if(response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Arduino>> PegarArduinos(int idOwner)
        {
            try
            {
                using var response = await client.GetAsync($"{EnvironmentConfig.Host.HostApi}/GetArduinoListById?idOwner={idOwner}");

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<Arduino>>(await response.Content.ReadAsStringAsync());
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
