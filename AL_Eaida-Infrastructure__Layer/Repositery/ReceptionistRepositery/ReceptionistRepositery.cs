using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.ReceptionistRepositery
{
    public class ReceptionistRepositery : GenaricRepositery<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<Receptionist?> GetByUserIdAsync(string userId)
        {
            return await _context.Set<Receptionist>()
                .FirstOrDefaultAsync(r => r.UserId == userId);
        }

        public async Task<IEnumerable<Receptionist>> GetByDepartmentAsync(string department)
        {
            return await _context.Set<Receptionist>()
                .Where(r => r.Department == department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receptionist>> GetActiveReceptionistsAsync()
        {
            return await _context.Set<Receptionist>()
                .Where(r => r.IsActive)
                .ToListAsync();
        }
    }
}
