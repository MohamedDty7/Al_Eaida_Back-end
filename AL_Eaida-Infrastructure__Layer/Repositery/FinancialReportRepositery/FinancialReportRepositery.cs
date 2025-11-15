using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.FinancialReportRepositery
{
    public class FinancialReportRepositery : GenaricRepositery<FinancialReport>, IFinancialReportRepository
    {
        public FinancialReportRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<FinancialReport>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Set<FinancialReport>()
                .Where(r => r.ReportDate >= startDate && r.ReportDate <= endDate)
                .ToListAsync();
        }

        public async Task<FinancialReport?> GetLatestReportAsync()
        {
            return await _context.Set<FinancialReport>()
                .OrderByDescending(r => r.ReportDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetReportsByYearAsync(int year)
        {
            return await _context.Set<FinancialReport>()
                .Where(r => r.ReportDate.Year == year)
                .ToListAsync();
        }
    }
}
