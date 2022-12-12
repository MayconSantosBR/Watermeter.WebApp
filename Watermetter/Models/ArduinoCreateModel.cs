using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Watermetter.Models
{
    public class ArduinoCreateModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("idOwner")]
        public int IdOwner { get; set; }
    }
}
