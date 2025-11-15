using EL_Eaida_Applcation.DTO.DoctorScheduleDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IDoctorScheduleServices
    {
        Task<DoctorScheduleDTO> CreateScheduleAsync(CreateDoctorScheduleDTO createDto);
        Task<DoctorScheduleDTO?> GetScheduleByIdAsync(Guid id);
        Task<IEnumerable<DoctorScheduleDTO>> GetAllSchedulesAsync();
        Task<IEnumerable<DoctorScheduleDTO>> GetSchedulesByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<DoctorScheduleDTO>> GetSchedulesByDayAsync(DayOfWeek dayOfWeek);
        Task<DoctorScheduleDTO?> UpdateScheduleAsync(UpdateDoctorScheduleDTO updateDto);
        Task<bool> DeleteScheduleAsync(Guid id);
    }
}
