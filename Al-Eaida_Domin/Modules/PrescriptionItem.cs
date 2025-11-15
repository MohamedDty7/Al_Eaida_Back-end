using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class PrescriptionItem : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string Dosage { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Frequency { get; set; } = string.Empty; // Once daily, Twice daily, etc.

        [Required]
        public int Duration { get; set; } // Number of days

        [Required]
        public int Quantity { get; set; } = 1;

        [StringLength(500)]
        public string? Instructions { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; } = null!;

        public Guid MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; } = null!;
    }
}
