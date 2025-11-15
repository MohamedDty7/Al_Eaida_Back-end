using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.InsuranceInfoDTO
{
    public class UpdateInsuranceInfoDTO
    {
        public Guid Id { get; set; }
        public string? Provider { get; set; }
        public string? PolicyNumber { get; set; }
        public string? GroupNumber { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
























