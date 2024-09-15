using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب إدخال النص.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "يجب إدخال الخيار A.")]
        public string choiceA { get; set; }

        [Required(ErrorMessage = "يجب إدخال الخيار B.")]
        public string choiceB { get; set; }

        [Required(ErrorMessage = "يجب إدخال الخيار C.")]
        public string choiceC { get; set; }

        [Required(ErrorMessage = "يجب تحديد الإجابة.")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "يجب إدخال النقاط.")]
        public int Point { get; set; }

        // Relation
        public List<Institute> Institutes { get; set; }
    }

}
