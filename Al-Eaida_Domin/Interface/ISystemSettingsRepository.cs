using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface ISystemSettingsRepository : IGenericRepositery<SystemSettings>
    {
        Task<SystemSettings?> GetByKeyAsync(string key);
        Task<IEnumerable<SystemSettings>> GetByTypeAsync(SettingType type);
        Task<IEnumerable<SystemSettings>> GetActiveSettingsAsync();
    }
}
