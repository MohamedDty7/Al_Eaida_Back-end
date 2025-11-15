using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ClinicSettingsDTO
{
    public class UpdateClinicSettingsDTO
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string? ClinicName { get; set; }

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
        public int? DefaultAppointmentDuration { get; set; }
        public int? MaxAppointmentsPerDay { get; set; }
        public bool? AllowOnlineBooking { get; set; }
        public bool? RequireAppointmentConfirmation { get; set; }
    }
}
