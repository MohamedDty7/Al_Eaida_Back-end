using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.ReportDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Al_Eaida_Domin.Modules;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _reportServices;

        public ReportController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportDTO createDto)
        {
            try
            {
                var report = await _reportServices.CreateReportAsync(createDto);
                return CreatedAtAction(nameof(GetReportById), new { id = report.Id }, report);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء التقرير: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            var report = await _reportServices.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound("التقرير غير موجود");
            }
            return Ok(report);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _reportServices.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetReportsByType(int type)
        {
            var reports = await _reportServices.GetReportsByTypeAsync((ReportType)type);
            return Ok(reports);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReportsByUser(string userId)
        {
            var reports = await _reportServices.GetReportsByUserAsync(userId);
            return Ok(reports);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetReportsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reports = await _reportServices.GetReportsByDateRangeAsync(startDate, endDate);
            return Ok(reports);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] UpdateReportDTO updateDto)
        {
            try
            {
                var report = await _reportServices.UpdateReportAsync(updateDto);
                if (report == null)
                {
                    return NotFound("التقرير غير موجود");
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث التقرير: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            var result = await _reportServices.DeleteReportAsync(id);
            if (!result)
            {
                return NotFound("التقرير غير موجود");
            }
            return Ok("تم حذف التقرير بنجاح");
        }
    }
}
