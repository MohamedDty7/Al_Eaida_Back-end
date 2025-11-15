using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.DoctorSpecializationDTO
{
    public class CreateDoctorSpecializationDTO
    {
        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid SpecializationId { get; set; }
    }
}
