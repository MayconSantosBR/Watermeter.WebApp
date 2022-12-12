using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Watermetter.Models
{
    public class Perfil
    {
        [JsonPropertyName("name")]
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        [Required, MaxLength(255)]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [JsonPropertyName("cellphone")]
        [Required, MaxLength(15)]
        public string Cellphone { get; set; }

        [JsonPropertyName("password")]
        [Required, MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
