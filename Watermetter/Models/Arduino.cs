using Microsoft.VisualBasic;
using System;
using System.Text.Json.Serialization;

namespace Watermetter.Models
{
    public class Arduino
    {
        [JsonPropertyName("idArduino")]
        public int IdArduino { get; set; }

        [JsonPropertyName("idOwner")]
        public int IdOwner { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("applyDate")]
        public DateTime ApplyDate { get; set; }
    }
}
