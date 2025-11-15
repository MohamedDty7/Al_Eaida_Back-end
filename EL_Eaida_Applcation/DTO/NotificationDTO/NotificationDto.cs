using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.DTO.NotificationDTO
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string? UserId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public string? Data { get; set; } // JSON data for additional information
    }

    public class CreateNotificationDto
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string? UserId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public string? Data { get; set; }
    }

    public class NotificationSummaryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NotificationStatsDto
    {
        public int TotalNotifications { get; set; }
        public int UnreadNotifications { get; set; }
        public int AppointmentNotifications { get; set; }
        public int SystemNotifications { get; set; }
        public int EmergencyNotifications { get; set; }
    }
}

public enum NotificationType
{
    AppointmentCreated,
    AppointmentConfirmed,
    AppointmentStarted,
    AppointmentCompleted,
    AppointmentCancelled,
    AppointmentRescheduled,
    SystemAlert,
    EmergencyAlert,
    General
}

namespace EL_Eaida_Applcation.DTO.NotificationDTO
{
    public class NotificationDoctorDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string? UserId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public string? Data { get; set; } // JSON data for additional information
    }

    public class createNotificationDto
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string? UserId { get; set; }
        public string? DoctorId { get; set; }
        public string? PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public string? Data { get; set; }
    }

    public class NotificationSummaryedDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NotificationStatedDto
    {
        public int TotalNotifications { get; set; }
        public int UnreadNotifications { get; set; }
        public int AppointmentNotifications { get; set; }
        public int SystemNotifications { get; set; }
        public int EmergencyNotifications { get; set; }
    }
}

public enum Notification
{
    AppointmentCreated,
    AppointmentConfirmed,
    AppointmentStarted,
    AppointmentCompleted,
    AppointmentCancelled,
    AppointmentRescheduled,
    SystemAlert,
    EmergencyAlert,
    General
}






