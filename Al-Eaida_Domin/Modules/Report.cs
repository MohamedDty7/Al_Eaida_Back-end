using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public enum ReportType
    {
        Appointments,
        Patients,
        Financial,
        Medications,
        Doctors,
        Custom
    }
    public class Report : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public ReportType Type { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string GeneratedBy { get; set; } = string.Empty; // User ID

        [Required]
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(500)]
        public string? FilePath { get; set; }

        public string? Data { get; set; } // JSON data

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual User GeneratedByUser { get; set; } = null!;
    }
}
