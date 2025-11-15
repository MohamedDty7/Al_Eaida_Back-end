using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.LocationDTO;

namespace EL_Eaida_Applcation.DTO.AddressDTO
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public Guid? GovernorateId { get; set; }
        public Guid? CityId { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        
        // Navigation properties
        public GovernorateDTO? Governorate { get; set; }
        public CityDTO? City { get; set; }
    }
}





