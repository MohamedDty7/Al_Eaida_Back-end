using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Al_Eaida_Domin.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenaricRepositery<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

        // Specific repository properties
        IDoctorScheduleRepository DoctorScheduleRepository { get; }
        IDoctorSpecializationRepository DoctorSpecializationRepository { get; }
        IMedicationCategoryRepository MedicationCategoryRepository { get; }
        IReceptionistRepository ReceptionistRepository { get; }
        IClinicSettingsRepository ClinicSettingsRepository { get; }
        ISystemSettingsRepository SystemSettingsRepository { get; }
        IFinancialReportRepository FinancialReportRepository { get; }
        IReportRepository ReportRepository { get; }
        IAuditLogRepository AuditLogRepository { get; }
        IAppointmentRepositery AppointmentRepository { get; }
        INotificationRepository NotificationRepository { get; }
    }
}
