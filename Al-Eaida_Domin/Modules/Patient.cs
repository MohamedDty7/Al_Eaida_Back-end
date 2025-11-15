using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Patient :BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
         
        [Required]
        [StringLength(50)]
        
        public string FullName { get; set; } = string.Empty; 

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public Guid? AddressId { get; set; }

        public Guid? EmergencyContactId { get; set; }

        public Guid? InsuranceInfoId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Address Address { get; set; } = null!;
        public virtual EmergencyContact EmergencyContact { get; set; } = null!;
        public virtual InsuranceInfo? InsuranceInfo { get; set; }
        public virtual ICollection<MedicalVisit> MedicalVisits { get; set; } = new List<MedicalVisit>();
        public virtual ICollection<MedicalRecord> MedicalHistory { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}