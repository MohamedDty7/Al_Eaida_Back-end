using System;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface INotificationService
    {
        Task SendAsync(
            string title,
            string message,
            Al_Eaida_Domin.Modules.NotificationType type,
            Guid? doctorId = null,
            Guid? patientId = null,
            Guid? appointmentId = null,
            string? userId = null,
            params string[] groups);

        Task NotifyAppointmentCreatedAsync(Guid appointmentId, Guid doctorId, Guid patientId, string? userId);
        Task NotifyAppointmentStartedAsync(Guid appointmentId, Guid? doctorId, Guid? patientId);
        Task NotifyAppointmentCompletedAsync(Guid appointmentId, Guid? doctorId, Guid? patientId);
        Task NotifyAppointmentCancelledAsync(Guid appointmentId, Guid? doctorId, Guid? patientId, string? cancelledByUserId);

        // Notification management methods
        Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUserNotificationsAsync(string userId);
        Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetDoctorNotificationsAsync(Guid doctorId);
        Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUnreadUserNotificationsAsync(string userId);
        Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUnreadDoctorNotificationsAsync(Guid doctorId);
        Task<bool> MarkNotificationAsReadAsync(Guid notificationId);
        Task<bool> MarkAllUserNotificationsAsReadAsync(string userId);
        Task<int> GetUnreadCountForUserAsync(string userId);
        Task<int> GetUnreadCountForDoctorAsync(Guid doctorId);
        Task<bool> DeleteNotificationAsync(Guid notificationId);
        Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetRecentNotificationsAsync(int count = 10);

        // Doctor availability notifications
        Task NotifyDoctorAvailabilityAsync(Guid doctorId, string doctorName, bool isAvailable);
        Task NotifyNewDoctorAddedAsync(Guid doctorId, string doctorName, string specialization);
        Task NotifyDoctorStatusChangeAsync(Guid doctorId, string doctorName, bool isActive);
    }
}


