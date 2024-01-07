using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class ManagerLogInDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
