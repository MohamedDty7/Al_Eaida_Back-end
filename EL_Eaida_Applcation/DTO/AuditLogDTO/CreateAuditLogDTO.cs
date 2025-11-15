using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.AuditLogDTO
{
    public class CreateAuditLogDTO
    {
        [Required]
        [StringLength(100)]
        public string TableName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty;

        [Required]
        public string RecordId { get; set; } = string.Empty;

        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? UserId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
