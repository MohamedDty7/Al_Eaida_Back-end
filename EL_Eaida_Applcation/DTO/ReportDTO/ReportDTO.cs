using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.DTO.ReportDTO
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ReportType Type { get; set; }
        public string? Description { get; set; }
        public string GeneratedBy { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? FilePath { get; set; }
        public string? Data { get; set; }
        public bool IsActive { get; set; }
        public string? GeneratedByUserName { get; set; }
    }
}
