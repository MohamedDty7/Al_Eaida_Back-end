using System.ComponentModel.DataAnnotations;

namespace Al_Eaida_Domin.Modules
{
    public class City : BaseEntity
    {
        [Required]
        public Guid GovernorateId { get; set; }
        [Required]
        [StringLength(100)]
        public string NameAr { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NameEn { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual Governorate Governorate { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }

}



















