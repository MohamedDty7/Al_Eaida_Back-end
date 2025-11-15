using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IAuditLogRepository : IGenericRepositery<AuditLog>
    {
        Task<IEnumerable<AuditLog>> GetLogsByTableAsync(string tableName);
        Task<IEnumerable<AuditLog>> GetLogsByUserAsync(string userId);
        Task<IEnumerable<AuditLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AuditLog>> GetLogsByActionAsync(string action);
    }
}
