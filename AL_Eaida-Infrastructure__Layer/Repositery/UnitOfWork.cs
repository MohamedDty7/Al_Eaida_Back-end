
using Al_Eaida_Domin.Interface;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.DoctorScheduleRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.DoctorSpecializationRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.MedicationCategoryRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.ReceptionistRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.ClinicSettingsRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.SystemSettingsRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.FinancialReportRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.ReportRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.AuditLogRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.AppointmentRepositery;
using AL_Eaida_Infrastructure__Layer.Repositery.NotificationRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace AL_Eaida_Infrastructure__Layer.Repositery
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBcontext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        // Specific repositories
        private IDoctorScheduleRepository? _doctorScheduleRepository;
        private IDoctorSpecializationRepository? _doctorSpecializationRepository;
        private IMedicationCategoryRepository? _medicationCategoryRepository;
        private IReceptionistRepository? _receptionistRepository;
        private IClinicSettingsRepository? _clinicSettingsRepository;
        private ISystemSettingsRepository? _systemSettingsRepository;
        private IFinancialReportRepository? _financialReportRepository;
        private IReportRepository? _reportRepository;
        private IAuditLogRepository? _auditLogRepository;
        private IAppointmentRepositery? _appointmentRepository;
        private INotificationRepository? _notificationRepository;

        public UnitOfWork(AppDBcontext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenaricRepositery<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repoInstance = new GenaricRepositery<T>(_context);
                _repositories.Add(typeof(T), repoInstance);
            }

            return (IGenaricRepositery<T>)_repositories[typeof(T)];
        }

        // Specific repository properties
        public IDoctorScheduleRepository DoctorScheduleRepository
        {
            get
            {
                _doctorScheduleRepository ??= new DoctorScheduleRepositery.DoctorScheduleRepositery(_context);
                return _doctorScheduleRepository;
            }
        }

        public IDoctorSpecializationRepository DoctorSpecializationRepository
        {
            get
            {
                _doctorSpecializationRepository ??= new DoctorSpecializationRepositery.DoctorSpecializationRepositery(_context);
                return _doctorSpecializationRepository;
            }
        }

        public IMedicationCategoryRepository MedicationCategoryRepository
        {
            get
            {
                _medicationCategoryRepository ??= new MedicationCategoryRepositery.MedicationCategoryRepositery(_context);
                return _medicationCategoryRepository;
            }
        }

        public IReceptionistRepository ReceptionistRepository
        {
            get
            {
                _receptionistRepository ??= new ReceptionistRepositery.ReceptionistRepositery(_context);
                return _receptionistRepository;
            }
        }

        public IClinicSettingsRepository ClinicSettingsRepository
        {
            get
            {
                _clinicSettingsRepository ??= new ClinicSettingsRepositery.ClinicSettingsRepositery(_context);
                return _clinicSettingsRepository;
            }
        }

        public ISystemSettingsRepository SystemSettingsRepository
        {
            get
            {
                _systemSettingsRepository ??= new SystemSettingsRepositery.SystemSettingsRepositery(_context);
                return _systemSettingsRepository;
            }
        }

        public IFinancialReportRepository FinancialReportRepository
        {
            get
            {
                _financialReportRepository ??= new FinancialReportRepositery.FinancialReportRepositery(_context);
                return _financialReportRepository;
            }
        }

        public IReportRepository ReportRepository
        {
            get
            {
                _reportRepository ??= new ReportRepositery.ReportRepositery(_context);
                return _reportRepository;
            }
        }

        public IAuditLogRepository AuditLogRepository
        {
            get
            {
                _auditLogRepository ??= new AuditLogRepositery.AuditLogRepositery(_context);
                return _auditLogRepository;
            }
        }

        public IAppointmentRepositery AppointmentRepository
        {
            get
            {
                _appointmentRepository ??= new AppointmentRepositery.AppointmentRepositery(_context);
                return _appointmentRepository;
            }
        }

        public INotificationRepository NotificationRepository
        {
            get
            {
                _notificationRepository ??= new NotificationRepository.NotificationRepository(_context);
                return _notificationRepository;
            }
        }

    }
}
