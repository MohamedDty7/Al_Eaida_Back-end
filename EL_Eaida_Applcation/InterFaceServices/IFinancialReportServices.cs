using EL_Eaida_Applcation.DTO.FinancialReportDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IFinancialReportServices
    {
        Task<FinancialReportDTO> CreateReportAsync(CreateFinancialReportDTO createDto);
        Task<FinancialReportDTO?> GetReportByIdAsync(Guid id);
        Task<IEnumerable<FinancialReportDTO>> GetAllReportsAsync();
        Task<IEnumerable<FinancialReportDTO>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<FinancialReportDTO?> GetLatestReportAsync();
        Task<IEnumerable<FinancialReportDTO>> GetReportsByYearAsync(int year);
        Task<FinancialReportDTO?> UpdateReportAsync(UpdateFinancialReportDTO updateDto);
        Task<bool> DeleteReportAsync(Guid id);
    }
}
