using ExamManagementApp.Data;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers
{
    public class InstituteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InstituteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("managerId") == null)
                return RedirectToAction("LogIn");
            return View(_context.Institutes.OrderByDescending(e=>e.Id).ToList());
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("managerId") == null)
                return RedirectToAction("LogIn");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Institute school)
        {
            if (ModelState.IsValid)
            {
                school.Code = GenerateCode.GetInstitueCode(32);
                _context.Institutes.Add(school);
                await _context.SaveChangesAsync();
                ViewBag.schoolAdded = true;
                ModelState.Clear();
                return View();
            }
            return View(school);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("managerId") == null)
                return RedirectToAction("LogIn");
            if (id == null)
            {
                return RedirectToAction("LogIn");
            }

            var school = await _context.Institutes.FindAsync(id);
            if (school == null)
            {
                return RedirectToAction("LogIn");
            }
            return View(school);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Institute school)
        {
            if (id != school.Id)
            {
                return RedirectToAction("LogIn");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var getSchool = _context.Institutes.FirstOrDefault(e => e.Id == school.Id);
                    getSchool.Name = school.Name;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Id))
                    {
                        return RedirectToAction("LogIn");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(school);
        }
        private bool SchoolExists(int id)
        {
            return _context.Institutes.Any(e => e.Id == id);
        }
    }
}
