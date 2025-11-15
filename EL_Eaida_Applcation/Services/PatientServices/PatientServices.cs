using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using AddressDTO = EL_Eaida_Applcation.DTO.AddressDTO.AddressDTO;
using GovernorateDTO = EL_Eaida_Applcation.DTO.LocationDTO.GovernorateDTO;
using CityDTO = EL_Eaida_Applcation.DTO.LocationDTO.CityDTO;
using EmergencyContactDTO = EL_Eaida_Applcation.DTO.EmergencyContactDTO.EmergencyContactDTO;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EL_Eaida_Applcation.Services.PatientServices
{
    public class PatientServices : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientServices> _logger;

        public PatientServices(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PatientServices> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        private Gender ParseGender(string gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("نوع المريض مطلوب", nameof(gender));

            // تحويل النص إلى حالة موحدة للتحقق
            var normalizedGender = gender.Trim().ToLower();
            
            return normalizedGender switch
            {
                "male" or "ذكر" => Gender.Male,
                "female" or "أنثى" => Gender.Female,
                "other" or "آخر" => Gender.Other,
                _ => throw new ArgumentException($"قيمة الجنس غير صحيحة: {gender}. القيم المقبولة: Male, Female, Other, ذكر, أنثى, آخر")
            };
        }

        public async Task AddPatientAsync(CreatePatientDTO patient)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _logger.LogInformation("بدء إنشاء مريض جديد: {Email}", patient.Email);

                if (string.IsNullOrWhiteSpace(patient.FirstName))
                    throw new ArgumentException("الاسم الأول مطلوب", nameof(patient.FirstName));

                if (string.IsNullOrWhiteSpace(patient.Email))
                    throw new ArgumentException("البريد الإلكتروني مطلوب", nameof(patient.Email));

                var existingPatient = await _unitOfWork.Repository<Patient>()
                    .GetAsync(p => p.Email == patient.Email);
                if (existingPatient != null)
                    throw new InvalidOperationException("البريد الإلكتروني مستخدم بالفعل");

                Guid? addressId = null;
                Guid? emergencyContactId = null;

                if (!string.IsNullOrEmpty(patient.Street) &&
                    patient.GovernorateId.HasValue &&
                    patient.CityId.HasValue)
                {
                    var governorate = await _unitOfWork.Repository<Governorate>().GetByIdAsync(patient.GovernorateId.Value);
                    if (governorate == null)
                        throw new ArgumentException($"المحافظة غير موجودة: {patient.GovernorateId.Value}", nameof(patient.GovernorateId));

                    var city = await _unitOfWork.Repository<City>().GetByIdAsync(patient.CityId.Value);
                    if (city == null)
                        throw new ArgumentException($"المدينة غير موجودة: {patient.CityId.Value}", nameof(patient.CityId));

                    if (city.GovernorateId != patient.GovernorateId.Value)
                        throw new ArgumentException($"المدينة {city.NameAr} لا تنتمي للمحافظة {governorate.NameAr}", nameof(patient.CityId));

                    var address = new Address
                    {
                        Id = Guid.NewGuid(),
                        Street = patient.Street,
                        ZipCode = patient.ZipCode ?? "",
                        Country = patient.Country ?? "مصر",
                        GovernorateId = patient.GovernorateId.Value,
                        CityId = patient.CityId.Value,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.Repository<Address>().AddAsync(address);
                    addressId = address.Id;
                }

                if (!string.IsNullOrEmpty(patient.EmergencyContactName) &&
                    !string.IsNullOrEmpty(patient.EmergencyContactPhone))
                {
                    var emergencyContact = new EmergencyContact
                    {
                        Id = Guid.NewGuid(),
                        Name = patient.EmergencyContactName,
                        Relationship = patient.EmergencyContactRelationship ?? "",
                        Phone = patient.EmergencyContactPhone,
                        Email = patient.EmergencyContactEmail,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.Repository<EmergencyContact>().AddAsync(emergencyContact);
                    emergencyContactId = emergencyContact.Id;
                }

                var patientEntity = new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    FullName = patient.FullName,
                    Email = patient.Email,
                    Phone = patient.Phone,
                    DateOfBirth = patient.DateOfBirth.ToDateTime(TimeOnly.MinValue),
                    Gender = ParseGender(patient.Gender),
                    AddressId = addressId,
                    EmergencyContactId = emergencyContactId,
                    InsuranceInfoId = null,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Repository<Patient>().AddAsync(patientEntity);
                await _unitOfWork.CompleteAsync();
                await transaction.CommitAsync();

                _logger.LogInformation("تم إنشاء المريض بنجاح: {Id}", patientEntity.Id);
            }
            catch (DbUpdateException dbEx)
            {
                await transaction.RollbackAsync();
                _logger.LogError(dbEx, "خطأ في قاعدة البيانات أثناء إنشاء المريض: {Email}", patient.Email);

                if (dbEx.InnerException != null)
                {
                    _logger.LogError(dbEx.InnerException, "تفاصيل الخطأ الداخلي");
                }

                throw new InvalidOperationException($"فشل في حفظ بيانات المريض: {dbEx.InnerException?.Message}", dbEx);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "خطأ في إنشاء المريض: {Email}", patient.Email);
                throw;
            }
        }
        public async Task<bool> DeletePatientAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("??? ??? ??????: {Id}", id);
                
                var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);
                if (patient == null)
                {
                    _logger.LogWarning("?????? ??? ????? ?????: {Id}", id);
                    return false;
                }

                await _unitOfWork.Repository<Patient>().Delete(patient);
                await _unitOfWork.CompleteAsync();
                
                _logger.LogInformation("?? ??? ?????? ?????: {Id}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "??? ?? ??? ??????: {Id}", id);
                throw;
            }
        }


        public async Task<PatientDTO?> GetPatientByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("????? ?? ??????: {Id}", id);
                
                var entity = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);

                if (entity == null)
                {
                    _logger.LogWarning("?????? ??? ?????: {Id}", id);
                    return null;
                }

                var dto = new PatientDTO
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    FullName = entity.FullName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    DateOfBirth = DateOnly.FromDateTime(entity.DateOfBirth),
                    Gender = entity.Gender.ToString(),
                    AddressId = entity.AddressId,
                    EmergencyContactId = entity.EmergencyContactId,
                    InsuranceInfoId = entity.InsuranceInfoId,
                    IsActive = entity.IsActive,
                    CreatedAt = DateOnly.FromDateTime(entity.CreatedAt),
                    UpdatedAt = DateOnly.FromDateTime(entity.UpdatedAt)
                };

                if (entity.AddressId.HasValue)
                {
                    var address = await _unitOfWork.Repository<Address>().GetByIdAsync(entity.AddressId.Value);
                    if (address != null)
                    {
                        dto.Address = new AddressDTO
                        {
                            Id = address.Id,
                            Street = address.Street,
                            ZipCode = address.ZipCode,
                            Country = address.Country,
                            GovernorateId = address.GovernorateId,
                            CityId = address.CityId,
                            CreatedAt = DateOnly.FromDateTime(address.CreatedAt)
                        };

                        if (address.GovernorateId.HasValue)
                        {
                            var governorate = await _unitOfWork.Repository<Governorate>().GetByIdAsync(address.GovernorateId.Value);
                            if (governorate != null)
                            {
                                dto.Address.Governorate = new GovernorateDTO
                                {
                                    Id = governorate.Id,
                                    NameAr = governorate.NameAr,
                                    NameEn = governorate.NameEn
                                };
                            }
                        }

                        if (address.CityId.HasValue)
                        {
                            var city = await _unitOfWork.Repository<City>().GetByIdAsync(address.CityId.Value);
                            if (city != null)
                            {
                                dto.Address.City = new CityDTO
                                {
                                    Id = city.Id,
                                    GovernorateId = city.GovernorateId,
                                    NameAr = city.NameAr,
                                    NameEn = city.NameEn
                                };
                            }
                        }
                    }
                }

                
                if (entity.EmergencyContactId.HasValue)
                {
                    var emergencyContact = await _unitOfWork.Repository<EmergencyContact>().GetByIdAsync(entity.EmergencyContactId.Value);
                    if (emergencyContact != null)
                    {
                        dto.EmergencyContact = new EmergencyContactDTO
                        {
                            Id = emergencyContact.Id,
                            Name = emergencyContact.Name,
                            Relationship = emergencyContact.Relationship,
                            Phone = emergencyContact.Phone,
                            Email = emergencyContact.Email,
                            CreatedAt = DateOnly.FromDateTime(emergencyContact.CreatedAt)
                        };
                    }
                }
                
                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "??? ?? ????? ?? ??????: {Id}", id);
                throw;
            }
        }
        public async Task<bool> UpdatePatientAsync(UpdatePatientDTO patients)
        {
            try
            {
                _logger.LogInformation("??? ????? ??????: {Id}", patients.Id);
                
                var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patients.Id);

                if (patient == null)
                {
                    _logger.LogWarning("?????? ??? ????? ???????: {Id}", patients.Id);
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(patients.FirstName))
                    patient.FirstName = patients.FirstName;

                if (!string.IsNullOrWhiteSpace(patients.LastName))
                    patient.LastName = patients.LastName;

                if (!string.IsNullOrWhiteSpace(patients.FullName))
                    patient.FullName = patients.FullName;

                if (!string.IsNullOrWhiteSpace(patients.Email))
                    patient.Email = patients.Email;

                if (!string.IsNullOrWhiteSpace(patients.Phone))
                    patient.Phone = patients.Phone;

                if (patients.DateOfBirth.HasValue)
                    patient.DateOfBirth = patients.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue);

                if (!string.IsNullOrWhiteSpace(patients.Gender))
                    patient.Gender = ParseGender(patients.Gender);

                if (patients.AddressId.HasValue)
                    patient.AddressId = patients.AddressId.Value;

                if (patients.EmergencyContactId.HasValue)
                    patient.EmergencyContactId = patients.EmergencyContactId.Value;

                if (patients.InsuranceInfoId.HasValue)
                    patient.InsuranceInfoId = patients.InsuranceInfoId.Value;

                if (patients.IsActive.HasValue)
                    patient.IsActive = patients.IsActive.Value;

                patient.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.CompleteAsync();
                
                _logger.LogInformation("?? ????? ?????? ?????: {Id}", patients.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "??? ?? ????? ??????: {Id}", patients.Id);
                throw;
            }
        }

        #region دوال عرض المرضى الجديدة مع معلومات الصفحات

        /// <summary>
        /// عرض جميع المرضى مع معلومات الصفحات
        /// </summary>
        public async Task<PagedPatientResultDTO> GetAllPatientsPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("عرض جميع المرضى - الصفحة: {PageNumber}, الحجم: {PageSize}", pageNumber, pageSize);

                var query = _unitOfWork.Repository<Patient>().GetQueryable();
                var totalPatients = await query.CountAsync();

                var patients = await query
                    .OrderBy(p => p.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var patientDTOs = patients.Select(p => _mapper.Map<PatientDTO>(p));

                return new PagedPatientResultDTO
                {
                    Patients = patientDTOs,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPatients = totalPatients,
                    TotalPages = (int)Math.Ceiling((double)totalPatients / pageSize)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في عرض جميع المرضى");
                throw;
            }
        }

       
        public async Task<PagedPatientResultDTO> GetPatientsByNamePagedAsync(string name, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("البحث عن المرضى بالاسم: {Name} - الصفحة: {PageNumber}", name, pageNumber);

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("اسم المريض مطلوب", nameof(name));

                var query = _unitOfWork.Repository<Patient>().GetQueryable()
                    .Where(p => p.FullName.Contains(name) || 
                               p.FirstName.Contains(name) || 
                               p.LastName.Contains(name));

                var totalPatients = await query.CountAsync();

                var patients = await query
                    .OrderBy(p => p.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var patientDTOs = patients.Select(p => _mapper.Map<PatientDTO>(p));

                return new PagedPatientResultDTO
                {
                    Patients = patientDTOs,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPatients = totalPatients,
                    TotalPages = (int)Math.Ceiling((double)totalPatients / pageSize)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في البحث عن المرضى بالاسم: {Name}", name);
                throw;
            }
        }

        /// <summary>
        /// البحث عن المرضى حسب النوع مع معلومات الصفحات
        /// </summary>
        public async Task<PagedPatientResultDTO> GetPatientsByGenderPagedAsync(string gender, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("البحث عن المرضى بالنوع: {Gender} - الصفحة: {PageNumber}", gender, pageNumber);

                if (string.IsNullOrWhiteSpace(gender))
                    throw new ArgumentException("نوع المريض مطلوب", nameof(gender));

                var query = _unitOfWork.Repository<Patient>().GetQueryable()
                    .Where(p => p.Gender == ParseGender(gender));

                var totalPatients = await query.CountAsync();

                var patients = await query
                    .OrderBy(p => p.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var patientDTOs = patients.Select(p => _mapper.Map<PatientDTO>(p));

                return new PagedPatientResultDTO
                {
                    Patients = patientDTOs,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPatients = totalPatients,
                    TotalPages = (int)Math.Ceiling((double)totalPatients / pageSize)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في البحث عن المرضى بالنوع: {Gender}", gender);
                throw;
            }
        }

        /// <summary>
        /// البحث عن المرضى حسب الحالة (نشط/غير نشط) مع معلومات الصفحات
        /// </summary>
        public async Task<PagedPatientResultDTO> GetPatientsByStatusPagedAsync(bool isActive, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("البحث عن المرضى حسب الحالة: {IsActive} - الصفحة: {PageNumber}", 
                    isActive ? "نشط" : "غير نشط", pageNumber);

                var query = _unitOfWork.Repository<Patient>().GetQueryable()
                    .Where(p => p.IsActive == isActive);

                var totalPatients = await query.CountAsync();

                var patients = await query
                    .OrderBy(p => p.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var patientDTOs = patients.Select(p => _mapper.Map<PatientDTO>(p));

                return new PagedPatientResultDTO
                {
                    Patients = patientDTOs,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPatients = totalPatients,
                    TotalPages = (int)Math.Ceiling((double)totalPatients / pageSize)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في البحث عن المرضى حسب الحالة: {IsActive}", isActive);
                throw;
            }
        }

        /// <summary>
        /// البحث عن المرضى بفلترة متقدمة مع معلومات الصفحات (يشمل الحالة)
        /// </summary>
        public async Task<PagedPatientResultDTO> GetPatientsFilteredPagedAsync(string? name, string? gender, bool? isActive, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("البحث المتقدم عن المرضى - الاسم: {Name}, النوع: {Gender}, الحالة: {IsActive}, الصفحة: {PageNumber}", 
                    name, gender, isActive?.ToString() ?? "جميع الحالات", pageNumber);

                var query = _unitOfWork.Repository<Patient>().GetQueryable();

                // فلترة حسب الاسم
                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(p => p.FullName.Contains(name) || 
                                           p.FirstName.Contains(name) || 
                                           p.LastName.Contains(name));
                }

                // فلترة حسب النوع
                if (!string.IsNullOrWhiteSpace(gender))
                {
                    query = query.Where(p => p.Gender == ParseGender(gender));
                }

                // فلترة حسب الحالة
                if (isActive.HasValue)
                {
                    query = query.Where(p => p.IsActive == isActive.Value);
                }

                var totalPatients = await query.CountAsync();

                var patients = await query
                    .OrderBy(p => p.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var patientDTOs = patients.Select(p => _mapper.Map<PatientDTO>(p));

                return new PagedPatientResultDTO
                {
                    Patients = patientDTOs,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPatients = totalPatients,
                    TotalPages = (int)Math.Ceiling((double)totalPatients / pageSize)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "خطأ في البحث المتقدم عن المرضى");
                throw;
            }
        }

        #endregion

        #region الدوال القديمة (للتوافق مع الكود الموجود)

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();
            var patients = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return patients.Select(p => _mapper.Map<PatientDTO>(p));
        }

        public async Task<IEnumerable<PatientDTO>> FilterPatientsAsync(string? name, string? gender)
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.FullName.Contains(name) || p.FirstName.Contains(name) || p.LastName.Contains(name));

            if (!string.IsNullOrWhiteSpace(gender))
                query = query.Where(p => p.Gender == ParseGender(gender));

            var result = await query.ToListAsync();
            return result.Select(p => _mapper.Map<PatientDTO>(p));
        }

        public async Task<IEnumerable<PatientDTO>> GetPatientFilter(int pageNumber, int pageSize, string? name , string? gender )
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.FullName.Contains(name) || p.FirstName.Contains(name) || p.LastName.Contains(name));

            if (!string.IsNullOrWhiteSpace(gender))
                query = query.Where(p => p.Gender == ParseGender(gender));

            var patients = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return patients.Select(p => _mapper.Map<PatientDTO>(p));
        }

        #endregion
    }
}
   
