using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.Prescriptionitem
{
    public class UpdatePrescriptionItemDto
    { 
        public Guid Id { get; set; }
        public Guid? PrescriptionId { get; set; }
        public Guid? MedicineId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public int? Duration { get; set; }
        public int? Quantity { get; set; }
        public string? Instructions { get; set; }
        public string? Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
