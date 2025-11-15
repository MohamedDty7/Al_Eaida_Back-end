using System;
using System.Linq;
using System.Threading.Tasks;
using AL_Eaida_Infrastructure__Layer;
using Al_Eaida_Domin.Modules;
using Al_Eaida_Domin.Interface;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Hubs;

namespace WebApplication1.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDBcontext _context;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(AppDBcontext context, IHubContext<NotificationHub> hubContext, INotificationRepository notificationRepository)
        {
            _context = context;
            _hubContext = hubContext;
            _notificationRepository = notificationRepository;
        }

        public async Task SendAsync(
            string title,
            string message,
            Al_Eaida_Domin.Modules.NotificationType type,
            Guid? doctorId = null,
            Guid? patientId = null,
            Guid? appointmentId = null,
            string? userId = null,
            params string[] groups)
        {
            var notification = new Al_Eaida_Domin.Modules.Notification
            {
                Title = title,
                Message = message,
                Type = type,
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentId = appointmentId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            await _notificationRepository.AddAsync(notification);

            var payload = new
            {
                id = notification.Id,
                title = notification.Title,
                message = notification.Message,
                type = notification.Type.ToString(),
                doctorId = notification.DoctorId,
                patientId = notification.PatientId,
                appointmentId = notification.AppointmentId,
                userId = notification.UserId,
                createdAt = notification.CreatedAt
            };

            foreach (var group in groups.Distinct())
            {
                await _hubContext.Clients.Group(group).SendAsync("ReceiveNotification", payload);
            }
        }

        public async Task NotifyAppointmentCreatedAsync(Guid appointmentId, Guid doctorId, Guid patientId, string? userId)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            var doctorGroup = $"Doctor_{doctorId}";
            await SendAsync(
                title: "إضافة حالة جديدة",
                message: "تم إضافة حالة جديدة إلى جدولك",
                type: Al_Eaida_Domin.Modules.NotificationType.AppointmentCreated,
                doctorId: doctorId,
                patientId: patientId,
                appointmentId: appointment?.Id,
                userId: userId,
                groups: new[] { doctorGroup, "Admin" }
            );
        }

        public async Task NotifyAppointmentStartedAsync(Guid appointmentId, Guid? doctorId, Guid? patientId)
        {
            await SendAsync(
                title: "بدء الفحص",
                message: "تم بدء فحص الحالة",
                type: Al_Eaida_Domin.Modules.NotificationType.AppointmentStarted,
                doctorId: doctorId,
                patientId: patientId,
                appointmentId: appointmentId,
                groups: new[] { "Receptionist", "Admin" }
            );
        }

        public async Task NotifyAppointmentCompletedAsync(Guid appointmentId, Guid? doctorId, Guid? patientId)
        {
            await SendAsync(
                title: "انتهاء الفحص",
                message: "تم انتهاء فحص الحالة",
                type: Al_Eaida_Domin.Modules.NotificationType.AppointmentCompleted,
                doctorId: doctorId,
                patientId: patientId,
                appointmentId: appointmentId,
                groups: new[] { "Receptionist", "Admin" }
            );
        }

        public async Task NotifyAppointmentCancelledAsync(Guid appointmentId, Guid? doctorId, Guid? patientId, string? cancelledByUserId)
        {
            await SendAsync(
                title: "إلغاء الموعد",
                message: "تم إلغاء الموعد",
                type: Al_Eaida_Domin.Modules.NotificationType.AppointmentCancelled,
                doctorId: doctorId,
                patientId: patientId,
                appointmentId: appointmentId,
                userId: cancelledByUserId,
                groups: new[] { "Admin", "Receptionist", doctorId.HasValue ? $"Doctor_{doctorId}" : string.Empty }
                    .Where(g => !string.IsNullOrWhiteSpace(g))
                    .ToArray()
            );
        }

        // New methods for notification management
        public async Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetDoctorNotificationsAsync(Guid doctorId)
        {
            return await _notificationRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUnreadUserNotificationsAsync(string userId)
        {
            return await _notificationRepository.GetUnreadByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetUnreadDoctorNotificationsAsync(Guid doctorId)
        {
            return await _notificationRepository.GetUnreadByDoctorIdAsync(doctorId);
        }

        public async Task<bool> MarkNotificationAsReadAsync(Guid notificationId)
        {
            return await _notificationRepository.MarkAsReadAsync(notificationId);
        }

        public async Task<bool> MarkAllUserNotificationsAsReadAsync(string userId)
        {
            return await _notificationRepository.MarkAsReadByUserIdAsync(userId);
        }

        public async Task<int> GetUnreadCountForUserAsync(string userId)
        {
            return await _notificationRepository.GetUnreadCountByUserIdAsync(userId);
        }

        public async Task<int> GetUnreadCountForDoctorAsync(Guid doctorId)
        {
            return await _notificationRepository.GetUnreadCountByDoctorIdAsync(doctorId);
        }

        public async Task<bool> DeleteNotificationAsync(Guid notificationId)
        {
            return await _notificationRepository.DeleteAsync(notificationId);
        }

        public async Task<IEnumerable<Al_Eaida_Domin.Modules.Notification>> GetRecentNotificationsAsync(int count = 10)
        {
            return await _notificationRepository.GetRecentNotificationsAsync(count);
        }

        // Doctor availability notifications
        public async Task NotifyDoctorAvailabilityAsync(Guid doctorId, string doctorName, bool isAvailable)
        {
            var status = isAvailable ? "متاح" : "غير متاح";
            var message = isAvailable 
                ? $"الدكتور {doctorName} متاح الآن للاستقبال"
                : $"الدكتور {doctorName} غير متاح حالياً";

            await SendAsync(
                title: $"حالة الطبيب - {status}",
                message: message,
                type: Al_Eaida_Domin.Modules.NotificationType.SystemAlert,
                doctorId: doctorId,
                groups: new[] { "Admin", "Receptionist" }
            );
        }

        // Notify when doctor is added to system
        public async Task NotifyNewDoctorAddedAsync(Guid doctorId, string doctorName, string specialization)
        {
            await SendAsync(
                title: "طبيب جديد",
                message: $"تم إضافة الدكتور {doctorName} - تخصص {specialization}",
                type: Al_Eaida_Domin.Modules.NotificationType.SystemAlert,
                doctorId: doctorId,
                groups: new[] { "Admin", "Receptionist" }
            );
        }

        // Notify when doctor becomes active/inactive
        public async Task NotifyDoctorStatusChangeAsync(Guid doctorId, string doctorName, bool isActive)
        {
            var status = isActive ? "نشط" : "غير نشط";
            var message = $"الدكتور {doctorName} أصبح {status}";

            await SendAsync(
                title: $"تغيير حالة الطبيب",
                message: message,
                type: Al_Eaida_Domin.Modules.NotificationType.SystemAlert,
                doctorId: doctorId,
                groups: new[] { "Admin", "Receptionist" }
            );
        }
    }
}


