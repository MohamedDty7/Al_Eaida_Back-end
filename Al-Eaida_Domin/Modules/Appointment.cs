using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public  class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.في_الانتظار;
        public string Time { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // نوع الموعد (استشارة، فحص، متابعة، إلخ)
        public int Duration { get; set; } = 30; // مدة الموعد بالدقائق
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public string UserID { get; set; } = string.Empty;
        public virtual User User { get; set; } = null!;
    }
    public enum AppointmentStatus
    {
        مؤكد,
        في_الانتظار,
        جاري_الفحص,
        مكتمل,
        تأجيل,
        ملغي
    }
}
