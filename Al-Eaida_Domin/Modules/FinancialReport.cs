using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class FinancialReport : BaseEntity
    {

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        public decimal TotalRevenue { get; set; }

        public decimal? ConsultationFees { get; set; }

        public decimal? MedicationSales { get; set; }

        public decimal? OtherServices { get; set; }

        public decimal? TotalExpenses { get; set; }

        public decimal? NetProfit { get; set; }

        public int? TotalAppointments { get; set; }

        public int? CompletedAppointments { get; set; }

        public int? CancelledAppointments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
