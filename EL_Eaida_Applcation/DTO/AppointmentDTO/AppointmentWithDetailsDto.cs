namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class AppointmentWithDetailsDto
    {
        public Guid Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public DateTime Date { get; set; } // AppointmentDate
        public string Time { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // مؤكد | في الانتظار | جاري الفحص | مكتمل | تأجيل | ملغي
        public string Type { get; set; } = string.Empty; // نوع الموعد
        public string Notes { get; set; } = string.Empty;
        public int Duration { get; set; } = 30; // مدة الموعد بالدقائق

        // Patient Details
        public Guid PatientId { get; set; }

        // Doctor Details
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        // User Details
        public string UserID { get; set; } = string.Empty;
    }
}
