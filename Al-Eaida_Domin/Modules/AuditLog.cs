using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string TableName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty; // INSERT, UPDATE, DELETE

        [Required]
        public string RecordId { get; set; } = string.Empty;

        public string? OldValues { get; set; } // JSON

        public string? NewValues { get; set; } // JSON

        public string? UserId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [StringLength(200)]
        public string? IpAddress { get; set; }

        [StringLength(500)]
        public string? UserAgent { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
    }
   
}
