using Al_Eaida_Domin.Modules;
using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ReportDTO
{
    public class UpdateReportDTO
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        public ReportType? Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? FilePath { get; set; }
        public string? Data { get; set; }
        public bool? IsActive { get; set; }
    }
}
