using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IAppointmentRepositery : IGenaricRepositery<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllWithDetailsAsync();
        Task<Appointment?> GetByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Appointment>> GetByStatusAsync(AppointmentStatus status);
        Task<IEnumerable<Appointment>> GetAppointmentbyUser(string userId);


        // Advanced filtering methods
        Task<IEnumerable<Appointment>> GetByDoctorNameAsync(string doctorName);
        Task<IEnumerable<Appointment>> GetByPatientAndDoctorIdAsync(Guid patientId, Guid doctorId);
        Task<IEnumerable<Appointment>> GetByPatientIdAndDoctorNameAsync(Guid patientId, string doctorName);
        Task<IEnumerable<Appointment>> GetByPatientNameAndDoctorIdAsync(string patientName, Guid doctorId);
        Task<IEnumerable<Appointment>> GetByPatientNameAndDoctorNameAsync(string patientName, string doctorName);
        Task<IEnumerable<Appointment>> AdvancedSearchAsync(
            string? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            Guid? patientId = null,
            Guid? doctorId = null,
            string? patientName = null,
            string? doctorName = null,
            string? specialization = null,
            int pageNumber = 1,
            int pageSize = 50);
    }
}









