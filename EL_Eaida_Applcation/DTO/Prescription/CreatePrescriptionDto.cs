using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.DTO.Prescription
{
    public class CreatePrescriptionDto
    {
        public Guid PatientId { get; set; }
        public string DoctorId { get; set; } = string.Empty;
        public Guid MedicationId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string? Instructions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<CreatePrescriptionItemDto> Items { get; set; } = new List<CreatePrescriptionItemDto>();
    }
}
