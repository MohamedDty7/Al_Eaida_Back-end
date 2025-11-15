using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.InsuranceInfoDTO
{
    public class CreateInsuranceInfoDTO
    {
        [Required]
        [StringLength(100)]
        public string Provider { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string? GroupNumber { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }
    }
}
























