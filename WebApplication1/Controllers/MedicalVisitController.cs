using EL_Eaida_Applcation.DTO.MedicalVisitDTO;
using EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalVisitController : Controller
    {
        private readonly IMedicalVisitServices _medicalVisitServices;

        public MedicalVisitController(IMedicalVisitServices medicalVisitServices)
        {
            _medicalVisitServices = medicalVisitServices;
        }
        [HttpPost("CreateMediclVisits")]
        public async Task<IActionResult> Create([FromBody] CreateMedicalVisitDto value)
        {
            await _medicalVisitServices.CreateMedicalVisitAsync(value);
            return Ok("تمت الإضافة بنجاح");
        }
        [HttpGet("GetAllMedicalVisits")]
        public async Task<IActionResult> GetAllMedicalVisits(int pageSize = 10, int pageNumber = 1)
        {
            var medicalVisits = await _medicalVisitServices.GetAllMedicalVisitsAsync(pageSize, pageNumber);
            return Ok(medicalVisits);
        }
        [HttpGet("GetMedicalVisitById/{id}")]
        public async Task<IActionResult> GetMedicalVisitById(Guid id)
        {
            var medicalVisit = await _medicalVisitServices.GetMedicalVisitByIdAsync(id);
            if (medicalVisit == null)
            {
                return NotFound("الزيارة الطبية غير موجودة");
            }
            return Ok(medicalVisit);
        }
        [HttpPut("UpdateMedicalVisit")]
        public async Task<IActionResult> UpdateMedicalVisit([FromBody] UpdateMedicalVisitDto updateMedicalVisitDto)
        {
            var updatedVisit = await _medicalVisitServices.UpdateMedicalVisitAsync(updateMedicalVisitDto);
            if (updatedVisit == null)
            {
                return NotFound("الزيارة الطبية غير موجودة");
            }
            return Ok(updatedVisit);
        }
        [HttpDelete("DeleteMedicalVisit/{id}")]
        public async Task<IActionResult> DeleteMedicalVisit(Guid id)
        {
            var result = await _medicalVisitServices.DeleteMedicalVisitAsync(id);
            if (!result)
            {
                return NotFound("الزيارة الطبية غير موجودة");
            }
            return Ok("تم حذف الزيارة الطبية بنجاح");
        }
        [HttpGet("GetMedicalVisitsByPatientId/{patientId}")]
        public async Task<IActionResult> GetMedicalVisitsByPatientId(string patientId)
        {
            if (!Guid.TryParse(patientId, out Guid patientGuid))
                return BadRequest("Invalid patient ID format");
                
            var medicalVisits = await _medicalVisitServices.GetMedicalVisitsByPatientIdAsync(patientGuid);
            if (medicalVisits == null || !medicalVisits.Any())
            {
                return NotFound("لا توجد زيارات طبية لهذا المريض");
            }
            return Ok(medicalVisits);
        }
    }
}

