using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IFinancialReportRepository : IGenericRepositery<FinancialReport>
    {
        Task<IEnumerable<FinancialReport>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<FinancialReport?> GetLatestReportAsync();
        Task<IEnumerable<FinancialReport>> GetReportsByYearAsync(int year);
    }
}
