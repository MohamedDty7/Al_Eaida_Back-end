using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.DTO.Prescription
{
    public class PrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public Guid MedicationId { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string? Instructions { get; set; }
        public DateOnly PrescribedDate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateOnly CreatedAt { get; set; }
        public List<PrescriptionItemDto> Items { get; set; } = new List<PrescriptionItemDto>();
    }
}
