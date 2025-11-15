using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.DTO.Prescription
{
    public class UpdatePrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? MedicationId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public int? Duration { get; set; }
        public string? Instructions { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public List<PrescriptionItemDto>? Items { get; set; }
    }
}
