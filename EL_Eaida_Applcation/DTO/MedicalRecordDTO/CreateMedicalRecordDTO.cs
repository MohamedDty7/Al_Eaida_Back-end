using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicalRecordDTO
{
    public class CreateMedicalRecordDTO
    {
        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public string DoctorId { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Treatment { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}
