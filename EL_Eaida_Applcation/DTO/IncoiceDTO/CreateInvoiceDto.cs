using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.DTO.IncoiceDTO
{
    public class CreateInvoiceDto
    {
        public Guid PatientId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal NetAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Notes { get; set; }
        public string? PaymentNotes { get; set; }
        public string? PaymentMethod { get; set; }
        public List<CreateInvoiceItemDto> Items { get; set; } = new List<CreateInvoiceItemDto>();
    }

}
