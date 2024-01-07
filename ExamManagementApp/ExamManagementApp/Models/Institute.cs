using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Models
{
    public class Institute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        //Relations
        public int ManagerId { get; set; }
        public List<Question> Questions { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
