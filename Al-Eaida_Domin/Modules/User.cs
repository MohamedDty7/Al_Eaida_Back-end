using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Al_Eaida_Domin.Modules
{
    public class User : IdentityUser
    {
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalVisit> MedicalVisits { get; set; } = new List<MedicalVisit>();
        public virtual ICollection<Invoice> CreatedInvoices { get; set; } = new List<Invoice>();
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    }
}
