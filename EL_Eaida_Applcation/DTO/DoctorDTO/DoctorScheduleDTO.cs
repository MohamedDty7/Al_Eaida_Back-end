using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.DoctorDTO
{
    public class DoctorScheduleDTO
    {
        public string Id { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // خصائص مساعدة
        public string DayName => DayOfWeek.ToString();
        public string TimeRange => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
    }
}





















