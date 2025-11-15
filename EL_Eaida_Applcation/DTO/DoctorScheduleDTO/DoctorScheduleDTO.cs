using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.DTO.DoctorScheduleDTO
{
    public class DoctorScheduleDTO
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? DoctorName { get; set; }
    }
}
