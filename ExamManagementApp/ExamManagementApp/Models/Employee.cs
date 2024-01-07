using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Relation
        public int InstituteId { get; set; }
    }
}
