using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IReportRepository : IGenericRepositery<Report>
    {
        Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType type);
        Task<IEnumerable<Report>> GetReportsByUserAsync(string userId);
        Task<IEnumerable<Report>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Report>> GetActiveReportsAsync();
    }
}
