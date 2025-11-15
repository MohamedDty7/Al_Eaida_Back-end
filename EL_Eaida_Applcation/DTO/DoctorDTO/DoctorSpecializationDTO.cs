using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.DoctorDTO
{
    public class DoctorSpecializationDTO
    {
        public string Id { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
        public string SpecializationId { get; set; } = string.Empty;
        public string SpecializationName { get; set; } = string.Empty;
        public string? SpecializationDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}





















