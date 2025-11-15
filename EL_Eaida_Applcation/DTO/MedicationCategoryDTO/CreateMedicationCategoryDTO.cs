using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.MedicationCategoryDTO
{
    public class CreateMedicationCategoryDTO
    {
        [Required]
        public Guid MedicationId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
