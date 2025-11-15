using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalVisitDTO
{
    public class MedicalVisitDto
    {
        public Guid Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string UserID { get; set; } = string.Empty;
        public string DoctorID { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
    }

}
