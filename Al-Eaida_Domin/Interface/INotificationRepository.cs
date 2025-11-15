using Al_Eaida_Domin.Modules;

namespace Al_Eaida_Domin.Interface
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetByUserIdAsync(string userId);
        Task<IEnumerable<Notification>> GetByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(string userId);
        Task<IEnumerable<Notification>> GetUnreadByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Notification>> GetByAppointmentIdAsync(Guid appointmentId);
        Task<Notification?> GetByIdAsync(Guid id);
        Task<Notification> AddAsync(Notification notification);
        Task<Notification> UpdateAsync(Notification notification);
        Task<bool> MarkAsReadAsync(Guid notificationId);
        Task<bool> MarkAsReadByUserIdAsync(string userId);
        Task<int> GetUnreadCountByUserIdAsync(string userId);
        Task<int> GetUnreadCountByDoctorIdAsync(Guid doctorId);
        Task<bool> DeleteAsync(Guid notificationId);
        Task<IEnumerable<Notification>> GetRecentNotificationsAsync(int count = 10);
    }
}

