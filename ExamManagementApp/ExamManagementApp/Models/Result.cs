using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string EmployeeAnswer { get; set; }
        //Relations
        public int EmployeeId { get; set; }
        public int QuestionId { get; set; }
    }
}
