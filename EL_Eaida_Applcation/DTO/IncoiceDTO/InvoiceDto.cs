using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.DTO.IncoiceDTO
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateOnly InvoiceDate { get; set; }
        public DateOnly DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? PaymentNotes { get; set; }
        public DateOnly? PaidDate { get; set; }
        public string? PaymentMethod { get; set; }
        public bool IsDeleted { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    }

}
