using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.UserDTo
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "رقم الهاتف غير صحيح")]
        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}





















