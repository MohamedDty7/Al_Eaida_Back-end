using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.ReportRepositery
{
    public class ReportRepositery : GenaricRepositery<Report>, IReportRepository
    {
        public ReportRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType type)
        {
            return await _context.Set<Report>()
                .Where(r => r.Type == type)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByUserAsync(string userId)
        {
            return await _context.Set<Report>()
                .Where(r => r.GeneratedBy == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Set<Report>()
                .Where(r => r.GeneratedAt >= startDate && r.GeneratedAt <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetActiveReportsAsync()
        {
            return await _context.Set<Report>()
                .Where(r => r.IsActive)
                .ToListAsync();
        }
    }
}
