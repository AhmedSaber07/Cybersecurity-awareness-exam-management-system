using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class EmployeeAnswerDto
    {
        public int EmployeeId { get; set; }
        public int QuestionId { get; set; }
        public string EmployeeChoice { get; set; }
    }
}
