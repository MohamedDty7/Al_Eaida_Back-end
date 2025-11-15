using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer.IRepositery;

namespace AL_Eaida_Infrastructure__Layer.Repositery.MedicationCategoryRepositery
{
    public class MedicationCategoryRepositery : GenaricRepositery<MedicationCategory>, IMedicationCategoryRepository
    {
        public MedicationCategoryRepositery(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicationCategory>> GetCategoriesByMedicineIdAsync(Guid medicineId)
        {
            return await _context.Set<MedicationCategory>()
                .Where(c => c.MedicationId == medicineId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicationCategory>> GetMedicinesByCategoryIdAsync(Guid categoryId)
        {
            return await _context.Set<MedicationCategory>()
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicationCategory>> GetActiveCategoriesAsync()
        {
            return await _context.Set<MedicationCategory>()
                .Include(c => c.Category)
                .Where(c => c.Category != null && c.Category.IsActive)
                .ToListAsync();
        }
    }
}
