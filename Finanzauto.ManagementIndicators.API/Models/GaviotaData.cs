using System.ComponentModel.DataAnnotations;

namespace Finanzauto.ManagementIndicators.API.Models
{
    public class GaviotaData : Entity
    {
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int PhaseId { get; set; }
        [Required, MaxLength(100)]
        public string Phase { get; set; }
        [Required, MaxLength(100)]
        public string Analyst { get; set; }
        [Required, MaxLength(50)]
        public string StartDate { get; set; }
        [Required, MaxLength(50)]
        public string StartHour { get; set; }
        [Required, MaxLength(50)]
        public string EndDate { get; set; }
        [Required, MaxLength(50)]
        public string EndHour { get; set; }
    }
}
