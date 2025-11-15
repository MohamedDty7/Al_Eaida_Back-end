namespace EL_Eaida_Applcation.DTO.DoctorSpecializationDTO
{
    public class DoctorSpecializationDTO
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid SpecializationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? DoctorName { get; set; }
        public string? SpecializationName { get; set; }
    }
}
