using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.DoctorSpecializationDTO
{
    public class UpdateDoctorSpecializationDTO
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? DoctorId { get; set; }
        public Guid? SpecializationId { get; set; }
    }
}
