using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class SystemSettings : BaseEntity
    {


        [Required]
        [StringLength(100)]
        public string Key { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Value { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public SettingType Type { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum SettingType
    {
        String,
        Integer,
        Boolean,
        Decimal,
        DateTime,

    }
}
