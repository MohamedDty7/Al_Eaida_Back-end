using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Prescription : BaseEntity
    {




        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid MedicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Frequency { get; set; } = string.Empty; // Once daily, Twice daily, etc.

        [Required]
        public int Duration { get; set; } // Number of days

        [StringLength(500)]
        public string? Instructions { get; set; }

        [Required]
        public DateTime PrescribedDate { get; set; } = DateTime.UtcNow;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Medicine Medication { get; set; } = null!;
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();

    }
}
