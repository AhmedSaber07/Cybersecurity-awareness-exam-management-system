using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class EmployeeLoginDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "الرمز")]
        public string Code { get; set; }
    }

}
