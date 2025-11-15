using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.DoctorScheduleRepositery
{
    public class DoctorScheduleRepositery : GenaricRepositery<DoctorSchedule>, IDoctorScheduleRepository
    {
        public DoctorScheduleRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<DoctorSchedule>> GetSchedulesByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<DoctorSchedule>()
                .Where(s => s.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorSchedule>> GetSchedulesByDayAsync(DayOfWeek dayOfWeek)
        {
            return await _context.Set<DoctorSchedule>()
                .Where(s => s.DayOfWeek == dayOfWeek)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorSchedule>> GetActiveSchedulesAsync()
        {
            return await _context.Set<DoctorSchedule>()
                .Where(s => s.IsActive)
                .ToListAsync();
        }
    }
}
