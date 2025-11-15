using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.DTO.SystemSettingsDTO
{
    public class SystemSettingsDTO
    {
        public Guid Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string? Description { get; set; }
        public SettingType Type { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
