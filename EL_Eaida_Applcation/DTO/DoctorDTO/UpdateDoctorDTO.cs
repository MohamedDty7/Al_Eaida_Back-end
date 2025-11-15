using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.DoctorDTO
{
    public class UpdateDoctorDTO
    {
        public string Id { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Specialization { get; set; }
        public string? LicenseNumber { get; set; }
        public string? MedicalSchool { get; set; }
        public int? YearsOfExperience { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImage { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? MaxPatientsPerDay { get; set; }
        public bool? IsActive { get; set; }
    }
}
























