namespace EL_Eaida_Applcation.DTO.AuditLogDTO
{
    public class AuditLogDTO
    {
        public Guid Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string RecordId { get; set; } = string.Empty;
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? UserName { get; set; }
    }
}
