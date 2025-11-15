using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.SystemSettingsRepositery
{
    public class SystemSettingsRepositery : GenaricRepositery<SystemSettings>, ISystemSettingsRepository
    {
        public SystemSettingsRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<SystemSettings?> GetByKeyAsync(string key)
        {
            return await _context.Set<SystemSettings>()
                .FirstOrDefaultAsync(s => s.Key == key);
        }

        public async Task<IEnumerable<SystemSettings>> GetByTypeAsync(SettingType type)
        {
            return await _context.Set<SystemSettings>()
                .Where(s => s.Type == type)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemSettings>> GetActiveSettingsAsync()
        {
            return await _context.Set<SystemSettings>()
                .Where(s => s.IsActive)
                .ToListAsync();
        }
    }
}
