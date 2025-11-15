using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.AddressDTO
{
    public class UpdateAddressDTO
    {
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public Guid? CityId { get; set; }
        public Guid? GovernorateId { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
    }
}





