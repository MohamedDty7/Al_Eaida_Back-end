using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.InterFaceServices;
using Al_Eaida_Domin.Modules;
using Microsoft.AspNetCore.Authorization;
using EL_Eaida_Applcation.DTO.NotificationDTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Get all notifications for a user
        [HttpGet("GetUserNotifications/{userId}")]
        public async Task<IActionResult> GetUserNotifications(string userId)
        {
            try
            {
                var notifications = await _notificationService.GetUserNotificationsAsync(userId);
                return Ok(new { 
                    message = "تم استرجاع إشعارات المستخدم بنجاح",
                    notifications = notifications 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الإشعارات: {ex.Message}");
            }
        }

        // Get all notifications for a doctor
        [HttpGet("GetDoctorNotifications/{doctorId}")]
        public async Task<IActionResult> GetDoctorNotifications(Guid doctorId)
        {
            try
            {
                var notifications = await _notificationService.GetDoctorNotificationsAsync(doctorId);
                return Ok(new { 
                    message = "تم استرجاع إشعارات الطبيب بنجاح",
                    notifications = notifications 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع إشعارات الطبيب: {ex.Message}");
            }
        }

        // Get unread notifications for a user
        [HttpGet("GetUnreadUserNotifications/{userId}")]
        public async Task<IActionResult> GetUnreadUserNotifications(string userId)
        {
            try
            {
                var notifications = await _notificationService.GetUnreadUserNotificationsAsync(userId);
                return Ok(new { 
                    message = "تم استرجاع الإشعارات غير المقروءة بنجاح",
                    notifications = notifications 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الإشعارات غير المقروءة: {ex.Message}");
            }
        }

        // Get unread notifications for a doctor
        [HttpGet("GetUnreadDoctorNotifications/{doctorId}")]
        public async Task<IActionResult> GetUnreadDoctorNotifications(Guid doctorId)
        {
            try
            {
                var notifications = await _notificationService.GetUnreadDoctorNotificationsAsync(doctorId);
                return Ok(new { 
                    message = "تم استرجاع إشعارات الطبيب غير المقروءة بنجاح",
                    notifications = notifications 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع إشعارات الطبيب غير المقروءة: {ex.Message}");
            }
        }

        // Mark a notification as read
        [HttpPut("MarkAsRead/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(Guid notificationId)
        {
            try
            {
                var result = await _notificationService.MarkNotificationAsReadAsync(notificationId);
                if (result)
                {
                    return Ok("تم تمييز الإشعار كمقروء بنجاح");
                }
                return NotFound("الإشعار غير موجود");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تمييز الإشعار: {ex.Message}");
            }
        }

        // Mark all user notifications as read
        [HttpPut("MarkAllAsRead/{userId}")]
        public async Task<IActionResult> MarkAllAsRead(string userId)
        {
            try
            {
                var result = await _notificationService.MarkAllUserNotificationsAsReadAsync(userId);
                if (result)
                {
                    return Ok("تم تمييز جميع الإشعارات كمقروءة بنجاح");
                }
                return BadRequest("فشل في تمييز الإشعارات");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تمييز الإشعارات: {ex.Message}");
            }
        }

        // Get unread count for a user
        [HttpGet("GetUnreadCount/{userId}")]
        public async Task<IActionResult> GetUnreadCount(string userId)
        {
            try
            {
                var count = await _notificationService.GetUnreadCountForUserAsync(userId);
                return Ok(new { 
                    message = "تم استرجاع عدد الإشعارات غير المقروءة",
                    unreadCount = count 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع عدد الإشعارات: {ex.Message}");
            }
        }

        // Get unread count for a doctor
        [HttpGet("GetDoctorUnreadCount/{doctorId}")]
        public async Task<IActionResult> GetDoctorUnreadCount(Guid doctorId)
        {
            try
            {
                var count = await _notificationService.GetUnreadCountForDoctorAsync(doctorId);
                return Ok(new { 
                    message = "تم استرجاع عدد إشعارات الطبيب غير المقروءة",
                    unreadCount = count 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع عدد إشعارات الطبيب: {ex.Message}");
            }
        }

        // Delete a notification
        [HttpDelete("Delete/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(Guid notificationId)
        {
            try
            {
                var result = await _notificationService.DeleteNotificationAsync(notificationId);
                if (result)
                {
                    return Ok("تم حذف الإشعار بنجاح");
                }
                return NotFound("الإشعار غير موجود");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء حذف الإشعار: {ex.Message}");
            }
        }

        // Get recent notifications
        [HttpGet("GetRecentNotifications")]
        public async Task<IActionResult> GetRecentNotifications([FromQuery] int count = 10)
        {
            try
            {
                var notifications = await _notificationService.GetRecentNotificationsAsync(count);
                return Ok(new { 
                    message = "تم استرجاع الإشعارات الحديثة بنجاح",
                    notifications = notifications 
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الإشعارات الحديثة: {ex.Message}");
            }
        }

        // Send doctor availability notification (Admin only)
        [HttpPost("NotifyDoctorAvailability")]
        public async Task<IActionResult> NotifyDoctorAvailability([FromBody] DoctorAvailabilityNotificationDto dto)
        {
            try
            {
                await _notificationService.NotifyDoctorAvailabilityAsync(dto.DoctorId, dto.DoctorName, dto.IsAvailable);
                return Ok("تم إرسال إشعار حالة الطبيب بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء إرسال إشعار حالة الطبيب: {ex.Message}");
            }
        }

        // Send new doctor added notification (Admin only)
        [HttpPost("NotifyNewDoctor")]
        public async Task<IActionResult> NotifyNewDoctor([FromBody] NewDoctorNotificationDto dto)
        {
            try
            {
                await _notificationService.NotifyNewDoctorAddedAsync(dto.DoctorId, dto.DoctorName, dto.Specialization);
                return Ok("تم إرسال إشعار طبيب جديد بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء إرسال إشعار طبيب جديد: {ex.Message}");
            }
        }

        // Send doctor status change notification (Admin only)
        [HttpPost("NotifyDoctorStatusChange")]
        public async Task<IActionResult> NotifyDoctorStatusChange([FromBody] DoctorStatusChangeNotificationDto dto)
        {
            try
            {
                await _notificationService.NotifyDoctorStatusChangeAsync(dto.DoctorId, dto.DoctorName, dto.IsActive);
                return Ok("تم إرسال إشعار تغيير حالة الطبيب بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء إرسال إشعار تغيير حالة الطبيب: {ex.Message}");
            }
        }
    }
}
