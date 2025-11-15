using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.DTO.Prescription;

namespace EL_Eaida_Applcation.InterFaceServices.IAppointmentServices
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto?> GetByIdAsync(Guid id);
        Task<AppointmentDto> Createappointment(CreateAppointmentDto value);
        Task<string> UpdateAsync(Guid id, UpdateAppointmentDto value);
        Task<bool> DeleteAsync(Guid id);

        // Enhanced appointment management methods
        Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(Guid patientId);
        Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<AppointmentDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AppointmentDto>> GetByStatusAsync(string status);

        // Enhanced appointment methods with details
        Task<AppointmentWithDetailsDto> CreateAppointmentWithDetailsAsync(CreateAppointmentWithDetailsDto dto);
        Task<IEnumerable<AppointmentWithDetailsDto>> GetAllAppointmentsWithDetailsAsync();

        // Advanced filtering methods
        Task<IEnumerable<AppointmentWithDetailsDto>> FilterByStatusAsync(string status);
        Task<IEnumerable<AppointmentWithDetailsDto>> FilterByDateRangeAsync(DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<AppointmentWithDetailsDto>> FilterByDoctorAsync(Guid? doctorId, string? doctorName);
        Task<IEnumerable<AppointmentWithDetailsDto>> FilterByPatientAndDoctorAsync(Guid? patientId, Guid? doctorId, string? patientName, string? doctorName);
        Task<IEnumerable<AppointmentWithDetailsDto>> AdvancedSearchAsync(
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

        // طرق إدارة حالة الموعد مع الإشعارات
        Task<bool> StartAppointmentAsync(Guid appointmentId, string doctorId);
        Task<bool> EndAppointmentAsync(Guid appointmentId, string doctorId);
        Task<bool> ChangeAppointmentStatusAsync(Guid appointmentId, string newStatus, string changedBy);
        Task<bool> ScheduleAppointmentReminderAsync(Guid appointmentId, int minutesBefore);
        Task<bool> CancelAppointmentAsync(Guid appointmentId, string cancelledBy);

        // New method to fetch appointments for a specific doctor
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorOnlyAsync(string Userid, int pageNumber, int pageSize);
    }
}
