using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // نوع الموعد
        public int Duration { get; set; } = 30; // مدة الموعد بالدقائق
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string UserID { get; set; } = string.Empty;
        public string Status { get; set; } = "في_الانتظار";
    }

}
