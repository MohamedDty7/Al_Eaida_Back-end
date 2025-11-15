using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.AuditLogDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogServices _auditLogServices;

        public AuditLogController(IAuditLogServices auditLogServices)
        {
            _auditLogServices = auditLogServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] CreateAuditLogDTO createDto)
        {
            try
            {
                var log = await _auditLogServices.CreateLogAsync(createDto);
                return CreatedAtAction(nameof(GetLogById), new { id = log.Id }, log);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء سجل التدقيق: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(Guid id)
        {
            var log = await _auditLogServices.GetLogByIdAsync(id);
            if (log == null)
            {
                return NotFound("سجل التدقيق غير موجود");
            }
            return Ok(log);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _auditLogServices.GetAllLogsAsync();
            return Ok(logs);
        }

        [HttpGet("table/{tableName}")]
        public async Task<IActionResult> GetLogsByTable(string tableName)
        {
            var logs = await _auditLogServices.GetLogsByTableAsync(tableName);
            return Ok(logs);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLogsByUser(string userId)
        {
            var logs = await _auditLogServices.GetLogsByUserAsync(userId);
            return Ok(logs);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetLogsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var logs = await _auditLogServices.GetLogsByDateRangeAsync(startDate, endDate);
            return Ok(logs);
        }

        [HttpGet("action/{action}")]
        public async Task<IActionResult> GetLogsByAction(string action)
        {
            var logs = await _auditLogServices.GetLogsByActionAsync(action);
            return Ok(logs);
        }
    }
}
