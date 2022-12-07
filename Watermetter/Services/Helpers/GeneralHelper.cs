using Newtonsoft.Json;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Text;
using System;

namespace Watermetter.Services.Helpers
{
    public static class GeneralHelper
    {
        public static StringContent GenerateBody(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, Application.Json);
        }
    }
}
