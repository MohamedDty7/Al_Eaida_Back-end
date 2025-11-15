using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalVisitDTO
{
    public class CreateMedicalVisitDto
    {
        public DateTime VisitDate { get; set; } = DateTime.UtcNow;
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public Guid PatientId { get; set; }
        public string UserID { get; set; } = string.Empty; // ID الطبيب
        public string DoctorID { get; set; } = string.Empty;
    }

}
