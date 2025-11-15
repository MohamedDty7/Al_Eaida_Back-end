using System;
using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class Notification : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public NotificationType Type { get; set; }

        public string? UserId { get; set; }
        public virtual User? User { get; set; }

        public Guid? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

        public Guid? PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

        public Guid? AppointmentId { get; set; }
        public virtual Appointment? Appointment { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }

        [StringLength(2000)]
        public string? Data { get; set; } // JSON data for additional information
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
}














