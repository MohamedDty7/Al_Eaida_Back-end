using EL_Eaida_Applcation.DTO.ClinicSettingsDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IClinicSettingsServices
    {
        Task<ClinicSettingsDTO> CreateSettingsAsync(CreateClinicSettingsDTO createDto);
        Task<ClinicSettingsDTO?> GetSettingsByIdAsync(Guid id);
        Task<ClinicSettingsDTO?> GetActiveSettingsAsync();
        Task<ClinicSettingsDTO?> UpdateSettingsAsync(UpdateClinicSettingsDTO updateDto);
        Task<bool> DeleteSettingsAsync(Guid id);
    }
}
