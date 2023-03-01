using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finanzauto.ManagementIndicators.API.Models
{
    public class Entity
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
