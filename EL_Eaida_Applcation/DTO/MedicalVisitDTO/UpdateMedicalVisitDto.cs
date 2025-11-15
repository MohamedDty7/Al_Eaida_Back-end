using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalVisitDTO
{
    public class UpdateMedicalVisitDto
    {
        public Guid Id { get; set; }
        public DateTime? VisitDate { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public Guid? PatientId { get; set; }
        public string? UserID { get; set; }
        public string? DoctorID { get; set; }
    }

}
