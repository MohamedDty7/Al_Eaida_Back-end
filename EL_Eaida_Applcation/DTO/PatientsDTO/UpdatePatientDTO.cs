using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public class UpdatePatientDTO
    {
        public Guid Id { get; set; } // ضروري لتحديد المريض
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? EmergencyContactId { get; set; }
        public Guid? InsuranceInfoId { get; set; }
        public bool? IsActive { get; set; }
    }
}

