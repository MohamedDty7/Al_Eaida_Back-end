using System;
using System.ComponentModel.DataAnnotations;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public class CreatePatientDTO
    {
        [Required(ErrorMessage = "الاسم الأول مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأول يجب أن يكون أقل من 50 حرف")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم الأخير مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأخير يجب أن يكون أقل من 50 حرف")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم الكامل يجب أن يكون أقل من 100 حرف")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        [StringLength(100, ErrorMessage = "البريد الإلكتروني يجب أن يكون أقل من 100 حرف")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone(ErrorMessage = "صيغة رقم الهاتف غير صحيحة")]
        [StringLength(20, ErrorMessage = "رقم الهاتف يجب أن يكون أقل من 20 رقم")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
        [DataType(DataType.Date, ErrorMessage = "صيغة التاريخ غير صحيحة")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "الجنس مطلوب")]
        [RegularExpression("^(Male|Female|ذكر|أنثى)$", ErrorMessage = "الجنس يجب أن يكون Male أو Female أو ذكر أو أنثى")]
        public string Gender { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "اسم الشارع يجب أن يكون أقل من 200 حرف")]
        public string? Street { get; set; }

        [StringLength(20, ErrorMessage = "الرمز البريدي يجب أن يكون أقل من 20 حرف")]
        public string? ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "اسم البلد يجب أن يكون أقل من 100 حرف")]
        public string? Country { get; set; } = "مصر";

        public Guid? GovernorateId { get; set; }
        public Guid? CityId { get; set; }

        [StringLength(100, ErrorMessage = "اسم جهة الاتصال الطارئة يجب أن يكون أقل من 100 حرف")]
        public string? EmergencyContactName { get; set; }

        [StringLength(50, ErrorMessage = "صلة القرابة يجب أن تكون أقل من 50 حرف")]
        public string? EmergencyContactRelationship { get; set; }

        [Phone(ErrorMessage = "صيغة رقم هاتف جهة الاتصال الطارئة غير صحيحة")]
        [StringLength(20, ErrorMessage = "رقم هاتف جهة الاتصال الطارئة يجب أن يكون أقل من 20 رقم")]
        public string? EmergencyContactPhone { get; set; }

        [EmailAddress(ErrorMessage = "صيغة بريد جهة الاتصال الطارئة غير صحيحة")]
        [StringLength(100, ErrorMessage = "بريد جهة الاتصال الطارئة يجب أن يكون أقل من 100 حرف")]
        public string? EmergencyContactEmail { get; set; }

        [StringLength(50, ErrorMessage = "معرف التأمين يجب أن يكون أقل من 50 حرف")]
        public string? InsuranceInfoId { get; set; }
    }
}
