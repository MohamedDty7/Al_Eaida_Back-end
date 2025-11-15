using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.FinancialReportDTO
{
    public class UpdateFinancialReportDTO
    {
        [Required]
        public Guid Id { get; set; }

        public DateTime? ReportDate { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? ConsultationFees { get; set; }
        public decimal? MedicationSales { get; set; }
        public decimal? OtherServices { get; set; }
        public decimal? TotalExpenses { get; set; }
        public decimal? NetProfit { get; set; }
        public int? TotalAppointments { get; set; }
        public int? CompletedAppointments { get; set; }
        public int? CancelledAppointments { get; set; }
    }
}
