using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Watermetter.Models
{
    public class Login
    {
        [Required, MaxLength(100)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
