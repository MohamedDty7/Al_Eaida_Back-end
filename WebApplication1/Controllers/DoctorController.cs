using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.DoctorDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDTO createDoctorDTO)
        {
            try
            {
                var doctor = await _doctorServices.CreateDoctorAsync(createDoctorDTO);
                return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء الطبيب: {ex.Message}");
            }
        }

        [HttpGet("getdoctorbyid/{id}")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var doctor = await _doctorServices.GetDoctorDetailsByIdAsync(id);
            if (doctor == null)
            {
                return NotFound("الطبيب غير موجود");
            }
            return Ok(new { 
                message = "تم استرجاع بيانات الطبيب بنجاح",
                doctor = doctor 
            });
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors(
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 10)
        {
            var doctors = await _doctorServices.GetAllDoctorsAsync(pageNumber, pageSize);
            return Ok(doctors);
        }

        [HttpGet("GetDoctorsBySpecialization/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            var doctors = await _doctorServices.GetDoctorsBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpPut("UpDateDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDTO updateDoctorDTO)
        {
            try
            {
                var doctor = await _doctorServices.UpdateDoctorAsync(updateDoctorDTO);
                if (doctor == null)
                {
                    return NotFound("الطبيب غير موجود");
                }
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث الطبيب: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var result = await _doctorServices.DeleteDoctorAsync(id);
            if (!result)
            {
                return NotFound("الطبيب غير موجود");
            }
            return Ok("تم حذف الطبيب بنجاح");
        }
    }
}



