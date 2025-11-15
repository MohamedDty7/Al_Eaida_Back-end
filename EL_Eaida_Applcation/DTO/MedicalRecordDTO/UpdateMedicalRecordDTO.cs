using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalRecordDTO
{
    public class UpdateMedicalRecordDTO
    {
        public Guid Id { get; set; }
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public DateTime? Date { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public string? Notes { get; set; }
    }
}
