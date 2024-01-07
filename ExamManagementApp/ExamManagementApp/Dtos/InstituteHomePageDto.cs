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
        [Display(Name = "Name : ")]
        public string? Name { get; set; }
        [Display(Name = "Code : ")]
        public string? Code { get; set; }
        [Display(Name="Number OF Employee : ")]
        public int? NumberOfEmployee { get; set; }
        public List<EmployeeResultDto> EmployeeResults { get; set; } = new List<EmployeeResultDto>();
        [Display(Name = "Awareness Rate : ")]
        public string AwarenessRate { get; set; }
    }
}
