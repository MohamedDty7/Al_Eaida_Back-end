using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.SpecializationDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationServices _specializationServices;

        public SpecializationController(ISpecializationServices specializationServices)
        {
            _specializationServices = specializationServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationDTO createSpecializationDTO)
        {
            try
            {
                var specialization = await _specializationServices.CreateSpecializationAsync(createSpecializationDTO);
                return CreatedAtAction(nameof(GetSpecializationById), new { id = specialization.Id }, specialization);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء التخصص: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecializationById(string id)
        {
            var specialization = await _specializationServices.GetSpecializationByIdAsync(id);
            if (specialization == null)
            {
                return NotFound("التخصص غير موجود");
            }
            return Ok(specialization);
        }

        [HttpGet("GetAllSpecializations")]
        public async Task<IActionResult> GetAllSpecializations()
        {
            var specializations = await _specializationServices.GetAllSpecializationsAsync();
            return Ok(specializations);
        }

        [HttpPut("UpdateSpecialization")]
        public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationDTO updateSpecializationDTO)
        {
            try
            {
                var specialization = await _specializationServices.UpdateSpecializationAsync(updateSpecializationDTO);
                if (specialization == null)
                {
                    return NotFound("التخصص غير موجود");
                }
                return Ok(specialization);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث التخصص: {ex.Message}");
            }
        }

        [HttpDelete("DeleteSpecialization/{id}")]
        public async Task<IActionResult> DeleteSpecialization(string id)
        {
            var result = await _specializationServices.DeleteSpecializationAsync(id);
            if (!result)
            {
                return NotFound("التخصص غير موجود");
            }
            return Ok("تم حذف التخصص بنجاح");
        }
    }
}
























