using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.SystemSettingsDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Al_Eaida_Domin.Modules;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemSettingsController : ControllerBase
    {
        private readonly ISystemSettingsServices _systemSettingsServices;

        public SystemSettingsController(ISystemSettingsServices systemSettingsServices)
        {
            _systemSettingsServices = systemSettingsServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSetting([FromBody] CreateSystemSettingsDTO createDto)
        {
            try
            {
                var setting = await _systemSettingsServices.CreateSettingAsync(createDto);
                return CreatedAtAction(nameof(GetSettingById), new { id = setting.Id }, setting);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء الإعداد: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSettingById(Guid id)
        {
            var setting = await _systemSettingsServices.GetSettingByIdAsync(id);
            if (setting == null)
            {
                return NotFound("الإعداد غير موجود");
            }
            return Ok(setting);
        }

        [HttpGet("key/{key}")]
        public async Task<IActionResult> GetSettingByKey(string key)
        {
            var setting = await _systemSettingsServices.GetSettingByKeyAsync(key);
            if (setting == null)
            {
                return NotFound("الإعداد غير موجود");
            }
            return Ok(setting);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSettings()
        {
            var settings = await _systemSettingsServices.GetAllSettingsAsync();
            return Ok(settings);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetSettingsByType(int type)
        {
            var settings = await _systemSettingsServices.GetSettingsByTypeAsync((SettingType)type);
            return Ok(settings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSetting([FromBody] UpdateSystemSettingsDTO updateDto)
        {
            try
            {
                var setting = await _systemSettingsServices.UpdateSettingAsync(updateDto);
                if (setting == null)
                {
                    return NotFound("الإعداد غير موجود");
                }
                return Ok(setting);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث الإعداد: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetting(Guid id)
        {
            var result = await _systemSettingsServices.DeleteSettingAsync(id);
            if (!result)
            {
                return NotFound("الإعداد غير موجود");
            }
            return Ok("تم حذف الإعداد بنجاح");
        }
    }
}
