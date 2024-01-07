using ExamManagementApp.Data;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Instruction(Employee employee)
        {
            if (HttpContext.Session.GetInt32("EmployeeId") == null)
                return RedirectToAction("NotFound", "Error");
            var checkEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (checkEmployee == null)
                return RedirectToAction("NotFound", "Error");
            return View(checkEmployee);
        }
        public IActionResult Start(int Id)
        {
            if (HttpContext.Session.GetInt32("EmployeeId") == null||Id==0)
                return RedirectToAction("NotFound", "Error");
            var checkUser = _context.Employees.FirstOrDefault(e => e.Id == Id);
            if (checkUser == null)
                return RedirectToAction("NotFound", "Error");
            TempData["EmpId"] = Id;
            TempData["EmployeeName"] = checkUser.Name;
            TempData.Keep();
            var questions = _context.Questions.ToList();
            var newQuestions = new List<Question>().DefaultIfEmpty();
            if (questions.Count > 20)
            {
                Random rnd = new Random();
                newQuestions = questions.OrderBy(x => rnd.Next()).Take(20);
            }
            else
                newQuestions = questions;
            return View(newQuestions);
        }
        [HttpGet]
        public IActionResult EmployeeEndExam()
        {
            if (HttpContext.Session.GetInt32("EmployeeId") == null)
                return RedirectToAction("NotFound", "Error");
            int employeeId = Convert.ToInt32(TempData["EmpId"]);
            FinalResult finalResult = new FinalResult();
            finalResult.EmployeeId = employeeId;
            finalResult.Grade = getEmployeeFinalGrade(employeeId);
            _context.FinalResults.Add(finalResult);
            _context.SaveChanges();
            TempData["EmployeeName"] = null;
            HttpContext.Session.Remove("EmployeeId");
            return RedirectToAction("Index", "Home");
        }
        private bool CheckAnswer(int empId, int questionId)
        {
            Result result = _context.Results.FirstOrDefault(e => e.EmployeeId == empId && e.QuestionId == questionId);
            Question question = _context.Questions.FirstOrDefault(e => e.Id == questionId);
            return result.EmployeeAnswer == question.Answer;
        }
        private int getGradeOfQuestion(int questionId)
        {
            Question question = _context.Questions.FirstOrDefault(e => e.Id == questionId);
            return question.Point;
        }
        private int getEmployeeFinalGrade(int empId)
        {
            IEnumerable<Result> results = _context.Results.Where(e => e.EmployeeId == empId);
            int finalGrade = 0;
            foreach (var result in results)
            {
                if (CheckAnswer(empId, result.QuestionId))
                    finalGrade += getGradeOfQuestion(result.QuestionId);
            }
            return finalGrade;
        }

    }
}
