using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.Prescriptionitem
{
    public class PrescriptionItemDto
    {
        public Guid Id { get; set; }
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int Quantity { get; set; }
        public string? Instructions { get; set; }
        public string? Notes { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
