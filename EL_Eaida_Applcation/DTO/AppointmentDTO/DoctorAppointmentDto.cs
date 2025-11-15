using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class DoctorAppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string DoctorSpecialization { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class DoctorAppointmentSummaryDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
    }

    public class DoctorAppointmentStatusUpdateDto
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Notes { get; set; }
    }

    public class DoctorAppointmentFilterDto
    {
        public Guid? DoctorId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public string? PatientName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class DoctorAppointmentStatsDto
    {
        public int TotalAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int InProgressAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int TodayAppointments { get; set; }
        public int TomorrowAppointments { get; set; }
    }
}

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class doctorAppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string DoctorSpecialization { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class doctorAppointmentSummaryDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; } = string.Empty;
        public AppointmentStatus Status { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
    }

    public class doctorAppointmentStatusUpdateDto
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Notes { get; set; }
    }

    public class doctorAppointmentFilterDto
    {
        public Guid? DoctorId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public string? PatientName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class doctorAppointmentStatsDto
    {
        public int TotalAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int InProgressAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int TodayAppointments { get; set; }
        public int TomorrowAppointments { get; set; }
    }
}














