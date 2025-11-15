using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class MedicalRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnosis { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Treatment { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
    }

}