using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{

    public class DoctorSpecialization
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid SpecializationId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Specialization Specialization { get; set; } = null!;
    }

}