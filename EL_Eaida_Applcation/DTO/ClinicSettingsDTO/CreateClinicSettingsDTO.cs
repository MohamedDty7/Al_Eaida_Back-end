using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ClinicSettingsDTO
{
    public class CreateClinicSettingsDTO
    {
        [Required]
        [StringLength(200)]
        public string ClinicName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Website { get; set; }

        [StringLength(100)]
        public string? LicenseNumber { get; set; }

        [StringLength(200)]
        public string? LogoPath { get; set; }

        public TimeSpan? WorkingHoursStart { get; set; }
        public TimeSpan? WorkingHoursEnd { get; set; }
        public int? DefaultAppointmentDuration { get; set; } = 30;
        public int? MaxAppointmentsPerDay { get; set; }
        public bool AllowOnlineBooking { get; set; } = false;
        public bool RequireAppointmentConfirmation { get; set; } = true;
    }
}
