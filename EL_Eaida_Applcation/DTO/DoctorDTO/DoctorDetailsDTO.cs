using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.DoctorDTO
{
    public class DoctorDetailsDTO
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string MedicalSchool { get; set; } = string.Empty;
        public int? YearsOfExperience { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImage { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? MaxPatientsPerDay { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // تفاصيل إضافية
        public string FullName => $"{FirstName} {LastName}";
        public List<DoctorSpecializationDTO> Specializations { get; set; } = new List<DoctorSpecializationDTO>();
        public List<DoctorScheduleDTO> Schedules { get; set; } = new List<DoctorScheduleDTO>();
        public int TotalAppointments { get; set; }
        public int TodayAppointments { get; set; }
    }
}





















