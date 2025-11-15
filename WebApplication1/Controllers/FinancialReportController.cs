using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.FinancialReportDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReportServices _financialReportServices;

        public FinancialReportController(IFinancialReportServices financialReportServices)
        {
            _financialReportServices = financialReportServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateFinancialReportDTO createDto)
        {
            try
            {
                var report = await _financialReportServices.CreateReportAsync(createDto);
                return CreatedAtAction(nameof(GetReportById), new { id = report.Id }, report);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء التقرير المالي: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(Guid id)
        {
            var report = await _financialReportServices.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound("التقرير المالي غير موجود");
            }
            return Ok(report);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _financialReportServices.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetReportsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reports = await _financialReportServices.GetReportsByDateRangeAsync(startDate, endDate);
            return Ok(reports);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestReport()
        {
            var report = await _financialReportServices.GetLatestReportAsync();
            if (report == null)
            {
                return NotFound("لا توجد تقارير مالية");
            }
            return Ok(report);
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetReportsByYear(int year)
        {
            var reports = await _financialReportServices.GetReportsByYearAsync(year);
            return Ok(reports);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] UpdateFinancialReportDTO updateDto)
        {
            try
            {
                var report = await _financialReportServices.UpdateReportAsync(updateDto);
                if (report == null)
                {
                    return NotFound("التقرير المالي غير موجود");
                }
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث التقرير المالي: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            var result = await _financialReportServices.DeleteReportAsync(id);
            if (!result)
            {
                return NotFound("التقرير المالي غير موجود");
            }
            return Ok("تم حذف التقرير المالي بنجاح");
        }
    }
}
