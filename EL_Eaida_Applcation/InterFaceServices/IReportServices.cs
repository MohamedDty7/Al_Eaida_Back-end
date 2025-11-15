using EL_Eaida_Applcation.DTO.ReportDTO;
using Al_Eaida_Domin.Modules;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IReportServices
    {
        Task<ReportDTO> CreateReportAsync(CreateReportDTO createDto);
        Task<ReportDTO?> GetReportByIdAsync(Guid id);
        Task<IEnumerable<ReportDTO>> GetAllReportsAsync();
        Task<IEnumerable<ReportDTO>> GetReportsByTypeAsync(ReportType type);
        Task<IEnumerable<ReportDTO>> GetReportsByUserAsync(string userId);
        Task<IEnumerable<ReportDTO>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ReportDTO?> UpdateReportAsync(UpdateReportDTO updateDto);
        Task<bool> DeleteReportAsync(Guid id);
    }
}
