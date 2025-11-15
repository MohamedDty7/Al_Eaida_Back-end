using System;

namespace EL_Eaida_Applcation.DTO.EmergencyContactDTO
{
    public class EmergencyContactDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Relationship { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
    }
}