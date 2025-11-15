using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class CreateAppointmentWithDetailsDto
    {
        [Required(ErrorMessage = "تاريخ الموعد مطلوب")]
        public DateTime AppointmentDate { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = "وقت الموعد مطلوب")]
        public string Time { get; set; } = string.Empty;

        [Required(ErrorMessage = "معرف المريض مطلوب")]
        public Guid PatientId { get; set; }

        [Required(ErrorMessage = "معرف الطبيب مطلوب")]
        public Guid DoctorId { get; set; }

        [Required(ErrorMessage = "معرف المستخدم مطلوب")]
        public string UserID { get; set; } = string.Empty;
    }
}





















