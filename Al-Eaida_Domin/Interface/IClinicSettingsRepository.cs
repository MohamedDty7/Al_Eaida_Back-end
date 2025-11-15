using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IClinicSettingsRepository : IGenericRepositery<ClinicSettings>
    {
        Task<ClinicSettings?> GetActiveSettingsAsync();
        Task<bool> UpdateSettingsAsync(ClinicSettings settings);
    }
}
