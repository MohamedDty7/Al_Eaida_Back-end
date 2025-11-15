using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.DTO.Prescription;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;
using EL_Eaida_Applcation.InterFaceServices;

namespace EL_Eaida_Applcation.Services
{
    public class AppointmentServices : IAppointmentService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitofwork;
        private readonly INotificationService _notificationService;

        public AppointmentServices(IMapper mapper, IUnitOfWork unitofwork, INotificationService notificationService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _notificationService = notificationService;
        }
        public async Task<AppointmentDto> Createappointment(CreateAppointmentDto value)
        {
            var appointment = _mapper.Map<Appointment>(value);
            await _unitofwork.Repository<Appointment>().AddAsync(appointment);
            await _unitofwork.CompleteAsync();

            await _notificationService.NotifyAppointmentCreatedAsync(
                appointment.Id,
                appointment.DoctorId,
                appointment.PatientId,
                appointment.UserID
            );

            return _mapper.Map<AppointmentDto>(appointment);
        }

        // Create appointment with patient and doctor details
        public async Task<AppointmentWithDetailsDto> CreateAppointmentWithDetailsAsync(CreateAppointmentWithDetailsDto dto)
        {
            // Create the appointment
            var appointment = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                Notes = dto.Notes,
                Time = dto.Time,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                UserID = dto.UserID,
                Status = AppointmentStatus.في_الانتظار
            };

            await _unitofwork.Repository<Appointment>().AddAsync(appointment);
            await _unitofwork.CompleteAsync();

            await _notificationService.NotifyAppointmentCreatedAsync(
                appointment.Id,
                appointment.DoctorId,
                appointment.PatientId,
                appointment.UserID
            );

            // Get appointment with details
            var appointmentWithDetails = await _unitofwork.AppointmentRepository.GetByIdWithDetailsAsync(appointment.Id);

            if (appointmentWithDetails == null)
            {
                throw new Exception("فشل في إنشاء الموعد");
            }

            // Map to response DTO - فقط اسم المريض والطبيب
            var response = new AppointmentWithDetailsDto
            {
                Id = appointmentWithDetails.Id,
                Date = appointmentWithDetails.AppointmentDate,
                Notes = appointmentWithDetails.Notes,
                Status = appointmentWithDetails.Status.ToString(),
                Time = appointmentWithDetails.Time,
                Type = appointmentWithDetails.Type,
                Duration = appointmentWithDetails.Duration,
                PatientId = appointmentWithDetails.PatientId,
                PatientName = appointmentWithDetails.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointmentWithDetails.Patient?.Phone ?? "",
                DoctorId = appointmentWithDetails.DoctorId,
                DoctorName = $"{appointmentWithDetails.Doctor?.FirstName} {appointmentWithDetails.Doctor?.LastName}".Trim(),
                UserID = appointmentWithDetails.UserID
            };

