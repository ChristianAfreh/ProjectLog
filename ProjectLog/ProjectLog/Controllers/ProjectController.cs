using Microsoft.AspNetCore.Mvc;
using ProjectLog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;   
        }
        public IActionResult ProjectDetails(int id)
        {   
            var result = _projectService.GetProjectById(id);    
            return View(result);
        }
        public IActionResult AddProject()
        {
            return View();
        }
    }
}
