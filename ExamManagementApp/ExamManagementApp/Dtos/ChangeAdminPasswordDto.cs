using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class ChangeAdminPasswordDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum length of password is 8 character")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password is Weak! Choose a Strong Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password And Confirm Password Not Matched!")]
        public string ConfirmNewPassword { get; set; }
    }
}
