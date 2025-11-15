using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.MedicalRecordDTO;
using EL_Eaida_Applcation.InterFaceServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordServices _medicalRecordServices;

        public MedicalRecordController(IMedicalRecordServices medicalRecordServices)
        {
            _medicalRecordServices = medicalRecordServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] CreateMedicalRecordDTO createMedicalRecordDTO)
        {
            try
            {
                var medicalRecord = await _medicalRecordServices.CreateMedicalRecordAsync(createMedicalRecordDTO);
                return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في إنشاء السجل الطبي: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(Guid id)
        {
            var medicalRecord = await _medicalRecordServices.GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound("السجل الطبي غير موجود");
            }
            return Ok(medicalRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalRecords()
        {
            var medicalRecords = await _medicalRecordServices.GetAllMedicalRecordsAsync();
            return Ok(medicalRecords);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetMedicalRecordsByPatientId(string patientId)
        {
            if (!Guid.TryParse(patientId, out Guid patientGuid))
                return BadRequest("Invalid patient ID format");
                
            var medicalRecords = await _medicalRecordServices.GetMedicalRecordsByPatientIdAsync(patientGuid);
            return Ok(medicalRecords);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetMedicalRecordsByDoctorId(Guid doctorId)
        {
            var medicalRecords = await _medicalRecordServices.GetMedicalRecordsByDoctorIdAsync(doctorId);
            return Ok(medicalRecords);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicalRecord([FromBody] UpdateMedicalRecordDTO updateMedicalRecordDTO)
        {
            try
            {
                var medicalRecord = await _medicalRecordServices.UpdateMedicalRecordAsync(updateMedicalRecordDTO);
                if (medicalRecord == null)
                {
                    return NotFound("السجل الطبي غير موجود");
                }
                return Ok(medicalRecord);
            }
            catch (Exception ex)
            {
                return BadRequest($"خطأ في تحديث السجل الطبي: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(Guid id)
        {
            var result = await _medicalRecordServices.DeleteMedicalRecordAsync(id);
            if (!result)
            {
                return NotFound("السجل الطبي غير موجود");
            }
            return Ok("تم حذف السجل الطبي بنجاح");
        }
    }
}
