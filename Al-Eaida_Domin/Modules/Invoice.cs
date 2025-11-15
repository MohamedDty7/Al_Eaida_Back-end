using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Invoice : BaseEntity
    {
        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty; // User ID who created the invoice

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public decimal TaxAmount { get; set; } = 0;

        [Required]
        public decimal DiscountAmount { get; set; } = 0;

        [Required]
        public decimal NetAmount { get; set; }

        [Required]
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;

        [StringLength(1000)]
        public string? Notes { get; set; }

        [StringLength(1000)]
        public string? PaymentNotes { get; set; }

        public DateTime? PaidDate { get; set; }

        public string? PaymentMethod { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual User CreatedByUser { get; set; } = null!;
        public virtual ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
    public enum InvoiceStatus
    {
        Pending,
        Paid,
        Overdue,
        Cancelled,
        Refunded
    }
}

