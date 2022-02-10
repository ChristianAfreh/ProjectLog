using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectLog.Services.IService;
using ProjectLog.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProjectController(IProjectService projectService, IHostingEnvironment hostingEnvironment)
        {
            _projectService = projectService;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ProjectDetails(int id)
        {   
            var result = _projectService.GetProjectById(id);    
            return View(result);
        }

        public IActionResult ProjectList()
        {
            var projects = _projectService.GetAllProjects();
            return View(projects);
        }

        //Adding a project
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProject(AddProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Upload !=null)
                {
                   string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pics");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Upload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Upload.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                _projectService.AddProject(model);
                
                return RedirectToAction("ProjectList");
            }
            return View();
        }

        //public IActionResult DeleteProject(int Id)
        //{

        //}






    }
}
