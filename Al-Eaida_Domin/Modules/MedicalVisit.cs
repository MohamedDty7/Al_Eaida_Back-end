using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class MedicalVisit : BaseEntity
    {
     
        public DateTime VisitDate { get; set; } = DateTime.UtcNow;
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public string UserID { get; set; } = string.Empty;
        public virtual User User { get; set; } = null!;

        public Guid DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
