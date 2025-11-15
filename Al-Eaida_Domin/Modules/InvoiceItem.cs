using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class InvoiceItem : BaseEntity
    {

        [Required]
        public Guid InvoiceId { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string? ItemType { get; set; } // Service, Medication, Consultation, etc.

        public string? ItemId { get; set; } // Reference to the actual item (Medication, Service, etc.)

        [StringLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Invoice Invoice { get; set; } = null!;
    }
}
