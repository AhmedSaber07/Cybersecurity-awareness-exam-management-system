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

        [Display(Name = "نص السؤال")]
        public string Text { get; set; }

        [Display(Name = "الاختيار A")]
        public string choiceA { get; set; }

        [Display(Name = "الاختيار B")]
        public string choiceB { get; set; }

        [Display(Name = "الاختيار C")]
        public string choiceC { get; set; }

        [Display(Name = "الإجابة الصحيحة")]
        public string Answer { get; set; }

        [Display(Name = "النقاط")]
        public int Point { get; set; }
    }

}
