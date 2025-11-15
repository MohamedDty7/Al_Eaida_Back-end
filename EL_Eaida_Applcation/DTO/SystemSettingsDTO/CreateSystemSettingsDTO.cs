using Al_Eaida_Domin.Modules;
using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.SystemSettingsDTO
{
    public class CreateSystemSettingsDTO
    {
        [Required]
        [StringLength(100)]
        public string Key { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Value { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public SettingType Type { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
