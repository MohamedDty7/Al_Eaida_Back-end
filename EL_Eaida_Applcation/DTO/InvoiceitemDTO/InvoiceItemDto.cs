using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.InvoiceitemDTO
{
    public class InvoiceItemDto
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string? ItemType { get; set; }
        public string? ItemId { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