            return response;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(id);
            var result = await _unitofwork.Repository<Appointment>().Delete(appointment);
            await _unitofwork.CompleteAsync();
            return true;



        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _unitofwork.AppointmentRepository.GetAllWithDetailsAsync();
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            var appointment = await _unitofwork.AppointmentRepository.GetByIdWithDetailsAsync(id);
            if (appointment == null)
                return null;

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            await _unitofwork.CompleteAsync();
            return appointmentDto;
        }

        public async Task<string> UpdateAsync(Guid id, UpdateAppointmentDto value)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(id);
            if (appointment == null)
                return "Appointment not found";

            if (!string.IsNullOrWhiteSpace(value.Notes))
            {
                appointment.Notes = value.Notes;
            }

            if (value.AppointmentDate.HasValue)
            {
                appointment.AppointmentDate = value.AppointmentDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(value.Status))
            {
                appointment.Status = Enum.Parse<AppointmentStatus>(value.Status);
            }

            if (!string.IsNullOrWhiteSpace(value.Time))
            {
                appointment.Time = value.Time;
            }

            if (!string.IsNullOrWhiteSpace(value.Type))
            {
                appointment.Type = value.Type;
            }

            if (value.Duration.HasValue)
            {
                appointment.Duration = value.Duration.Value;
            }

            if (value.PatientId.HasValue)
            {
                appointment.PatientId = value.PatientId.Value;
            }

            if (value.DoctorId.HasValue)
            {
                appointment.DoctorId = value.DoctorId.Value;
            }

            if (!string.IsNullOrWhiteSpace(value.UserID))
            {
                appointment.UserID = value.UserID;
            }

            await _unitofwork.Repository<Appointment>().Update(appointment);
            await _unitofwork.CompleteAsync();

            return "Appointment updated successfully";
        }

        // New methods for enhanced appointment management
        public async Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(Guid patientId)
        {
            var appointments = await _unitofwork.AppointmentRepository.GetByPatientIdAsync(patientId);
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        public async Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(Guid doctorId)
        {
            var appointments = await _unitofwork.AppointmentRepository.GetByDoctorIdAsync(doctorId);
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        public async Task<IEnumerable<AppointmentDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var appointments = await _unitofwork.AppointmentRepository.GetByDateRangeAsync(startDate, endDate);
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        public async Task<IEnumerable<AppointmentDto>> GetByStatusAsync(string status)
        {
            if (!Enum.TryParse<AppointmentStatus>(status, out var appointmentStatus))
            {
                throw new ArgumentException("Invalid appointment status");
            }

            var appointments = await _unitofwork.AppointmentRepository.GetByStatusAsync(appointmentStatus);
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        // Get all appointments with patient and doctor details
        public async Task<IEnumerable<AppointmentWithDetailsDto>> GetAllAppointmentsWithDetailsAsync()
        {
            var appointments = await _unitofwork.AppointmentRepository.GetAllWithDetailsAsync();

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        // Advanced filtering methods implementation
        public async Task<IEnumerable<AppointmentWithDetailsDto>> FilterByStatusAsync(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("يجب تحديد حالة الموعد");
            }

            if (!Enum.TryParse<AppointmentStatus>(status, out var appointmentStatus))
            {
                throw new ArgumentException("حالة الموعد غير صحيحة");
            }

            var appointments = await _unitofwork.AppointmentRepository.GetByStatusAsync(appointmentStatus);

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        public async Task<IEnumerable<AppointmentWithDetailsDto>> FilterByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            var appointments = await _unitofwork.AppointmentRepository.GetByDateRangeAsync(
                startDate ?? DateTime.MinValue,
                endDate ?? DateTime.MaxValue);

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        public async Task<IEnumerable<AppointmentWithDetailsDto>> FilterByDoctorAsync(Guid? doctorId, string? doctorName)
        {
            IEnumerable<Appointment> appointments;

            if (doctorId.HasValue)
            {
                appointments = await _unitofwork.AppointmentRepository.GetByDoctorIdAsync(doctorId.Value);
            }
            else if (!string.IsNullOrEmpty(doctorName))
            {
                appointments = await _unitofwork.AppointmentRepository.GetByDoctorNameAsync(doctorName);
            }
            else
            {
                throw new ArgumentException("يجب تحديد معرف الطبيب أو اسم الطبيب");
            }

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        public async Task<IEnumerable<AppointmentWithDetailsDto>> FilterByPatientAndDoctorAsync(Guid? patientId, Guid? doctorId, string? patientName, string? doctorName)
        {
            IEnumerable<Appointment> appointments;

            if (patientId.HasValue && doctorId.HasValue)
            {
                appointments = await _unitofwork.AppointmentRepository.GetByPatientAndDoctorIdAsync(patientId.Value, doctorId.Value);
            }
            else if (patientId.HasValue && !string.IsNullOrEmpty(doctorName))
            {
                appointments = await _unitofwork.AppointmentRepository.GetByPatientIdAndDoctorNameAsync(patientId.Value, doctorName);
            }
            else if (!string.IsNullOrEmpty(patientName) && doctorId.HasValue)
            {
                appointments = await _unitofwork.AppointmentRepository.GetByPatientNameAndDoctorIdAsync(patientName, doctorId.Value);
            }
            else if (!string.IsNullOrEmpty(patientName) && !string.IsNullOrEmpty(doctorName))
            {
                appointments = await _unitofwork.AppointmentRepository.GetByPatientNameAndDoctorNameAsync(patientName, doctorName);
            }
            else
            {
                throw new ArgumentException("يجب تحديد معرف المريض أو اسم المريض مع معرف الطبيب أو اسم الطبيب");
            }

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        public async Task<IEnumerable<AppointmentWithDetailsDto>> AdvancedSearchAsync(
            string? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            Guid? patientId = null,
            Guid? doctorId = null,
            string? patientName = null,
            string? doctorName = null,
            string? specialization = null,
            int pageNumber = 1,
            int pageSize = 50)
        {
            var appointments = await _unitofwork.AppointmentRepository.AdvancedSearchAsync(
                status, startDate, endDate, patientId, doctorId,
                patientName, doctorName, specialization, pageNumber, pageSize);

            var appointmentsWithDetails = appointments.Select(appointment => new AppointmentWithDetailsDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                DoctorName = $"{appointment.Doctor?.FirstName} {appointment.Doctor?.LastName}".Trim(),
                UserID = appointment.UserID
            });

            await _unitofwork.CompleteAsync();
            return appointmentsWithDetails;
        }

        // طرق جديدة لإدارة حالة الموعد مع الإشعارات
        public async Task<bool> StartAppointmentAsync(Guid appointmentId, string doctorId)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            // تحديث حالة الموعد إلى "جاري الفحص"
            appointment.Status = AppointmentStatus.جاري_الفحص;
            await _unitofwork.CompleteAsync();

            await _notificationService.NotifyAppointmentStartedAsync(
                appointment.Id,
                appointment.DoctorId,
                appointment.PatientId
            );

            return true;
        }

        public async Task<bool> EndAppointmentAsync(Guid appointmentId, string doctorId)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            // تحديث حالة الموعد إلى "مكتمل"
            appointment.Status = AppointmentStatus.مكتمل;
            await _unitofwork.CompleteAsync();

            await _notificationService.NotifyAppointmentCompletedAsync(
                appointment.Id,
                appointment.DoctorId,
                appointment.PatientId
            );

            return true;
        }

        public async Task<bool> ChangeAppointmentStatusAsync(Guid appointmentId, string newStatus, string changedBy)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            var oldStatus = appointment.Status.ToString();

            // تحديث حالة الموعد
            appointment.Status = ParseAppointmentStatus(newStatus);
            await _unitofwork.CompleteAsync();

            // إرسال إشعار للدكتور عن تغيير الحالة
            // TODO: إضافة نظام الإشعارات

            return true;
        }

        public async Task<bool> ScheduleAppointmentReminderAsync(Guid appointmentId, int minutesBefore)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            // حساب وقت التذكير
            var appointmentDateTime = appointment.AppointmentDate.Date + TimeSpan.Parse(appointment.Time);
            var reminderTime = appointmentDateTime.AddMinutes(-minutesBefore);

            // إرسال تذكير مجدول
            // يمكن لاحقاً استخدام Quartz لإرسال التذكير

            return true;
        }

        public async Task<bool> CancelAppointmentAsync(Guid appointmentId, string cancelledBy)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(appointmentId);
            if (appointment == null) return false;

            appointment.Status = AppointmentStatus.ملغي;
            await _unitofwork.CompleteAsync();

            await _notificationService.NotifyAppointmentCancelledAsync(
                appointment.Id,
                appointment.DoctorId,
                appointment.PatientId,
                cancelledBy
            );

            return true;
        }

        private AppointmentStatus ParseAppointmentStatus(string status)
        {
            return status switch
            {
                "مؤكد" => AppointmentStatus.مؤكد,
                "في_الانتظار" or "في الانتظار" => AppointmentStatus.في_الانتظار,
                "جاري_الفحص" or "جاري الفحص" => AppointmentStatus.جاري_الفحص,
                "مكتمل" => AppointmentStatus.مكتمل,
                "تأجيل" => AppointmentStatus.تأجيل,
                "ملغي" => AppointmentStatus.ملغي,
                _ => AppointmentStatus.في_الانتظار
            };
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorOnlyAsync( string Userid , int pageNumber, int pageSize)
        {
            var appointments = await _unitofwork.AppointmentRepository.GetAppointmentbyUser(Userid);
            var appointmentDtos = appointments.Select(appointment => new AppointmentDto
            {
                Id = appointment.Id,
                Date = appointment.AppointmentDate,
                Notes = appointment.Notes,
                Status = appointment.Status.ToString(),
                Time = appointment.Time,
                Type = appointment.Type,
                Duration = appointment.Duration,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName ?? "غير محدد",
                PatientPhone = appointment.Patient?.Phone ?? "",
                DoctorId = appointment.DoctorId,
                UserID = appointment.UserID
            }).Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }
    }

}
