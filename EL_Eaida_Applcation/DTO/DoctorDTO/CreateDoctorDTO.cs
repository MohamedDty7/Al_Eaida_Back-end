using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.DoctorDTO
{
    public class CreateDoctorDTO
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; } = string.Empty;

        [StringLength(50)]
        public string? LicenseNumber { get; set; }

        [StringLength(100)]
        public string? MedicalSchool { get; set; }

        public int? YearsOfExperience { get; set; }

        [StringLength(1000)]
        public string? Bio { get; set; }

        [StringLength(200)]
        public string? ProfileImage { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public int? MaxPatientsPerDay { get; set; }
    }
}
























