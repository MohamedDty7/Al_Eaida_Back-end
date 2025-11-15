using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.UserDTo
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string Username { get; set; }  // ← يستخدم Username
        public string Email { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        public List<string> Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Token { get; set; }
    }
}
