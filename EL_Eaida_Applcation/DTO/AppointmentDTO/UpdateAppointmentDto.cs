using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class UpdateAppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public string? Time { get; set; }
        public string? Type { get; set; } // نوع الموعد
        public int? Duration { get; set; } // مدة الموعد بالدقائق
        public Guid? PatientId { get; set; }
        public Guid? DoctorId { get; set; }
        public string? UserID { get; set; }
    }

}
