using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.UserDTo
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "كلمة المرور الحالية مطلوبة")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "كلمة المرور الجديدة مطلوبة")]
        [MinLength(8, ErrorMessage = "كلمة المرور يجب أن تكون 8 أحرف على الأقل")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [Compare("NewPassword", ErrorMessage = "كلمة المرور الجديدة وتأكيدها غير متطابقين")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}





















