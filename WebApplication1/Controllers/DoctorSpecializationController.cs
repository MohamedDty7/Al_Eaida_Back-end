using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.DoctorSpecializationDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorSpecializationController : ControllerBase
    {
        private readonly IDoctorSpecializationServices _doctorSpecializationServices;

        public DoctorSpecializationController(IDoctorSpecializationServices doctorSpecializationServices)
        {
            _doctorSpecializationServices = doctorSpecializationServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateDoctorSpecializationDTO createDto)
        {
            try
            {
                var specialization = await _doctorSpecializationServices.CreateSpecializationAsync(createDto);
                return CreatedAtAction(nameof(GetSpecializationById), new { id = specialization.Id }, specialization);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء التخصص: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecializationById(Guid id)
        {
            var specialization = await _doctorSpecializationServices.GetSpecializationByIdAsync(id);
            if (specialization == null)
            {
                return NotFound("التخصص غير موجود");
            }
            return Ok(specialization);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecializations()
        {
            var specializations = await _doctorSpecializationServices.GetAllSpecializationsAsync();
            return Ok(specializations);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetSpecializationsByDoctorId(Guid doctorId)
        {
            var specializations = await _doctorSpecializationServices.GetSpecializationsByDoctorIdAsync(doctorId);
            return Ok(specializations);
        }

        [HttpGet("specialization/{specializationId}")]
        public async Task<IActionResult> GetDoctorsBySpecializationId(Guid specializationId)
        {
            var specializations = await _doctorSpecializationServices.GetDoctorsBySpecializationIdAsync(specializationId);
            return Ok(specializations);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialization(Guid id)
        {
            var result = await _doctorSpecializationServices.DeleteSpecializationAsync(id);
            if (!result)
            {
                return NotFound("التخصص غير موجود");
            }
            return Ok("تم حذف التخصص بنجاح");
        }
    }
}
