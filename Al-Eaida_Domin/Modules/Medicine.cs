using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Medicine : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? GenericName { get; set; }

        [StringLength(50)]
        public string? DosageForm { get; set; } // Tablet, Capsule, Syrup, etc.

        [StringLength(100)]
        public string? Strength { get; set; } // 500mg, 10ml, etc.

        [StringLength(100)]
        public string? Manufacturer { get; set; }

        [StringLength(50)]
        public string? Barcode { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(1000)]
        public string? SideEffects { get; set; }

        [StringLength(1000)]
        public string? Contraindications { get; set; }

        [StringLength(1000)]
        public string? Instructions { get; set; }

        public decimal? Price { get; set; }

        public int? StockQuantity { get; set; }

        public int? MinStockLevel { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool RequiresPrescription { get; set; } = true;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();

        public virtual ICollection<MedicationCategory> MedicationCategories { get; set; } = new List<MedicationCategory>();


    }
}
