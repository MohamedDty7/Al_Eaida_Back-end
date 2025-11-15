using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.AuditLogRepositery
{
    public class AuditLogRepositery : GenaricRepositery<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByTableAsync(string tableName)
        {
            return await _context.Set<AuditLog>()
                .Where(l => l.TableName == tableName)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByUserAsync(string userId)
        {
            return await _context.Set<AuditLog>()
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Set<AuditLog>()
                .Where(l => l.Timestamp >= startDate && l.Timestamp <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByActionAsync(string action)
        {
            return await _context.Set<AuditLog>()
                .Where(l => l.Action == action)
                .ToListAsync();
        }
    }
}
