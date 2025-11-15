using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;
using EL_Eaida_Applcation.Services;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AL_Eaida_Infrastructure__Layer;
using Al_Eaida_Domin.Modules;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;
using Microsoft.Identity.Client;
using Microsoft.OpenApi.Validations;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        protected readonly IAppointmentService _appointmentServices;
        protected readonly IPatientService _patientServices;
        protected readonly IDoctorServices _doctorServices;
        protected readonly AppDBcontext _context;
        private readonly IHubContext<NotificationHub>? _hubContext;
        
        public AppointmentController(
            IAppointmentService appointmentServices,
            IPatientService patientServices,
            IDoctorServices doctorServices,
            AppDBcontext context,
            IHubContext<NotificationHub> hubContext)
        {
            _appointmentServices = appointmentServices;
            _patientServices = patientServices;
            _doctorServices = doctorServices;
            _context = context;
            _hubContext = hubContext;
        }

        // تم نقل منطق الإشعارات إلى NotificationService و AppointmentServices
        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto value)
        {
            try
            {
                await _appointmentServices.Createappointment(value);
                return Ok("تمت الإضافة بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء الإضافة: {ex.Message}");
            }
        }

        [HttpPost("CreateAppointmentWithDetails")]
        public async Task<IActionResult> CreateAppointmentWithDetails([FromBody] CreateAppointmentWithDetailsDto dto)
        {
            try
            {
                var result = await _appointmentServices.CreateAppointmentWithDetailsAsync(dto);

                return Ok(new { 
                    message = "تم إنشاء الموعد بنجاح مع تفاصيل المريض والطبيب",
                    appointment = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء إنشاء الموعد: {ex.Message}");
            }
        }
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentServices.GetAllAppointmentsWithDetailsAsync();
                return Ok(new { 
                    message = "تم استرجاع المواعيد مع تفاصيل المرضى والأطباء بنجاح",
                    appointments = appointments 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المواعيد: {ex.Message}");
            }
        }
        [HttpGet("GetAppointmentById/{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            try
            {
                var appointment = await _appointmentServices.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الموعد: {ex.Message}");
            }
        }
        [HttpPut("UpdateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] UpdateAppointmentDto value)
        {
            try
            {
                var result = await _appointmentServices.UpdateAsync(id, value);
                if (result == null)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تحديث الموعد: {ex.Message}");
            }
        }
        [HttpDelete("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            try
            {
                var result = await _appointmentServices.DeleteAsync(id);
                if (!result)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok("تم حذف الموعد بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء حذف الموعد: {ex.Message}");
            }

        }

        // Enhanced appointment management endpoints
        [HttpGet("GetAppointmentsByPatient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(Guid patientId)
        {
            try
            {
                var appointments = await _appointmentServices.GetByPatientIdAsync(patientId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع مواعيد المريض: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentsByDoctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(Guid doctorId)
        {
            try
            {
                var appointments = await _appointmentServices.GetByDoctorIdAsync(doctorId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع مواعيد الطبيب: {ex.Message}");
            }
        }

        // إرجاع مواعيد الطبيب مع تفاصيل المريض
        [HttpGet("GetDoctorAppointmentsWithDetails/{Userid}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetDoctorAppointmentsWithDetails(string Userid, int pageNumber, int pageSize)
        {      
            try
            {
                var appointments = await _appointmentServices.GetAppointmentsByDoctorOnlyAsync(Userid, pageNumber, pageSize);
                return Ok(new {
                    message = "تم استرجاع مواعيد الطبيب مع تفاصيل المرضى",
                    appointments
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع مواعيد الطبيب: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentsByDateRange")]
        public async Task<IActionResult> GetAppointmentsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var appointments = await _appointmentServices.GetByDateRangeAsync(startDate, endDate);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المواعيد: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentsByStatus/{status}")]
        public async Task<IActionResult> GetAppointmentsByStatus(string status)
        {
            try
            {
                var appointments = await _appointmentServices.GetByStatusAsync(status);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المواعيد: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentsWithDetails")]
        public async Task<IActionResult> GetAppointmentsWithDetails( string pagesize , string pagenumber )
        {
            try
            {
                var appointments = await _appointmentServices.GetAllAsync();
                return Ok(new { 
                    message = "تم استرجاع المواعيد مع تفاصيل المريض والطبيب بنجاح",
                    appointments = appointments 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المواعيد: {ex.Message}");
            }
        }

        // Endpoints for getting patients and doctors for appointment creation
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientServices.GetAllPatientsAsync(1, 1000);
                return Ok(new { 
                    message = "تم استرجاع قائمة المرضى بنجاح",
                    patients = patients 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المرضى: {ex.Message}");
            }
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorServices.GetAllDoctorsAsync(1, 1000);
                return Ok(new { 
                    message = "تم استرجاع قائمة الأطباء بنجاح",
                    doctors = doctors.Doctors 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الأطباء: {ex.Message}");
            }
        }

        [HttpGet("GetActiveDoctors")]
        public async Task<IActionResult> GetActiveDoctors()
        {
            try
            {
                var doctors = await _doctorServices.GetAllDoctorsAsync(1, 1000);
                var activeDoctors = doctors.Doctors.Where(d => d.IsActive).ToList();
                return Ok(new { 
                    message = "تم استرجاع قائمة الأطباء النشطين بنجاح",
                    doctors = activeDoctors 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الأطباء النشطين: {ex.Message}");
            }
        }

        [HttpGet("GetDoctorsBySpecialization/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecialization(string specialization)
        {
            try
            {
                var doctors = await _doctorServices.GetDoctorsBySpecializationAsync(specialization);
                var activeDoctors = doctors.Where(d => d.IsActive).ToList();
                return Ok(new { 
                    message = $"تم استرجاع قائمة أطباء التخصص {specialization} بنجاح",
                    doctors = activeDoctors 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع أطباء التخصص: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentFormData")]
        public async Task<IActionResult> GetAppointmentFormData()
        {
            try
            {
                var patients = await _patientServices.GetAllPatientsAsync(1, 1000);
                var doctors = await _doctorServices.GetAllDoctorsAsync(1, 1000);
                var activeDoctors = doctors.Doctors.Where(d => d.IsActive).ToList();
                
                return Ok(new { 
                    message = "تم استرجاع بيانات نموذج المواعيد بنجاح",
                    patients = patients,
                    doctors = activeDoctors,
                    specializations = activeDoctors.Select(d => d.Specialization).Distinct().ToList()
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع بيانات نموذج المواعيد: {ex.Message}");
            }
        }

        // Direct database access endpoints - بدون استخدام services
        [HttpGet("GetAllPatientsDirect")]
        public async Task<IActionResult> GetAllPatientsDirect()
        {
            try
            {
                var patients = await _context.Patients
                    .Select(p => new
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        FullName = p.FullName,
                        Email = p.Email,
                        Phone = p.Phone,
                        Gender = p.Gender,
                        DateOfBirth = p.DateOfBirth,
                        IsActive = p.IsActive,
                        CreatedAt = p.CreatedAt
                    })
                    .ToListAsync();

                return Ok(new { 
                    message = "تم استرجاع جميع المرضى بنجاح",
                    patients = patients,
                    totalCount = patients.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المرضى: {ex.Message}");
            }
        }

        [HttpGet("GetAllDoctorsDirect")]
        public async Task<IActionResult> GetAllDoctorsDirect()
        {
            try
            {
                var doctors = await _context.Doctors
                    .Select(d => new
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        FullName = d.FirstName + " " + d.LastName,
                        Email = d.Email,
                        Phone = d.Phone,
                        Specialization = d.Specialization,
                        LicenseNumber = d.LicenseNumber,
                        MedicalSchool = d.MedicalSchool,
                        YearsOfExperience = d.YearsOfExperience,
                        Bio = d.Bio,
                        StartTime = d.StartTime,
                        EndTime = d.EndTime,
                        MaxPatientsPerDay = d.MaxPatientsPerDay,
                        IsActive = d.IsActive,
                        CreatedAt = d.CreatedAt
                    })
                    .ToListAsync();

                return Ok(new { 
                    message = "تم استرجاع جميع الأطباء بنجاح",
                    doctors = doctors,
                    totalCount = doctors.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الأطباء: {ex.Message}");
            }
        }

        [HttpGet("GetActiveDoctorsDirect")]
        public async Task<IActionResult> GetActiveDoctorsDirect()
        {
            try
            {
                var doctors = await _context.Doctors
                    .Where(d => d.IsActive)
                    .Select(d => new
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        FullName = d.FirstName + " " + d.LastName,
                        Email = d.Email,
                        Phone = d.Phone,
                        Specialization = d.Specialization,
                        LicenseNumber = d.LicenseNumber,
                        MedicalSchool = d.MedicalSchool,
                        YearsOfExperience = d.YearsOfExperience,
                        Bio = d.Bio,
                        StartTime = d.StartTime,
                        EndTime = d.EndTime,
                        MaxPatientsPerDay = d.MaxPatientsPerDay,
                        IsActive = d.IsActive,
                        CreatedAt = d.CreatedAt
                    })
                    .ToListAsync();

                return Ok(new { 
                    message = "تم استرجاع الأطباء النشطين بنجاح",
                    doctors = doctors,
                    totalCount = doctors.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الأطباء النشطين: {ex.Message}");
            }
        }

        [HttpGet("GetDoctorsBySpecializationDirect/{specialization}")]
        public async Task<IActionResult> GetDoctorsBySpecializationDirect(string specialization)
        {
            try
            {
                var doctors = await _context.Doctors
                    .Where(d => d.IsActive && d.Specialization == specialization)
                    .Select(d => new
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        FullName = d.FirstName + " " + d.LastName,
                        Email = d.Email,
                        Phone = d.Phone,
                        Specialization = d.Specialization,
                        LicenseNumber = d.LicenseNumber,
                        MedicalSchool = d.MedicalSchool,
                        YearsOfExperience = d.YearsOfExperience,
                        Bio = d.Bio,
                        StartTime = d.StartTime,
                        EndTime = d.EndTime,
                        MaxPatientsPerDay = d.MaxPatientsPerDay,
                        IsActive = d.IsActive,
                        CreatedAt = d.CreatedAt
                    })
                    .ToListAsync();

                return Ok(new { 
                    message = $"تم استرجاع أطباء التخصص {specialization} بنجاح",
                    doctors = doctors,
                    totalCount = doctors.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع أطباء التخصص: {ex.Message}");
            }
        }

        [HttpGet("GetAllSpecializationsDirect")]
        public async Task<IActionResult> GetAllSpecializationsDirect()
        {
            try
            {
                var specializations = await _context.Doctors
                    .Where(d => d.IsActive)
                    .Select(d => d.Specialization)
                    .Distinct()
                    .OrderBy(s => s)
                    .ToListAsync();

                return Ok(new { 
                    message = "تم استرجاع جميع التخصصات بنجاح",
                    specializations = specializations,
                    totalCount = specializations.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع التخصصات: {ex.Message}");
            }
        }

        [HttpGet("GetAppointmentFormDataDirect")]
        public async Task<IActionResult> GetAppointmentFormDataDirect()
        {
            try
            {
                var patients = await _context.Patients
                    .Select(p => new
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        FullName = p.FullName,
                        Email = p.Email,
                        Phone = p.Phone,
                        Gender = p.Gender,
                        DateOfBirth = p.DateOfBirth,
                        IsActive = p.IsActive
                    })
                    .ToListAsync();

                var doctors = await _context.Doctors
                    .Where(d => d.IsActive)
                    .Select(d => new
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        FullName = d.FirstName + " " + d.LastName,
                        Email = d.Email,
                        Phone = d.Phone,
                        Specialization = d.Specialization,
                        LicenseNumber = d.LicenseNumber,
                        YearsOfExperience = d.YearsOfExperience,
                        IsActive = d.IsActive
                    })
                    .ToListAsync();

                var specializations = doctors
                    .Select(d => d.Specialization)
                    .Distinct()
                    .OrderBy(s => s)
                    .ToList();
                
                return Ok(new { 
                    message = "تم استرجاع بيانات نموذج المواعيد بنجاح",
                    patients = patients,
                    doctors = doctors,
                    specializations = specializations,
                    patientsCount = patients.Count,
                    doctorsCount = doctors.Count,
                    specializationsCount = specializations.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع بيانات نموذج المواعيد: {ex.Message}");
            }
        }

        // إنشاء موعد بدون UserID (للاستخدام في التطوير)
        [HttpPost("CreateAppointmentWithoutUser")]
        public async Task<IActionResult> CreateAppointmentWithoutUser([FromBody] CreateAppointmentDto value)
        {
            try
            {
                // استخدام UserID افتراضي من البيانات الموجودة
                var defaultUser = await _context.Users.FirstOrDefaultAsync();
                if (defaultUser == null)
                {
                    return BadRequest("لا يوجد مستخدمين في النظام");
                }

                // التحقق من وجود المريض
                var patient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.Id == value.PatientId);
                if (patient == null)
                {
                    return BadRequest($"المريض غير موجود: {value.PatientId}");
                }

                // التحقق من وجود الطبيب
                var doctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.Id == value.DoctorId);
                if (doctor == null)
                {
                    return BadRequest($"الطبيب غير موجود: {value.DoctorId}");
                }

                // استخدام UserID الافتراضي
                value.UserID = defaultUser.Id;

                var created = await _appointmentServices.Createappointment(value);
                
                return Ok(new { 
                    message = "تم إنشاء الموعد بنجاح",
                    appointment = new {
                        patientName = patient.FullName,
                        doctorName = doctor.FirstName + " " + doctor.LastName,
                        appointmentDate = value.AppointmentDate,
                        time = value.Time,
                        status = value.Status,
                        userId = defaultUser.Id
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء إنشاء الموعد: {ex.Message}");
            }
        }

        // ========== فلاتر المواعيد المتقدمة ==========

        // فلتر حسب حالة الموعد
        [HttpGet("FilterByStatus")]
        public async Task<IActionResult> FilterByStatus([FromQuery] string status)
        {
            try
            {
                var appointments = await _appointmentServices.FilterByStatusAsync(status);
                
                return Ok(new { 
                    message = $"تم استرجاع المواعيد بحالة {status} بنجاح",
                    appointments = appointments,
                    totalCount = appointments.Count(),
                    status = status
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء فلترة المواعيد حسب الحالة: {ex.Message}");
            }
        }

        // ====== إدارة حالة الموعد مع الإشعارات ======
        [HttpPost("StartAppointment")] 
        public async Task<IActionResult> StartAppointment([FromQuery] Guid appointmentId, [FromQuery] string doctorId)
        {
            var ok = await _appointmentServices.StartAppointmentAsync(appointmentId, doctorId);
            if (!ok) return NotFound("الموعد غير موجود");
            return Ok("تم تحديث الحالة إلى جاري الفحص");
        }

        [HttpPost("EndAppointment")] 
        public async Task<IActionResult> EndAppointment([FromQuery] Guid appointmentId, [FromQuery] string doctorId)
        {
            var ok = await _appointmentServices.EndAppointmentAsync(appointmentId, doctorId);
            if (!ok) return NotFound("الموعد غير موجود");
            return Ok("تم تحديث الحالة إلى مكتمل");
        }

        [HttpPost("CancelAppointment")] 
        public async Task<IActionResult> CancelAppointment([FromQuery] Guid appointmentId, [FromQuery] string cancelledBy)
        {
            var ok = await _appointmentServices.CancelAppointmentAsync(appointmentId, cancelledBy);
            if (!ok) return NotFound("الموعد غير موجود");
            return Ok("تم إلغاء الموعد");
        }

        // فلتر حسب التاريخ
        [HttpGet("FilterByDateRange")]
        public async Task<IActionResult> FilterByDateRange([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var appointments = await _appointmentServices.FilterByDateRangeAsync(startDate, endDate);
                
                return Ok(new { 
                    message = "تم استرجاع المواعيد حسب التاريخ بنجاح",
                    appointments = appointments,
                    totalCount = appointments.Count(),
                    startDate = startDate,
                    endDate = endDate
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء فلترة المواعيد حسب التاريخ: {ex.Message}");
            }
        }

        // فلتر حسب الدكتور
        [HttpGet("FilterByDoctor")]
        public async Task<IActionResult> FilterByDoctor([FromQuery] Guid? doctorId, [FromQuery] string? doctorName)
        {
            try
            {
                var appointments = await _appointmentServices.FilterByDoctorAsync(doctorId, doctorName);
                
                return Ok(new { 
                    message = "تم استرجاع مواعيد الطبيب بنجاح",
                    appointments = appointments,
                    totalCount = appointments.Count(),
                    doctorId = doctorId,
                    doctorName = doctorName
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء فلترة المواعيد حسب الطبيب: {ex.Message}");
            }
        }

        // فلتر مجمع حسب المريض والدكتور
        [HttpGet("FilterByPatientAndDoctor")]
        public async Task<IActionResult> FilterByPatientAndDoctor([FromQuery] Guid? patientId, [FromQuery] Guid? doctorId, [FromQuery] string? patientName, [FromQuery] string? doctorName)
        {
            try
            {
                var appointments = await _appointmentServices.FilterByPatientAndDoctorAsync(patientId, doctorId, patientName, doctorName);
                
                return Ok(new { 
                    message = "تم استرجاع المواعيد حسب المريض والطبيب بنجاح",
                    appointments = appointments,
                    totalCount = appointments.Count(),
                    patientId = patientId,
                    patientName = patientName,
                    doctorId = doctorId,
                    doctorName = doctorName
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء فلترة المواعيد حسب المريض والطبيب: {ex.Message}");
            }
        }

    }

}
