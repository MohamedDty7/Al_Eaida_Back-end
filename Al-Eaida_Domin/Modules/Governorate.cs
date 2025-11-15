using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class Governorate : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string NameAr { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NameEn { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}



















