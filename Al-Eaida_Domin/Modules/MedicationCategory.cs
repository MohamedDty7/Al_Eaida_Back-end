using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<MedicationCategory> MedicationCategories { get; set; } = new List<MedicationCategory>();
    }

    public class MedicationCategory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid MedicationId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Medicine Medication { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }

}