using Microsoft.EntityFrameworkCore;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.AppointmentRepositery
{
    public class AppointmentRepositery : GenaricRepositery<Appointment>, IAppointmentRepositery
    {
        public AppointmentRepositery(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAllWithDetailsAsync()
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentbyUser(string userId)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.Doctor != null && a.Doctor.UserId == userId)
                .ToListAsync();
        }



        public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.AppointmentDate >= startDate && a.AppointmentDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.Status == status)
                .ToListAsync();
        }

        // Advanced filtering methods implementation
        public async Task<IEnumerable<Appointment>> GetByDoctorNameAsync(string doctorName)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => (a.Doctor.FirstName + " " + a.Doctor.LastName).Contains(doctorName))
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientAndDoctorIdAsync(Guid patientId, Guid doctorId)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.PatientId == patientId && a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientIdAndDoctorNameAsync(Guid patientId, string doctorName)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.PatientId == patientId && (a.Doctor.FirstName + " " + a.Doctor.LastName).Contains(doctorName))
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientNameAndDoctorIdAsync(string patientName, Guid doctorId)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.Patient.FullName.Contains(patientName) && a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientNameAndDoctorNameAsync(string patientName, string doctorName)
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .Where(a => a.Patient.FullName.Contains(patientName) && (a.Doctor.FirstName + " " + a.Doctor.LastName).Contains(doctorName))
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> AdvancedSearchAsync(
            string? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            Guid? patientId = null,
            Guid? doctorId = null,
            string? patientName = null,
            string? doctorName = null,
            string? specialization = null,
            int pageNumber = 1,
            int pageSize = 50)
        {
            var query = _context.Set<Appointment>()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .AsQueryable();

            // فلتر حسب الحالة
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<AppointmentStatus>(status, out var appointmentStatus))
            {
                query = query.Where(a => a.Status == appointmentStatus);
            }

            // فلتر حسب التاريخ
            if (startDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate <= endDate.Value);
            }

            // فلتر حسب المريض
            if (patientId.HasValue)
            {
                query = query.Where(a => a.PatientId == patientId.Value);
            }
            else if (!string.IsNullOrEmpty(patientName))
            {
                query = query.Where(a => a.Patient.FullName.Contains(patientName));
            }

            // فلتر حسب الطبيب
            if (doctorId.HasValue)
            {
                query = query.Where(a => a.DoctorId == doctorId.Value);
            }
            else if (!string.IsNullOrEmpty(doctorName))
            {
                query = query.Where(a => (a.Doctor.FirstName + " " + a.Doctor.LastName).Contains(doctorName));
            }

            // فلتر حسب التخصص
            if (!string.IsNullOrEmpty(specialization))
            {
                query = query.Where(a => a.Doctor.Specialization == specialization);
            }

            // تطبيق التصفح
            return await query
                .OrderBy(a => a.AppointmentDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

      
    }
}
