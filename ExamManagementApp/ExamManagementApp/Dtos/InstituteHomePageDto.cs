using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class InstituteHomePageDto
    {
        public int Id { get; set; }

        [Display(Name = "الاسم : ")]
        public string? Name { get; set; }

        [Display(Name = "الرمز : ")]
        public string? Code { get; set; }

        [Display(Name = "عدد الموظفين : ")]
        public int? NumberOfEmployee { get; set; }

        public List<EmployeeResultDto> EmployeeResults { get; set; } = new List<EmployeeResultDto>();

        [Display(Name = "معدل الوعي : ")]
        public string AwarenessRate { get; set; }
    }

}
