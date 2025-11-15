using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.ClinicSettingsDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicSettingsController : ControllerBase
    {
        private readonly IClinicSettingsServices _clinicSettingsServices;

        public ClinicSettingsController(IClinicSettingsServices clinicSettingsServices)
        {
            _clinicSettingsServices = clinicSettingsServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSettings([FromBody] CreateClinicSettingsDTO createDto)
        {
            try
            {
                var settings = await _clinicSettingsServices.CreateSettingsAsync(createDto);
                return CreatedAtAction(nameof(GetSettingsById), new { id = settings.Id }, settings);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء إعدادات العيادة: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSettingsById(Guid id)
        {
            var settings = await _clinicSettingsServices.GetSettingsByIdAsync(id);
            if (settings == null)
            {
                return NotFound("إعدادات العيادة غير موجودة");
            }
            return Ok(settings);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveSettings()
        {
            var settings = await _clinicSettingsServices.GetActiveSettingsAsync();
            if (settings == null)
            {
                return NotFound("لا توجد إعدادات نشطة");
            }
            return Ok(settings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSettings([FromBody] UpdateClinicSettingsDTO updateDto)
        {
            try
            {
                var settings = await _clinicSettingsServices.UpdateSettingsAsync(updateDto);
                if (settings == null)
                {
                    return NotFound("إعدادات العيادة غير موجودة");
                }
                return Ok(settings);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث إعدادات العيادة: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSettings(Guid id)
        {
            var result = await _clinicSettingsServices.DeleteSettingsAsync(id);
            if (!result)
            {
                return NotFound("إعدادات العيادة غير موجودة");
            }
            return Ok("تم حذف إعدادات العيادة بنجاح");
        }
    }
}
