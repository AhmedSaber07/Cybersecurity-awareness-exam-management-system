using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            TempData["ManagerName"] = null;
            HttpContext.Session.Remove("ManagerId");
            TempData["EmployeeName"] = null;
            HttpContext.Session.Remove("EmployeeId");
            TempData["AdminName"] = null;
            HttpContext.Session.Remove("AdminId");
            return View();
        }
        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetInt32("ManagerId") == null)
                return RedirectToAction("LogIn","Manager");
            TempData["ManagerName"] = null;
            HttpContext.Session.Remove("ManagerId");
            return RedirectToAction("Index", "Home");
        }
    }
}
