using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.DoctorScheduleDTO
{
    public class CreateDoctorScheduleDTO
    {
        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
