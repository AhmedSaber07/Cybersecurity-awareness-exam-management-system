using ExamManagementApp.Data;
using ExamManagementApp.Dtos;
using ExamManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
namespace ExamManagementApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("ManagerId") == null)
                return RedirectToAction("LogIn");
            int managerId = Convert.ToInt32(HttpContext.Session.GetInt32("ManagerId"));
            TempData["ManagerName"] =_context.Managers.FirstOrDefault(e=>e.Id==managerId).Name;
            TempData.Keep();
            #region
            /*
            InstituteHomePageDto instituteHomePageDto = new InstituteHomePageDto();
            instituteHomePageDto.EmployeeResults = new List<EmployeeResultDto>();
            Institute institute = _context.Institutes.FirstOrDefault(e => e.ManagerId == managerId);
            IEnumerable<Employee> employees = _context.Employees.Where(e => e.InstituteId == institute.Id).OrderByDescending(e=>e.Id);
            instituteHomePageDto.Name = institute.Name;
            instituteHomePageDto.Code = institute.Code;
            instituteHomePageDto.NumberOfEmployee = employees.Count();
            double totalGrade=0;
            foreach (var emp in employees)
            {
                var getEmp = _context.FinalResults.FirstOrDefault(e => e.EmployeeId == emp.Id);
                if (getEmp == null)
                    instituteHomePageDto.EmployeeResults?.Add(new EmployeeResultDto { Name = emp.Name, Grade = 0 });
                else
                {
                    instituteHomePageDto.EmployeeResults?.Add(new EmployeeResultDto { Name = emp.Name, Grade = getEmp.Grade });
                    totalGrade += getEmp.Grade;
                }
            }
            double rate = (((double)(totalGrade / instituteHomePageDto.NumberOfEmployee)));
            instituteHomePageDto.AwarenessRate =  rate==0?rate.ToString("F2")+" %":" ";
            */
            #endregion
            InstituteHomePageDto data = new InstituteHomePageDto();
            data = GetResult(managerId);
            return View(data);
        }
        public IActionResult Register()
        {
            TempData["ManagerName"] = null;
            HttpContext.Session.Remove("ManagerId");
            ManagerRegisterDto managerRegisterDto = new ManagerRegisterDto();
            return View(managerRegisterDto);
        }
        [HttpPost]
        public IActionResult Register(ManagerRegisterDto managerRegisterDto)
        {
            if(ModelState.IsValid)
            {
                var checkEmail = _context.Managers.FirstOrDefault(e => e.Email == managerRegisterDto.Email);
                if(checkEmail!=null)
                {
                    ViewBag.EmailExists = "هذا الايميل موجود مسبقا";
                    return View(managerRegisterDto);
                }
                Manager manager = new Manager();
                manager.Name = managerRegisterDto.Name;
                manager.Email = managerRegisterDto.Email;
                manager.Password = EncryptPassword.EncodePasswordToBase64(managerRegisterDto.Password);
                _context.Managers.Add(manager);
                _context.SaveChanges();
                int managerId = _context.Managers.FirstOrDefault(e => e.Email == managerRegisterDto.Email).Id;
                Institute institute = new Institute();
                institute.Name = managerRegisterDto.InstituteName;
                institute.Code = GenerateCode.GetInstitueCode(32);
                institute.ManagerId = managerId;
                _context.Institutes.Add(institute);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("ManagerId",managerId);
                TempData["ManagerName"] = manager.Name;
                TempData.Keep();
                return RedirectToAction(nameof(Index));
            }
            return View(managerRegisterDto);
        }
        public IActionResult LogIn()
        {
            TempData["ManagerName"] = null;
            HttpContext.Session.Remove("ManagerId");
            ManagerLogInDto managerLogInDto = new ManagerLogInDto();
            return View(managerLogInDto);
        }
        [HttpPost]
        public IActionResult LogIn(ManagerLogInDto managerLogInDto)
        {
            if (ModelState.IsValid)
            {
                var checkManager = _context.Managers.FirstOrDefault(e => e.Email == managerLogInDto.Email && e.Password == EncryptPassword.EncodePasswordToBase64(managerLogInDto.Password));
                if(checkManager is null)
                {
                    ViewBag.ManagerNotFound = "خطا في البريد الالكتروني او كلمة المرور";
                    return View(managerLogInDto);
                }
                HttpContext.Session.SetInt32("ManagerId", checkManager.Id);
                TempData["ManagerName"] = checkManager.Name;
                TempData.Keep();
                return RedirectToAction(nameof(Index));
            }
            else
            return View(managerLogInDto);
        }
        [HttpPost]
        public IActionResult ExportEmployeeResultReport()
        {
            if (HttpContext.Session.GetInt32("ManagerId") == null)
                return RedirectToAction("LogIn");

            int managerId = Convert.ToInt32(HttpContext.Session.GetInt32("ManagerId"));
            InstituteHomePageDto data = GetResult(managerId);

            if (data.EmployeeResults.Count != 0)
            {
                // Load the image and convert it to a base64 string
                string imagePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "hadeel-high-resolution-logo-transparent (1).png");
                string base64Image = Convert.ToBase64String(System.IO.File.ReadAllBytes(imagePath));
                string imageSrc = $"data:image/png;base64,{base64Image}";

                StringBuilder stringBuilder = new StringBuilder();

                // Header section
                stringBuilder.Append("<div style='text-align: center; padding-bottom: 20px; border-bottom: 2px solid #0056b3;'>");
                stringBuilder.Append($"<img src='{imageSrc}' style='width: 100px; height: auto; margin-bottom: 10px;' alt='Logo' />");
                stringBuilder.Append("<h1 style='font-family: Arial; font-size: 24pt; color: #0056b3; margin: 0;'>Institute Report</h1>");
                stringBuilder.Append("<p style='font-family: Arial; font-size: 12pt; color: #555;'>Cyber Security Awareness Examination Results</p>");
                stringBuilder.Append("</div>");

                // Institute Information
                stringBuilder.Append("<div style='padding: 20px; margin-bottom: 20px; background-color: #f7f7f7; border-radius: 8px;'>");
                stringBuilder.Append("<h2 style='font-family: Arial; font-size: 20pt; color: #333;'>Institute Information</h2>");
                stringBuilder.Append("<p style='font-family: Arial; font-size: 14pt;'><strong>Institute Name: </strong>" + data.Name + "</p>");
                stringBuilder.Append("<p style='font-family: Arial; font-size: 14pt;'><strong>Number of Employees: </strong>" + data.NumberOfEmployee + "</p>");
                stringBuilder.Append("<div style='margin: 10px 0; font-family: Arial; font-size: 14pt;'><strong>Awareness Rate: </strong>" + data.AwarenessRate + "</div>");
                stringBuilder.Append("<div style='width: 300px; height: 20px; border-radius: 10px; background-color: #e0e0e0; margin-top: 10px;'>");
                stringBuilder.Append("<div style='width: " + data.AwarenessRate + "; height: 100%; background-color: green; border-radius: 10px;'></div>");
                stringBuilder.Append("</div>");
                stringBuilder.Append("</div>");

                // Employee Results Table
                stringBuilder.Append("<table style='width: 100%; border-collapse: collapse; font-family: Arial; font-size: 12pt; margin-bottom: 20px;'>");
                stringBuilder.Append("<thead>");
                stringBuilder.Append("<tr style='background-color: #0056b3; color: white;'>");
                stringBuilder.Append("<th style='padding: 10px; border: 1px solid #ccc;'>Employee Name</th>");
                stringBuilder.Append("<th style='padding: 10px; border: 1px solid #ccc;'>Grade</th>");
                stringBuilder.Append("</tr>");
                stringBuilder.Append("</thead>");
                stringBuilder.Append("<tbody>");

                // Alternating row colors for better readability
                bool isEvenRow = true;
                foreach (var item in data.EmployeeResults)
                {
                    string rowStyle = isEvenRow ? "background-color: #f0f8ff;" : "background-color: white;";
                    stringBuilder.Append("<tr style='" + rowStyle + "'>");
                    stringBuilder.Append("<td style='padding: 10px; border: 1px solid #ccc;'>" + item.Name + "</td>");
                    stringBuilder.Append("<td style='padding: 10px; border: 1px solid #ccc;'>" + item.Grade + "</td>");
                    stringBuilder.Append("</tr>");
                    isEvenRow = !isEvenRow;
                }

                stringBuilder.Append("</tbody>");
                stringBuilder.Append("</table>");

                // Footer section
                stringBuilder.Append("<div style='text-align: center; margin-top: 20px; font-family: Arial; font-size: 10pt; color: #777; border-top: 1px solid #ddd; padding-top: 10px;'>");
                stringBuilder.Append("<p>Generated by Hadeel Tech - Cyber Security Awareness Platform</p>");
                stringBuilder.Append("<p>Page 1 of 1</p>"); // You may implement dynamic page numbering if required
                stringBuilder.Append("</div>");

                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(stringBuilder.ToString())))
                {
                    MemoryStream byteArrayOutputStream = new MemoryStream();
                    PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                    PdfDocument pdfDocument = new PdfDocument(writer);
                    pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);
                    HtmlConverter.ConvertToPdf(stream, pdfDocument);
                    pdfDocument.Close();
                    return File(byteArrayOutputStream.ToArray(), "application/pdf", "EmployeesGrade.pdf");
                }
            }
            return RedirectToAction(nameof(Index));
        }



  //      [HttpPost]
  //      public IActionResult ExportAwarenessRateReport()
  //      {
  //          if (HttpContext.Session.GetInt32("ManagerId") == null)
  //              return RedirectToAction("LogIn");
  //          int managerId = Convert.ToInt32(HttpContext.Session.GetInt32("ManagerId"));
  //          InstituteHomePageDto data = GetResult(managerId);
  //          if (data.EmployeeResults.Count != 0)
  //          {
  //              //StringBuilder stringBuilder = new StringBuilder();
  //              //string minifiedCss = "@page{size:A4 landscape;margin:10mm;}.border-pattern{position:absolute;left:4mm;top:-6mm;height:200mm;width:267mm;border:1mm solid #991B1B;background-color:#d6d6e4;background-image:url(\"data:image/svg+xml,%3Csvg width='16' height='16' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M0 0h16v2h-6v6h6v8H8v-6H2v6H0V0zm4 4h2v2H4V4zm8 8h2v2h-2v-2zm-8 0h2v2H4v-2zm8-8h2v2h-2V4z' fill='%23991B1B' fill-opacity='1' fill-rule='evenodd'/%3E%3C/svg%3E\");}.content{position:absolute;left:10mm;top:10mm;height:178mm;width:245mm;border:1mm solid #991B1B;background:white;}.inner-content{border:1mm solid #991B1B;margin:4mm;padding:10mm;height:148mm;text-align:center;}h1{text-transform:uppercase;font-size:48pt;margin-bottom:0;}h2{font-size:24pt;margin-top:0;padding-bottom:1mm;display:inline-block;border-bottom:1mm solid #991B1B;}h2::after{content:\"\";display:block;padding-bottom:4mm;border-bottom:1mm solid #991B1B;}h3{font-size:20pt;margin-bottom:0;margin-top:10mm;}p{font-size:16pt;}.badges{width:40mm;height:40mm;position:absolute;right:10mm;bottom:10mm;background-image:url(\"data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor'%3E%3Cpath stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M9 12l2 2 4-4M7.835 4.697a3.42 3.42 0 001.946-.806 3.42 3.42 0 014.438 0 3.42 3.42 0 001.946.806 3.42 3.42 0 013.138 3.138 3.42 3.42 0 00.806 1.946 3.42 3.42 0 010 4.438 3.42 3.42 0 00-.806 1.946 3.42 3.42 0 01-3.138 3.138 3.42 3.42 0 00-1.946.806 3.42 3.42 0 01-4.438 0 3.42 3.42 0 00-1.946-.806 3.42 3.42 0 01-3.138-3.138 3.42 3.42 0 00-.806-1.946 3.42 3.42 0 010-4.438 3.42 3.42 0 00.806-1.946 3.42 3.42 0 013.138-3.138z' /%3E%3C/svg%3E\");}";
  //              //stringBuilder.Append("<html><head><style>" + minifiedCss + "</style></head>");
  //              //stringBuilder.Append("<body><div class='border-pattern'><div class='content'><div class='inner-content'><h1>Certificate</h1><h2>of Excellence</h2><h3>This Certificate Is Proudly Presented To</h3><p>Jane Doe</p><h3>Has Completed</h3><p>PrintCSS Basics Course</p><h3>On</h3><p>Feburary 5, 2021</p><div class='badges'></div></div></div></div></body></html>");
  //              StringBuilder stringBuilder = new StringBuilder();
  //              stringBuilder.Append(@"<html>
  //<head>
  //  <style>
  //    @page{
  //      size:A4 landscape;
  //      margin:10mm;
  //    }
  //    .border-pattern{
  //      position:absolute;
  //      left:4mm;
  //      top:-6mm;
  //      height:200mm;
  //      width:267mm;
  //      border:1mm solid #991B1B;
  //      /* http://www.heropatterns.com/ */
  //      background-color: #d6d6e4;
  //      background-image: url(""data:image/svg+xml,%3Csvg width='16' height='16' viewBox='0 0 16 16' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M0 0h16v2h-6v6h6v8H8v-6H2v6H0V0zm4 4h2v2H4V4zm8 8h2v2h-2v-2zm-8 0h2v2H4v-2zm8-8h2v2h-2V4z' fill='%23991B1B' fill-opacity='1' fill-rule='evenodd'/%3E%3C/svg%3E"");
  //    }
  //    .content{
  //      position:absolute;
  //      left:10mm;
  //      top:10mm;
  //      height:178mm;
  //      width:245mm;
  //      border:1mm solid #991B1B;
  //      background:white;
  //    }
  //    .inner-content{
  //      border:1mm solid #991B1B;
  //      margin:4mm;
  //      padding:10mm;
  //      height:148mm;
  //      text-align:center;
  //    }
  //    h1{
  //      text-transform:uppercase;
  //      font-size:48pt;
  //      margin-bottom:0;
  //    }
  //    h2{
  //      font-size:24pt;
  //      margin-top:0;
  //      padding-bottom:1mm;
  //      display:inline-block;
  //      border-bottom:1mm solid #991B1B;
  //    }
  //    h2::after{
  //      content:'';
  //      display:block;
  //      padding-bottom:4mm;
  //      border-bottom:1mm solid #991B1B;
  //    }
  //    h3{
  //      font-size:20pt;
  //      margin-bottom:0;
  //      margin-top:10mm;
  //    }
  //    p{
  //      font-size:16pt;
  //    }
  //    .badges{
  //      width:40mm;
  //      height:40mm;
  //      position:absolute;
  //      right:10mm;
  //      bottom:10mm;
  //      background-image:url(""data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor'%3E%3Cpath stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M9 12l2 2 4-4M7.835 4.697a3.42 3.42 0 001.946-.806 3.42 3.42 0 014.438 0 3.42 3.42 0 001.946.806 3.42 3.42 0 013.138 3.138 3.42 3.42 0 00.806 1.946 3.42 3.42 0 010 4.438 3.42 3.42 0 00-.806 1.946 3.42 3.42 0 01-3.138 3.138 3.42 3.42 0 00-1.946.806 3.42 3.42 0 01-4.438 0 3.42 3.42 0 00-1.946-.806 3.42 3.42 0 01-3.138-3.138 3.42 3.42 0 00-.806-1.946 3.42 3.42 0 010-4.438 3.42 3.42 0 00.806-1.946 3.42 3.42 0 013.138-3.138z' /%3E%3C/svg%3E"");
  //    }
  //  </style>
  //</head>");
  //              stringBuilder.Append("<body>\n");
  //              stringBuilder.Append("<div class=\"border-pattern\">\n");
  //              stringBuilder.Append(" <div class=\"content\">\n");
  //              stringBuilder.Append("  <div class=\"inner-content\">\n");
  //              stringBuilder.Append("   <h1>Certificate</h1>\n");
  //              stringBuilder.Append("   <h2>of Excellence</h2>\n");
  //              stringBuilder.Append("   <h3>This Certificate Is Proudly Presented To</h3>\n");
  //              stringBuilder.Append("   <p>Jane Doe</p>\n");
  //              stringBuilder.Append("   <h3>Has Completed</h3>\n");
  //              stringBuilder.Append("   <p>PrintCSS Basics Course</p>\n");
  //              stringBuilder.Append("   <h3>On</h3>\n");
  //              stringBuilder.Append("   <p>Feburary 5, 2021</p>\n");
  //              stringBuilder.Append("   <div class=\"badges\">\n");
  //              stringBuilder.Append("   </div>\n");
  //              stringBuilder.Append("  </div>\n");
  //              stringBuilder.Append(" </div>\n");
  //              stringBuilder.Append("</div>\n");
  //              stringBuilder.Append("  </body>\n");
  //              stringBuilder.Append("</html>");
  //              using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(stringBuilder.ToString())))
  //              {
  //                  ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
  //                  PdfWriter writer = new PdfWriter(byteArrayOutputStream);
  //                  PdfDocument pdfDocument = new PdfDocument(writer);
  //                  pdfDocument.SetDefaultPageSize(PageSize.A3);
  //                  HtmlConverter.ConvertToPdf(stream, pdfDocument);
  //                  pdfDocument.Close();
  //                  return File(byteArrayOutputStream.ToArray(), "application/pdf", "AwarnessRate.pdf");
  //              }
  //          }
  //          return RedirectToAction(nameof(Index));
  //      }
        public IActionResult LogOut()
        {
            TempData["ManagerName"] = null;
            HttpContext.Session.Remove("ManagerId");
            return RedirectToAction("Index", "Home");
        }
        private InstituteHomePageDto GetResult(int managerId)
        {
            InstituteHomePageDto instituteHomePageDto = new InstituteHomePageDto();
            instituteHomePageDto.EmployeeResults = new List<EmployeeResultDto>();
            Institute institute = _context.Institutes.FirstOrDefault(e => e.ManagerId == managerId);
            IEnumerable<Employee> employees = _context.Employees.Where(e => e.InstituteId == institute.Id).OrderByDescending(e => e.Id);
            instituteHomePageDto.Name = institute.Name;
            instituteHomePageDto.Code = institute.Code;
            instituteHomePageDto.NumberOfEmployee = employees.Count();
            double totalGrade = 0;
            foreach (var emp in employees)
            {
                var getEmp = _context.FinalResults.FirstOrDefault(e => e.EmployeeId == emp.Id);
                if (getEmp == null)
                    instituteHomePageDto.EmployeeResults?.Add(new EmployeeResultDto { Name = emp.Name, Grade = 0 });
                else
                {
                    instituteHomePageDto.EmployeeResults?.Add(new EmployeeResultDto { Name = emp.Name, Grade = getEmp.Grade });
                    totalGrade += getEmp.Grade;
                }
            }
            double rate = (((double)(totalGrade / instituteHomePageDto.NumberOfEmployee)));
            instituteHomePageDto.AwarenessRate = double.IsNaN(rate)?string.Empty:rate.ToString("F2")+" %";
            return instituteHomePageDto;
        }

    }
}
