using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.ReceptionistDTO
{
    public class CreateReceptionistDTO
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(50)]
        public string? EmployeeId { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(200)]
        public string? ProfileImage { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
