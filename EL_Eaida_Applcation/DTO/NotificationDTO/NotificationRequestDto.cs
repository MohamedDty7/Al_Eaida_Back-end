using System;

namespace EL_Eaida_Applcation.DTO.NotificationDTO
{
    public class DoctorAvailabilityNotificationDto
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }

    public class NewDoctorNotificationDto
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
    }

    public class DoctorStatusChangeNotificationDto
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

