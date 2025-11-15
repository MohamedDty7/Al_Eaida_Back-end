using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalRecordDTO
{
    public class MedicalRecordDTO
    {
        public string Id { get; set; } = string.Empty;
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
