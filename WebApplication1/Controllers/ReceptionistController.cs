using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.ReceptionistDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistServices _receptionistServices;

        public ReceptionistController(IReceptionistServices receptionistServices)
        {
            _receptionistServices = receptionistServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceptionist([FromBody] CreateReceptionistDTO createDto)
        {
            try
            {
                var receptionist = await _receptionistServices.CreateReceptionistAsync(createDto);
                return CreatedAtAction(nameof(GetReceptionistById), new { id = receptionist.Id }, receptionist);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء الاستقبال: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceptionistById(Guid id)
        {
            var receptionist = await _receptionistServices.GetReceptionistByIdAsync(id);
            if (receptionist == null)
            {
                return NotFound("الاستقبال غير موجود");
            }
            return Ok(receptionist);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReceptionistByUserId(string userId)
        {
            var receptionist = await _receptionistServices.GetReceptionistByUserIdAsync(userId);
            if (receptionist == null)
            {
                return NotFound("الاستقبال غير موجود");
            }
            return Ok(receptionist);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceptionists()
        {
            var receptionists = await _receptionistServices.GetAllReceptionistsAsync();
            return Ok(receptionists);
        }

        [HttpGet("department/{department}")]
        public async Task<IActionResult> GetReceptionistsByDepartment(string department)
        {
            var receptionists = await _receptionistServices.GetReceptionistsByDepartmentAsync(department);
            return Ok(receptionists);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReceptionist([FromBody] UpdateReceptionistDTO updateDto)
        {
            try
            {
                var receptionist = await _receptionistServices.UpdateReceptionistAsync(updateDto);
                if (receptionist == null)
                {
                    return NotFound("الاستقبال غير موجود");
                }
                return Ok(receptionist);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث الاستقبال: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceptionist(Guid id)
        {
            var result = await _receptionistServices.DeleteReceptionistAsync(id);
            if (!result)
            {
                return NotFound("الاستقبال غير موجود");
            }
            return Ok("تم حذف الاستقبال بنجاح");
        }
    }
}
