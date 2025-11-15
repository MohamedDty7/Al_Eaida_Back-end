using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.EmergencyContactDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyContactController : ControllerBase
    {
        private readonly IEmergencyContactServices _emergencyContactServices;

        public EmergencyContactController(IEmergencyContactServices emergencyContactServices)
        {
            _emergencyContactServices = emergencyContactServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmergencyContact([FromBody] CreateEmergencyContactDTO createEmergencyContactDTO)
        {
            try
            {
                var emergencyContact = await _emergencyContactServices.CreateEmergencyContactAsync(createEmergencyContactDTO);
                return CreatedAtAction(nameof(GetEmergencyContactById), new { id = emergencyContact.Id }, emergencyContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء جهة الاتصال الطارئة: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmergencyContactById(Guid id)
        {
            var emergencyContact = await _emergencyContactServices.GetEmergencyContactByIdAsync(id);
            if (emergencyContact == null)
            {
                return NotFound("جهة الاتصال الطارئة غير موجودة");
            }
            return Ok(emergencyContact);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmergencyContacts()
        {
            var emergencyContacts = await _emergencyContactServices.GetAllEmergencyContactsAsync();
            return Ok(emergencyContacts);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmergencyContact([FromBody] UpdateEmergencyContactDTO updateEmergencyContactDTO)
        {
            try
            {
                var emergencyContact = await _emergencyContactServices.UpdateEmergencyContactAsync(updateEmergencyContactDTO);
                if (emergencyContact == null)
                {
                    return NotFound("جهة الاتصال الطارئة غير موجودة");
                }
                return Ok(emergencyContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث جهة الاتصال الطارئة: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyContact(Guid id)
        {
            var result = await _emergencyContactServices.DeleteEmergencyContactAsync(id);
            if (!result)
            {
                return NotFound("جهة الاتصال الطارئة غير موجودة");
            }
            return Ok("تم حذف جهة الاتصال الطارئة بنجاح");
        }
    }
}
























