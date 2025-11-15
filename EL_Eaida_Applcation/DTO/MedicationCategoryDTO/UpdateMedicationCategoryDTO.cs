using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.MedicationCategoryDTO
{
    public class UpdateMedicationCategoryDTO
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? MedicationId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
