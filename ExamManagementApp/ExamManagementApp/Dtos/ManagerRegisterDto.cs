using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class ManagerRegisterDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "الحد الأقصى لطول الاسم هو 50 حرف")]
        [MinLength(3, ErrorMessage = "الحد الأدنى لطول اسم المدير هو 3 أحرف")]
        [Display(Name = "اسم المدير")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "يرجى إدخال بريد إلكتروني صحيح")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "اسم المؤسسة")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "*")]
        [MinLength(8, ErrorMessage = "الحد الأدنى لطول كلمة المرور هو 8 أحرف")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "كلمة المرور ضعيفة! اختر كلمة مرور قوية")]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيد كلمة المرور غير متطابقتين!")]
        [Display(Name = "تأكيد كلمة المرور")]
        public string ConfirmPassword { get; set; }
    }

}
