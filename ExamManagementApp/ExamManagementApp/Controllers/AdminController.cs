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
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn");
            return View();
        }
        public IActionResult LogIn()
        {
            TempData["AdminName"] = null;
            HttpContext.Session.Remove("AdminId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(AdminLoginDto adminLogin)
        {
            if (ModelState.IsValid)
            {
                var getAdmin = _context.Admins.FirstOrDefault(e => e.Name == adminLogin.Name && e.Password == EncryptPassword.EncodePasswordToBase64(adminLogin.Password)) ;
                if (getAdmin == null)
                {
                    ViewBag.invalidaccount = "invalid account";
                    return View(getAdmin);
                }
                TempData["AdminName"] = getAdmin.Name;
                    HttpContext.Session.SetInt32("AdminId", getAdmin.Id);
                return RedirectToAction(nameof(index));
            }
            return View(adminLogin);
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn");
            HttpContext.Session.Remove("AdminId");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangePassowrd()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
                return RedirectToAction("LogIn");
            ChangeAdminPasswordDto changeAdminPassword = new ChangeAdminPasswordDto();
            return View(changeAdminPassword);
        }
        [HttpPost]
        public IActionResult ChangePassowrd(ChangeAdminPasswordDto changeAdminPassword)
        {
            if (ModelState.IsValid)
            {
                var getAdmin = _context.Admins.FirstOrDefault(e => e.Password == EncryptPassword.EncodePasswordToBase64(changeAdminPassword.OldPassword));
                if (getAdmin == null)
                {
                    ViewBag.invalidPassword = "Password is incorrect";
                    return View();
                }
                getAdmin.Password = EncryptPassword.EncodePasswordToBase64(changeAdminPassword.NewPassword);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(changeAdminPassword);
        }
    }
}
