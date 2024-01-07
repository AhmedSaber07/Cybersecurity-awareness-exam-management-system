using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/NotFound")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
