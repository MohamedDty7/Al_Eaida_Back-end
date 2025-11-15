using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class InsuranceInfo : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Provider { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string? GroupNumber { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}