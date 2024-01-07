using ExamManagementApp.Data;
using ExamManagementApp.Dtos;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers.ControllerApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AdminApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetQuestion")]
        public IActionResult GetQuestion(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(e => e.Id == questionId);
            if (question == null)
                return NotFound();
            var jsonString = JsonConvert.SerializeObject(question);
            return Ok(jsonString);
        }
        [HttpDelete("DeleteQuestion")]
        public IActionResult DeleteQuestion(int questionId)
        {
            var question = _context.Questions.FirstOrDefault(e => e.Id == questionId);
            if (question == null)
                return NotFound();
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("DeleteInstitute")]
        public IActionResult DeleteInstitute(int InstituteId)
        {
            var institute = _context.Institutes.FirstOrDefault(e => e.Id == InstituteId);
            if (institute == null)
                return NotFound();
            _context.Institutes.Remove(institute);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("AddAnswer")]
        public IActionResult AddAnswer(EmployeeAnswerDto employeeAnswer)
        {
            var result = _context.Results.FirstOrDefault(e => e.EmployeeId == employeeAnswer.EmployeeId && e.QuestionId == employeeAnswer.QuestionId);
            if(result==null)
            {
                var newResult = new Result();
                newResult.EmployeeId = employeeAnswer.EmployeeId;
                newResult.QuestionId = employeeAnswer.QuestionId;
                newResult.EmployeeAnswer = employeeAnswer.EmployeeChoice;
                _context.Results.Add(newResult);
                _context.SaveChanges();
            }
            else
            {
                result.EmployeeAnswer = employeeAnswer.EmployeeChoice;
                _context.SaveChanges();
            }
            return Ok("Ok");
        }
        [HttpPost("GetQuestionStates")]
        public IActionResult GetQuestionStates(CheckEmployeeAnswerDto checkEmployeeAnswer)
        {
            var result = _context.Results.FirstOrDefault(e => e.QuestionId == checkEmployeeAnswer.QuestionId && e.EmployeeId == checkEmployeeAnswer.EmployeeId);
            if (result == null)
                return Ok("NotChecked");
            return Ok(result.EmployeeAnswer);

        }
        [HttpGet("GetCountAnswerdQuestion")]
        public IActionResult GetCountAnswerdQuestion(int EmployeeId)
        {
            var result = _context.Results.Where(e => e.EmployeeId == EmployeeId);
                return Ok(result.Count());
        }
            }
}
