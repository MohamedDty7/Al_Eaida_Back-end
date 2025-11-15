using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.DTO.IncoiceDTO
{
    public class UpdateInvoiceDto
    {
        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public string? CreatedBy { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? NetAmount { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public string? PaymentNotes { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaymentMethod { get; set; }
        public bool? IsDeleted { get; set; }
        public List<UpdateInvoiceItemDto>? Items { get; set; }
    }

}
