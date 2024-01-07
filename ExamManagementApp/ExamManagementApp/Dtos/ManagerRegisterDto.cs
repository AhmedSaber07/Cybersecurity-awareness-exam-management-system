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
        [Required(ErrorMessage ="*")]
        [MaxLength(50, ErrorMessage = "Maximum length of name is 50 character"), MinLength(3,ErrorMessage ="Minimum length of manager name is 3 character")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [EmailAddress]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string InstitueName { get; set; }
        [Required(ErrorMessage = "*")]
        [MinLength(8, ErrorMessage = "Minimum length of password is 8 character")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password is Weak! Choose a Strong Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password And Confirm Password Not Matched!")]
        public string ConfirmPassword { get; set; }
    }
}
