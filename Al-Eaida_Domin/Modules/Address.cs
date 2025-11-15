using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class Address : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Street { get; set; } = string.Empty;

        [StringLength(20)]
        public string? ZipCode { get; set; }

        [StringLength(100)]
        public string? Country { get; set; } = "مصر";

        // Foreign Keys
        public Guid? GovernorateId { get; set; }
        public Guid? CityId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Governorate? Governorate { get; set; }
        public virtual City? City { get; set; }
    }
}