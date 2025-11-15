using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using System.Linq;

namespace EL_Eaida_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // POST: api/Patient
        [HttpPost("Add-Patients")]
        public async Task<IActionResult> AddPatient([FromBody] CreatePatientDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { 
                        message = "Validation failed", 
                        errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) 
                    });
                }

                await _patientService.AddPatientAsync(dto);
                return Ok(new { message = "Patient added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error adding patient", error = ex.Message });
            }
        }

        // PUT: api/Patient
        [HttpPut("UPDatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _patientService.UpdatePatientAsync(dto);
            if (!updated)
                return NotFound(new { message = "Patient not found" });

            return Ok(new { message = "Patient updated successfully" });
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
          var deleted = await _patientService.DeletePatientAsync(id);
            if (!deleted)
                return NotFound(new { message = "Patient not found" });

            return Ok(new { message = "Patient deleted successfully" });
        }

        // GET: api/Patient/{id}
        [HttpGet("  GetPatientbyId /{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound(new { message = "Patient not found" });

            return Ok(patient);
        }

        // GET: api/Patient?name=...&gender=...&pageNumber=1&pageSize=10
        [HttpGet("GetallPatients")]
        public async Task<IActionResult> GetAllPatients(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? name,
            [FromQuery] string? gender)
        {
            if (pageNumber < 1)
                return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

            if (pageSize < 1 || pageSize > 100)
                return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

            var patients = await _patientService.GetPatientFilter(pageNumber, pageSize, name, gender);
            return Ok(patients);
        }

        #region الدوال الجديدة مع معلومات الصفحات

      
        [HttpGet("GetAllPatientsPaged")]
        public async Task<IActionResult> GetAllPatientsPaged(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            try
            {
                if (pageNumber < 1)
                    return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

                if (pageSize < 1 || pageSize > 100)
                    return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

                var result = await _patientService.GetAllPatientsPagedAsync(pageNumber, pageSize);
                return Ok(new
                {
                    message = "تم استرجاع المرضى بنجاح",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "خطأ في استرجاع المرضى", error = ex.Message });
            }
        }

        /// <summary>
        /// البحث عن المرضى حسب الاسم مع معلومات الصفحات
        /// </summary>
        /// <param name="name">اسم المريض</param>
        /// <param name="pageNumber">رقم الصفحة</param>
        /// <param name="pageSize">حجم الصفحة</param>
        /// <returns>قائمة المرضى المطابقة مع معلومات الصفحات</returns>
        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchPatientsByName(
            [FromQuery] string name,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest(new { message = "اسم المريض مطلوب" });

                if (pageNumber < 1)
                    return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

                if (pageSize < 1 || pageSize > 100)
                    return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

                var result = await _patientService.GetPatientsByNamePagedAsync(name, pageNumber, pageSize);
                return Ok(new
                {
                    message = $"تم العثور على {result.TotalPatients} مريض بالاسم '{name}'",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "خطأ في البحث عن المرضى بالاسم", error = ex.Message });
            }
        }

        /// <summary>
        /// البحث عن المرضى حسب النوع مع معلومات الصفحات
        /// </summary>
        /// <param name="gender">نوع المريض (Male, Female, Other)</param>
        /// <param name="pageNumber">رقم الصفحة</param>
        /// <param name="pageSize">حجم الصفحة</param>
        /// <returns>قائمة المرضى المطابقة مع معلومات الصفحات</returns>
        [HttpGet("SearchByGender")]
        public async Task<IActionResult> SearchPatientsByGender(
            [FromQuery] string gender,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(gender))
                    return BadRequest(new { message = "نوع المريض مطلوب" });

                if (pageNumber < 1)
                    return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

                if (pageSize < 1 || pageSize > 100)
                    return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

                var result = await _patientService.GetPatientsByGenderPagedAsync(gender, pageNumber, pageSize);
                return Ok(new
                {
                    message = $"تم العثور على {result.TotalPatients} مريض من النوع '{gender}'",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "خطأ في البحث عن المرضى بالنوع", error = ex.Message });
            }
        }

        

        [HttpGet("SearchByStatus")]
        public async Task<IActionResult> SearchPatientsByStatus(
            [FromQuery] bool isActive,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            try
            {
                if (pageNumber < 1)
                    return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

                if (pageSize < 1 || pageSize > 100)
                    return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

                var result = await _patientService.GetPatientsByStatusPagedAsync(isActive, pageNumber, pageSize);
                var statusText = isActive ? "نشط" : "غير نشط";
                
                return Ok(new
                {
                    message = $"تم العثور على {result.TotalPatients} مريض بحالة '{statusText}'",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "خطأ في البحث عن المرضى بالحالة", error = ex.Message });
            }
        }

        
        [HttpGet("AdvancedSearchPatients")]
        public async Task<IActionResult> AdvancedSearchPatients(
            [FromQuery] string? name,
            [FromQuery] string? gender,
            [FromQuery] bool? isActive,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            try
            {
                if (pageNumber < 1)
                    return BadRequest(new { message = "رقم الصفحة يجب أن يكون أكبر من 0" });

                if (pageSize < 1 || pageSize > 100)
                    return BadRequest(new { message = "حجم الصفحة يجب أن يكون بين 1 و 100" });

                var result = await _patientService.GetPatientsFilteredPagedAsync(name, gender, isActive, pageNumber, pageSize);
                
                var filters = new List<string>();
                if (!string.IsNullOrWhiteSpace(name)) filters.Add($"الاسم: {name}");
                if (!string.IsNullOrWhiteSpace(gender)) filters.Add($"النوع: {gender}");
                if (isActive.HasValue) filters.Add($"الحالة: {(isActive.Value ? "نشط" : "غير نشط")}");
                
                var filterText = filters.Any() ? $"بفلتر: {string.Join(", ", filters)}" : "بدون فلتر";
                
                return Ok(new
                {
                    message = $"تم العثور على {result.TotalPatients} مريض {filterText}",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "خطأ في البحث المتقدم عن المرضى", error = ex.Message });
            }
        }

        #endregion
    }
}
