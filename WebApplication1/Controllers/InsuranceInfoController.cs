using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.InsuranceInfoDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceInfoController : ControllerBase
    {
        private readonly IInsuranceInfoServices _insuranceInfoServices;

        public InsuranceInfoController(IInsuranceInfoServices insuranceInfoServices)
        {
            _insuranceInfoServices = insuranceInfoServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsuranceInfo([FromBody] CreateInsuranceInfoDTO createInsuranceInfoDTO)
        {
            try
            {
                var insuranceInfo = await _insuranceInfoServices.CreateInsuranceInfoAsync(createInsuranceInfoDTO);
                return CreatedAtAction(nameof(GetInsuranceInfoById), new { id = insuranceInfo.Id }, insuranceInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء معلومات التأمين: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsuranceInfoById(Guid id)
        {
            var insuranceInfo = await _insuranceInfoServices.GetInsuranceInfoByIdAsync(id);
            if (insuranceInfo == null)
            {
                return NotFound("معلومات التأمين غير موجودة");
            }
            return Ok(insuranceInfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInsuranceInfos()
        {
            var insuranceInfos = await _insuranceInfoServices.GetAllInsuranceInfosAsync();
            return Ok(insuranceInfos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInsuranceInfo([FromBody] UpdateInsuranceInfoDTO updateInsuranceInfoDTO)
        {
            try
            {
                var insuranceInfo = await _insuranceInfoServices.UpdateInsuranceInfoAsync(updateInsuranceInfoDTO);
                if (insuranceInfo == null)
                {
                    return NotFound("معلومات التأمين غير موجودة");
                }
                return Ok(insuranceInfo);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث معلومات التأمين: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceInfo(Guid id)
        {
            var result = await _insuranceInfoServices.DeleteInsuranceInfoAsync(id);
            if (!result)
            {
                return NotFound("معلومات التأمين غير موجودة");
            }
            return Ok("تم حذف معلومات التأمين بنجاح");
        }
    }
}
























