using EL_Eaida_Applcation.DTO.MedicationCategoryDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IMedicationCategoryServices
    {
        Task<MedicationCategoryDTO> CreateCategoryAsync(CreateMedicationCategoryDTO createDto);
        Task<MedicationCategoryDTO?> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<MedicationCategoryDTO>> GetAllCategoriesAsync();
        Task<IEnumerable<MedicationCategoryDTO>> GetCategoriesByMedicineIdAsync(Guid medicineId);
        Task<IEnumerable<MedicationCategoryDTO>> GetMedicinesByCategoryIdAsync(Guid categoryId);
        Task<MedicationCategoryDTO?> UpdateCategoryAsync(UpdateMedicationCategoryDTO updateDto);
        Task<bool> DeleteCategoryAsync(Guid id);
    }
}
