namespace EL_Eaida_Applcation.DTO.MedicationCategoryDTO
{
    public class MedicationCategoryDTO
    {
        public Guid Id { get; set; }
        public Guid MedicationId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? MedicationName { get; set; }
        public string? CategoryName { get; set; }
    }
}
