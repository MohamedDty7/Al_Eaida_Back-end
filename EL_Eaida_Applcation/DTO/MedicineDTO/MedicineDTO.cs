using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicineDTO
{
    public class MedicineDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? GenericName { get; set; }
        public string? DosageForm { get; set; }
        public string? Strength { get; set; }
        public string? Manufacturer { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public string? SideEffects { get; set; }
        public string? Contraindications { get; set; }
        public string? Instructions { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public int? MinStockLevel { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool RequiresPrescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
