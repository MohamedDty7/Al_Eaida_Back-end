using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.InsuranceInfoDTO
{
    public class InsuranceInfoDTO
    {
        public Guid Id { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public string? GroupNumber { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
























