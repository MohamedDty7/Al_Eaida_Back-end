using Al_Eaida_Domin.Modules;
using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.SystemSettingsDTO
{
    public class UpdateSystemSettingsDTO
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? Key { get; set; }

        [StringLength(1000)]
        public string? Value { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public SettingType? Type { get; set; }
        public bool? IsActive { get; set; }
    }
}
