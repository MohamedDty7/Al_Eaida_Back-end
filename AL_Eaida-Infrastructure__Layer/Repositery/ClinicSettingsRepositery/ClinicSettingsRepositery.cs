using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.ClinicSettingsRepositery
{
    public class ClinicSettingsRepositery : GenaricRepositery<ClinicSettings>, IClinicSettingsRepository
    {
        public ClinicSettingsRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<ClinicSettings?> GetActiveSettingsAsync()
        {
            return await _context.Set<ClinicSettings>()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSettingsAsync(ClinicSettings settings)
        {
            try
            {
                _context.Set<ClinicSettings>().Update(settings);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
