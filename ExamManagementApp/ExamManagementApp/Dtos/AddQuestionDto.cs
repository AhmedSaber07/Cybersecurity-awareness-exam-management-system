using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Dtos
{
    public class AddQuestionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string Text { get; set; }
        [Required(ErrorMessage = "*")]
        public string choiceA { get; set; }
        [Required(ErrorMessage = "*")]
        public string choiceB { get; set; }
        [Required(ErrorMessage = "*")]
        public string choiceC { get; set; }
        [Required(ErrorMessage = "*")]
        public string Answer { get; set; }
        [Required(ErrorMessage = "*")]
        public int Point { get; set; }
    }
}
