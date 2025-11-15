using Microsoft.EntityFrameworkCore;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using AL_Eaida_Infrastructure__Layer;

namespace AL_Eaida_Infrastructure__Layer.Repositery.NotificationRepository
{
    public class NotificationRepository : GenaricRepositery<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDBcontext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetByUserIdAsync(string userId)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .Where(n => n.DoctorId == doctorId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(string userId)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnreadByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .Where(n => n.DoctorId == doctorId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .Where(n => n.AppointmentId == appointmentId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public new async Task<Notification> AddAsync(Notification notification)
        {
            await _context.Set<Notification>().AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<Notification> UpdateAsync(Notification notification)
        {
            _context.Set<Notification>().Update(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<bool> MarkAsReadAsync(Guid notificationId)
        {
            var notification = await _context.Set<Notification>()
                .FirstOrDefaultAsync(n => n.Id == notificationId);
            
            if (notification == null) return false;

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkAsReadByUserIdAsync(string userId)
        {
            var notifications = await _context.Set<Notification>()
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetUnreadCountByUserIdAsync(string userId)
        {
            return await _context.Set<Notification>()
                .CountAsync(n => n.UserId == userId && !n.IsRead);
        }

        public async Task<int> GetUnreadCountByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Set<Notification>()
                .CountAsync(n => n.DoctorId == doctorId && !n.IsRead);
        }

        public async Task<bool> DeleteAsync(Guid notificationId)
        {
            var notification = await _context.Set<Notification>()
                .FirstOrDefaultAsync(n => n.Id == notificationId);
            
            if (notification == null) return false;

            _context.Set<Notification>().Remove(notification);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Notification>> GetRecentNotificationsAsync(int count = 10)
        {
            return await _context.Set<Notification>()
                .Include(n => n.Doctor)
                .Include(n => n.Patient)
                .Include(n => n.Appointment)
                .OrderByDescending(n => n.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}
