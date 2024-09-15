using ExamManagementApp.Data;
using ExamManagementApp.Dtos;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            TempData["EmployeeName"] = null;
            HttpContext.Session.Remove("EmployeeId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(EmployeeLoginDto employee)
        {
            if (ModelState.IsValid)
            {
                if (CheckCode(employee.Code))
                {
                    Institute getInstitute = _context.Institutes.FirstOrDefault(e => e.Code == employee.Code);
                    Employee Employee = new Employee();
                    Employee.Name = employee.Name;
                    Employee.InstituteId = getInstitute.Id;
                    _context.Employees.Add(Employee);
                    getInstitute.Employees?.Add(Employee);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("EmployeeId",employee.Id);
                    TempData["EmployeeName"] = employee.Name;
                    TempData.Keep();
                    return RedirectToAction("Instruction", "Exam",Employee);
                }
                else
                {
                    ViewBag.InvalidCode = "الكود غير صحيح";
                    return View(employee);
                }
            }
            return View(employee);
        }
        private bool CheckCode(string code)
        {
            return _context.Institutes.Any(e => e.Code == code);
        }
    }
}
