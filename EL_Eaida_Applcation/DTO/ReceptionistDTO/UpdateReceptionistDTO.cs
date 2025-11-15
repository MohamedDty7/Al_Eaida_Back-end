using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ReceptionistDTO
{
    public class UpdateReceptionistDTO
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(50)]
        public string? EmployeeId { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(200)]
        public string? ProfileImage { get; set; }

        public bool? IsActive { get; set; }
    }
}
