using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.AddressDTO;
using EL_Eaida_Applcation.DTO.EmergencyContactDTO;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Guid? AddressId { get; set; }
        public Guid? EmergencyContactId { get; set; }
        public Guid? InsuranceInfoId { get; set; }
        public bool IsActive { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        
        // Navigation properties
        public AddressDTO.AddressDTO? Address { get; set; }
        public EmergencyContactDTO.EmergencyContactDTO? EmergencyContact { get; set; }
    }
}
