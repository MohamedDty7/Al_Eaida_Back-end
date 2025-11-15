using EL_Eaida_Applcation.DTO.SystemSettingsDTO;
using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface ISystemSettingsServices
    {
        Task<SystemSettingsDTO> CreateSettingAsync(CreateSystemSettingsDTO createDto);
        Task<SystemSettingsDTO?> GetSettingByIdAsync(Guid id);
        Task<SystemSettingsDTO?> GetSettingByKeyAsync(string key);
        Task<IEnumerable<SystemSettingsDTO>> GetAllSettingsAsync();
        Task<IEnumerable<SystemSettingsDTO>> GetSettingsByTypeAsync(SettingType type);
        Task<SystemSettingsDTO?> UpdateSettingAsync(UpdateSystemSettingsDTO updateDto);
        Task<bool> DeleteSettingAsync(Guid id);
    }
}
