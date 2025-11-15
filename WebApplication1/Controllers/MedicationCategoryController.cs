using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.MedicationCategoryDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationCategoryController : ControllerBase
    {
        private readonly IMedicationCategoryServices _medicationCategoryServices;

        public MedicationCategoryController(IMedicationCategoryServices medicationCategoryServices)
        {
            _medicationCategoryServices = medicationCategoryServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateMedicationCategoryDTO createDto)
        {
            try
            {
                var category = await _medicationCategoryServices.CreateCategoryAsync(createDto);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء الفئة: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _medicationCategoryServices.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("الفئة غير موجودة");
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _medicationCategoryServices.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("medicine/{medicineId}")]
        public async Task<IActionResult> GetCategoriesByMedicineId(Guid medicineId)
        {
            var categories = await _medicationCategoryServices.GetCategoriesByMedicineIdAsync(medicineId);
            return Ok(categories);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetMedicinesByCategoryId(Guid categoryId)
        {
            var categories = await _medicationCategoryServices.GetMedicinesByCategoryIdAsync(categoryId);
            return Ok(categories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateMedicationCategoryDTO updateDto)
        {
            try
            {
                var category = await _medicationCategoryServices.UpdateCategoryAsync(updateDto);
                if (category == null)
                {
                    return NotFound("الفئة غير موجودة");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث الفئة: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _medicationCategoryServices.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound("الفئة غير موجودة");
            }
            return Ok("تم حذف الفئة بنجاح");
        }
    }
}
