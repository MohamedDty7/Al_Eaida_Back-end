using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IDoctorScheduleRepository : IGenericRepositery<DoctorSchedule>
    {
        Task<IEnumerable<DoctorSchedule>> GetSchedulesByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<DoctorSchedule>> GetSchedulesByDayAsync(DayOfWeek dayOfWeek);
        Task<IEnumerable<DoctorSchedule>> GetActiveSchedulesAsync();
    }
}
