using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.Prescriptionitem
{
    public class CreatePrescriptionItemDto
    {
        public Guid PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Instructions { get; set; }
        public string? Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
