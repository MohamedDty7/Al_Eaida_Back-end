using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.DoctorScheduleDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleServices _doctorScheduleServices;

        public DoctorScheduleController(IDoctorScheduleServices doctorScheduleServices)
        {
            _doctorScheduleServices = doctorScheduleServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateDoctorScheduleDTO createDto)
        {
            try
            {
                var schedule = await _doctorScheduleServices.CreateScheduleAsync(createDto);
                return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.Id }, schedule);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء الجدول: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(Guid id)
        {
            var schedule = await _doctorScheduleServices.GetScheduleByIdAsync(id);
            if (schedule == null)
            {
                return NotFound("الجدول غير موجود");
            }
            return Ok(schedule);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _doctorScheduleServices.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetSchedulesByDoctorId(Guid doctorId)
        {
            var schedules = await _doctorScheduleServices.GetSchedulesByDoctorIdAsync(doctorId);
            return Ok(schedules);
        }

        [HttpGet("day/{dayOfWeek}")]
        public async Task<IActionResult> GetSchedulesByDay(int dayOfWeek)
        {
            var schedules = await _doctorScheduleServices.GetSchedulesByDayAsync((DayOfWeek)dayOfWeek);
            return Ok(schedules);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchedule([FromBody] UpdateDoctorScheduleDTO updateDto)
        {
            try
            {
                var schedule = await _doctorScheduleServices.UpdateScheduleAsync(updateDto);
                if (schedule == null)
                {
                    return NotFound("الجدول غير موجود");
                }
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث الجدول: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(Guid id)
        {
            var result = await _doctorScheduleServices.DeleteScheduleAsync(id);
            if (!result)
            {
                return NotFound("الجدول غير موجود");
            }
            return Ok("تم حذف الجدول بنجاح");
        }
    }
}
