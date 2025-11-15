using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.DoctorDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EL_Eaida_Applcation.Services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorServices> _logger;

        public DoctorServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DoctorServices> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO createDoctorDTO)
        {
            var doctor = _mapper.Map<Doctor>(createDoctorDTO);
            doctor.Id = Guid.NewGuid();
            doctor.CreatedAt = DateTime.UtcNow;
            doctor.UpdatedAt = DateTime.UtcNow;
            
            await _unitOfWork.Repository<Doctor>().AddAsync(doctor);
            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<DoctorDTO?> GetDoctorByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var doctorId))
                {
                    _logger.LogWarning("معرف الطبيب غير صحيح: {Id}", id);
                    return null;
                }
                    
                var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(doctorId);
                
                if (doctor == null)
                {
                    _logger.LogWarning("الطبيب غير موجود: {Id}", id);
                    return null;
                }
                
                var doctorDto = new DoctorDTO
                {
                    Id = doctor.Id.ToString(),
                    UserId = doctor.UserId.ToString(),
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    FullName = $"{doctor.FirstName} {doctor.LastName}",
                    Email = doctor.Email,
                    Phone = doctor.Phone,
                    Specialization = doctor.Specialization,
                    LicenseNumber = doctor.LicenseNumber,
                    MedicalSchool = doctor.MedicalSchool,
                    YearsOfExperience = doctor.YearsOfExperience,
                    Bio = doctor.Bio,
                    ProfileImage = doctor.ProfileImage,
                    StartTime = doctor.StartTime,
                    EndTime = doctor.EndTime,
                    MaxPatientsPerDay = doctor.MaxPatientsPerDay,
                    IsActive = doctor.IsActive,
                    CreatedAt = doctor.CreatedAt,
                    UpdatedAt = doctor.UpdatedAt
                };
                
                return doctorDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في GetDoctorByIdAsync للطبيب: {Id}", id);
                throw;
            }
        }

        public async Task<DoctorDetailsDTO?> GetDoctorDetailsByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var doctorId))
                {
                    _logger.LogWarning("معرف الطبيب غير صحيح في GetDoctorDetailsByIdAsync: {Id}", id);
                    return null;
                }
                    
                var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(doctorId);
                if (doctor == null)
                {
                    _logger.LogWarning("الطبيب غير موجود في GetDoctorDetailsByIdAsync: {Id}", id);
                    return null;
                }

                var doctorDetails = new DoctorDetailsDTO
                {
                    Id = doctor.Id.ToString(),
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                    Phone = doctor.Phone,
                    Specialization = doctor.Specialization,
                    LicenseNumber = doctor.LicenseNumber ?? string.Empty,
                    MedicalSchool = doctor.MedicalSchool ?? string.Empty,
                    YearsOfExperience = doctor.YearsOfExperience,
                    Bio = doctor.Bio,
                    ProfileImage = doctor.ProfileImage,
                    StartTime = doctor.StartTime,
                    EndTime = doctor.EndTime,
                    MaxPatientsPerDay = doctor.MaxPatientsPerDay,
                    IsActive = doctor.IsActive,
                    CreatedAt = doctor.CreatedAt,
                    UpdatedAt = doctor.UpdatedAt
                };
            
                var specializations = await _unitOfWork.Repository<DoctorSpecialization>()
                    .GetQueryable()
                    .Where(ds => ds.DoctorId == doctorId)
                    .Include(ds => ds.Specialization)
                    .ToListAsync();

                doctorDetails.Specializations = specializations.Select(s => new DoctorSpecializationDTO
                {
                    Id = s.Id.ToString(),
                    DoctorId = s.DoctorId.ToString(),
                    SpecializationId = s.SpecializationId.ToString(),
                    SpecializationName = s.Specialization?.Name ?? "",
                    SpecializationDescription = s.Specialization?.Description,
                    CreatedAt = s.CreatedAt
                }).ToList();

                var schedules = await _unitOfWork.Repository<DoctorSchedule>()
                    .GetQueryable()
                    .Where(ds => ds.DoctorId == doctorId)
                    .ToListAsync();

                doctorDetails.Schedules = schedules.Select(s => new DoctorScheduleDTO
                {
                    Id = s.Id.ToString(),
                    DoctorId = s.DoctorId.ToString(),
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    IsActive = s.IsActive,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.CreatedAt 
                }).ToList();

                // جلب عدد المواعيد
                var appointments = await _unitOfWork.Repository<Appointment>()
                    .GetQueryable()
                    .Where(a => a.DoctorId == doctorId)
                    .ToListAsync();

                doctorDetails.TotalAppointments = appointments.Count;
                doctorDetails.TodayAppointments = appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);

                return doctorDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في GetDoctorDetailsByIdAsync للطبيب: {Id}", id);
                throw;
            }
        }

        public async Task<PaginatedDoctorsResponse> GetAllDoctorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            // الحصول على العدد الإجمالي للأطباء
            var totalCount = await _unitOfWork.Repository<Doctor>().GetQueryable().CountAsync();
            
            // الحصول على الأطباء مع pagination
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllAsync(pageNumber, pageSize);
            var doctorDtos = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            
            // حساب عدد الصفحات
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            
            return new PaginatedDoctorsResponse
            {
                Doctors = doctorDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                HasPreviousPage = pageNumber > 1,
                HasNextPage = pageNumber < totalPages
            };
        }

        public async Task<DoctorDTO?> UpdateDoctorAsync(UpdateDoctorDTO updateDoctorDTO)
        {
            try
            {
                if (!Guid.TryParse(updateDoctorDTO.Id, out var doctorId))
                {
                    _logger.LogWarning("معرف الطبيب غير صحيح في UpdateDoctorAsync: {Id}", updateDoctorDTO.Id);
                    return null;
                }
                    
                var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(doctorId);
                if (doctor == null)
                {
                    _logger.LogWarning("الطبيب غير موجود في UpdateDoctorAsync: {Id}", updateDoctorDTO.Id);
                    return null;
                }

                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.FirstName))
                    doctor.FirstName = updateDoctorDTO.FirstName;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.LastName))
                    doctor.LastName = updateDoctorDTO.LastName;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.Email))
                    doctor.Email = updateDoctorDTO.Email;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.Phone))
                    doctor.Phone = updateDoctorDTO.Phone;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.Specialization))
                    doctor.Specialization = updateDoctorDTO.Specialization;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.LicenseNumber))
                    doctor.LicenseNumber = updateDoctorDTO.LicenseNumber;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.MedicalSchool))
                    doctor.MedicalSchool = updateDoctorDTO.MedicalSchool;
                if (updateDoctorDTO.YearsOfExperience.HasValue)
                    doctor.YearsOfExperience = updateDoctorDTO.YearsOfExperience;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.Bio))
                    doctor.Bio = updateDoctorDTO.Bio;
                if (!string.IsNullOrWhiteSpace(updateDoctorDTO.ProfileImage))
                    doctor.ProfileImage = updateDoctorDTO.ProfileImage;
                if (updateDoctorDTO.StartTime.HasValue)
                    doctor.StartTime = updateDoctorDTO.StartTime;
                if (updateDoctorDTO.EndTime.HasValue)
                    doctor.EndTime = updateDoctorDTO.EndTime;
                if (updateDoctorDTO.MaxPatientsPerDay.HasValue)
                    doctor.MaxPatientsPerDay = updateDoctorDTO.MaxPatientsPerDay;
                if (updateDoctorDTO.IsActive.HasValue)
                    doctor.IsActive = updateDoctorDTO.IsActive.Value;

                doctor.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Repository<Doctor>().Update(doctor);
                await _unitOfWork.CompleteAsync();
                
                // تحويل يدوي بدلاً من AutoMapper
                var doctorDto = new DoctorDTO
                {
                    Id = doctor.Id.ToString(),
                    UserId = doctor.UserId.ToString(),
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    FullName = $"{doctor.FirstName} {doctor.LastName}",
                    Email = doctor.Email,
                    Phone = doctor.Phone,
                    Specialization = doctor.Specialization,
                    LicenseNumber = doctor.LicenseNumber,
                    MedicalSchool = doctor.MedicalSchool,
                    YearsOfExperience = doctor.YearsOfExperience,
                    Bio = doctor.Bio,
                    ProfileImage = doctor.ProfileImage,
                    StartTime = doctor.StartTime,
                    EndTime = doctor.EndTime,
                    MaxPatientsPerDay = doctor.MaxPatientsPerDay,
                    IsActive = doctor.IsActive,
                    CreatedAt = doctor.CreatedAt,
                    UpdatedAt = doctor.UpdatedAt
                };
                
                return doctorDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في UpdateDoctorAsync للطبيب: {Id}", updateDoctorDTO.Id);
                throw;
            }
        }

        public async Task<bool> DeleteDoctorAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var doctorId))
                {
                    _logger.LogWarning("معرف الطبيب غير صحيح في DeleteDoctorAsync: {Id}", id);
                    return false;
                }
                    
                var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(doctorId);
                if (doctor == null)
                {
                    _logger.LogWarning("الطبيب غير موجود في DeleteDoctorAsync: {Id}", id);
                    return false;
                }

                await _unitOfWork.Repository<Doctor>().Delete(doctor);
                await _unitOfWork.CompleteAsync();
                
                _logger.LogInformation("تم حذف الطبيب بنجاح: {Id}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في DeleteDoctorAsync للطبيب: {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctorsBySpecializationAsync(string specialization)
        {
            var allDoctors = await _unitOfWork.Repository<Doctor>().GetAllAsync(1, int.MaxValue);
            var filteredDoctors = allDoctors.Where(d => d.Specialization.Contains(specialization, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<IEnumerable<DoctorDTO>>(filteredDoctors);
        }
    }
}
