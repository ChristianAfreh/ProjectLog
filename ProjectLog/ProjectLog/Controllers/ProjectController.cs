using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult ProjectDetails(int id)
        {
            return View();
        }
        public IActionResult AddProject()
        {
            return View();
        }
    }
}
