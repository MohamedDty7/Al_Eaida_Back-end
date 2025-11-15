using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.DoctorScheduleDTO
{
    public class UpdateDoctorScheduleDTO
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? DoctorId { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
