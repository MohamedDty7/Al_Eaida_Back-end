using EL_Eaida_Applcation.DTO.AuditLogDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IAuditLogServices
    {
        Task<AuditLogDTO> CreateLogAsync(CreateAuditLogDTO createDto);
        Task<AuditLogDTO?> GetLogByIdAsync(Guid id);
        Task<IEnumerable<AuditLogDTO>> GetAllLogsAsync();
        Task<IEnumerable<AuditLogDTO>> GetLogsByTableAsync(string tableName);
        Task<IEnumerable<AuditLogDTO>> GetLogsByUserAsync(string userId);
        Task<IEnumerable<AuditLogDTO>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AuditLogDTO>> GetLogsByActionAsync(string action);
    }
}
