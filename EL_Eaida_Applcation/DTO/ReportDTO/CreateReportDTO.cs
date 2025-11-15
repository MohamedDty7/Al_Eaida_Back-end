using Al_Eaida_Domin.Modules;
using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ReportDTO
{
    public class CreateReportDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public ReportType Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string GeneratedBy { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? FilePath { get; set; }
        public string? Data { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
