using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamManagementApp.Data;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using ExamManagementApp.Dtos;

namespace ExamManagementApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn","Admin");
            return View(await _context.Questions.OrderByDescending(e => e.Id).ToListAsync());
        }
        

        // GET: Questions/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn", "Admin");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddQuestionDto addQuestionDto)
        {
            if (ModelState.IsValid)
            {
                if(addQuestionDto.choiceA.Trim() == addQuestionDto.choiceB.Trim() || addQuestionDto.choiceA.Trim() == addQuestionDto.choiceC.Trim() || addQuestionDto.choiceB.Trim() == addQuestionDto.choiceC.Trim())
                {
                    ViewBag.errorChoice = "each choice of question must be different";
                    return View(addQuestionDto);
                }
                Question question = new Question();
                question.Text = addQuestionDto.Text;
                question.choiceA = addQuestionDto.choiceA;
                question.choiceB = addQuestionDto.choiceB;
                question.choiceC = addQuestionDto.choiceC;
                question.Answer = addQuestionDto.Answer;
                question.Point = addQuestionDto.Point;
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                ViewBag.questionAdded = true;
                ModelState.Clear();
                return View();
            }
            return View(addQuestionDto);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn", "Admin");
            if (id == null)
            {
                return RedirectToAction("LogIn", "Admin");
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return RedirectToAction("LogIn", "Admin");
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Question question)
        {
            if (id != question.Id)
            {
                return RedirectToAction("LogIn", "Admin");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (question.choiceA.Trim() == question.choiceB.Trim() || question.choiceA.Trim() == question.choiceC.Trim() || question.choiceB.Trim() == question.choiceC.Trim())
                    {
                        ViewBag.errorChoice = "each choice of question must be different";
                        return View(question);
                    }
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return RedirectToAction("LogIn", "Admin");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
