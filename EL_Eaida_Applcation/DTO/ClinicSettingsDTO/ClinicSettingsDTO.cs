namespace EL_Eaida_Applcation.DTO.ClinicSettingsDTO
{
    public class ClinicSettingsDTO
    {
        public Guid Id { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LogoPath { get; set; }
        public TimeSpan? WorkingHoursStart { get; set; }
        public TimeSpan? WorkingHoursEnd { get; set; }
        public int? DefaultAppointmentDuration { get; set; }
        public int? MaxAppointmentsPerDay { get; set; }
        public bool AllowOnlineBooking { get; set; }
        public bool RequireAppointmentConfirmation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
