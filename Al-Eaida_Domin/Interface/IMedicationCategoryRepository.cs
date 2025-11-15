using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface IMedicationCategoryRepository : IGenericRepositery<MedicationCategory>
    {
        Task<IEnumerable<MedicationCategory>> GetCategoriesByMedicineIdAsync(Guid medicineId);
        Task<IEnumerable<MedicationCategory>> GetMedicinesByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<MedicationCategory>> GetActiveCategoriesAsync();
    }
}
