﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectLog.Models;
using ProjectLog.Services;
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
        private readonly ISdgService _sdgService;
        private readonly IStaffService _staffService;

        public ProjectController(IProjectService projectService, 
            IHostingEnvironment hostingEnvironment, ISdgService sdgService,
            IStaffService staffService)
        {
            _projectService = projectService;
            this.hostingEnvironment = hostingEnvironment;
            _sdgService = sdgService;
            _staffService = staffService;
        }
        public IActionResult ProjectDetails(int id)
        {
            try
            {
                var result = _projectService.GetProjectById(id);
                return View(result);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
            
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
             var x = _projectService.GetAllStatus();
            return View(x);
        }

        [HttpPost]
        public IActionResult AddProject(AddProjectViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = null;
                    if (model.Upload != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pics");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Upload.FileName;
                        string filePath =  Path.Combine(uploadsFolder, uniqueFileName);
                        model.Upload.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    var project = _projectService.AddProject(model);
                    _projectService.AddImagetoProject(uniqueFileName, project.ProjectId);
                    return RedirectToAction("AddSDG", new { project.ProjectId });
                }
                return View();
            }
            catch ( Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
          
        }

        //ADDING AN SDG TO A PROJECT
        [HttpGet]
        public IActionResult AddSDG(int id)
        {
            ViewBag.projectId = id;
             List<Sdg> sdg = _sdgService.GetAllSdgs();
           
            var model = new List<AddSDGToProjectViewModel>();

            foreach(var Sdg in sdg)
            {
                var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                {
                    SDGId=Sdg.GoalId,
                    SDGName= Sdg.Name,
                    IsSelected =false,
                };

                model.Add(addSDGToprojectViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddSDG(List<AddSDGToProjectViewModel> model , int Projectid)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        if (model[i].IsSelected)
                        {
                            _projectService.AddSDGToProject(model[i].SDGId, Projectid);
                        }
                        else
                        {
                            //do Nothing
                        }
                    }
                    return RedirectToAction("AddStaff", new { id = Projectid });
                }

                return View();
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }

            
        }

        //ADDING A STAFF TO A PROJECT
        [HttpGet]
        public IActionResult AddStaff(int id)
        {
            ViewBag.projectId = id;
            List<staff> _staff = _staffService.GetAllStaff();

            var model = new List<AddStaffToProjectViewModel>();

            foreach (var item in _staff)
            {
                var addStaffToprojectViewModel = new AddStaffToProjectViewModel
                {
                    StaffId = item.StaffId,
                    Name = item.FirstName + " " + item.LastName,
                    IsSelected = false,
                };

                model.Add(addStaffToprojectViewModel);
            }

            return View(model);
            
        }


        [HttpPost]
        public IActionResult AddStaff(List<AddStaffToProjectViewModel> model,int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        if (model[i].IsSelected)
                        {
                            _projectService.AddStaffToProject(model[i].StaffId, id);
                        }
                        else
                        {
                            //do Nothing
                        }
                    }
                    return RedirectToAction("ProjectList");
                }

                return View();
            }
            catch ( Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
            

        }

        [HttpGet]
        public IActionResult UpdateProject(int projectId)
        {
            var results = _projectService.GetProjectToUpdate(projectId);
            return View(results);
        }

        [HttpPost]
        public IActionResult UpdateProject(AddProjectViewModel model, int projectId)
        {
            _projectService.UpdateProject(model);
            
            return RedirectToAction("UpdateSDGProject", new {projectId = projectId });
        }


        [HttpGet]

        public IActionResult UpdateSDGProject(int projectid)
        {
            ViewBag.projectId = projectid;
            List<Sdgproject> sdgProject = _sdgService.GetSelectedSDGs(projectid);
            List<Sdg> sdg = _sdgService.GetAllSdgs();
            var model = new List<AddSDGToProjectViewModel>();

            for (int i = 0; i < sdg.Count; i++)
            {
                if(sdg[i].GoalId == sdgProject[0].GoalId)
                {
                    var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                    {
                        SDGId = sdg[i].GoalId,
                        SDGName = sdg[i].Name,
                        IsSelected = true,
                    };

                    model.Add(addSDGToprojectViewModel);
                }
                else
                {
                    var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                    {
                        SDGId = sdg[i].GoalId,
                        SDGName = sdg[i].Name,
                        IsSelected = false,
                    };

                    model.Add(addSDGToprojectViewModel);
                }
            }
            /*
                        foreach (var Sdg in sdgProject)
                        {
                            var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                            {
                                SDGId = Sdg.GoalId,
                                SDGName = Sdg.Name,
                                IsSelected = false,
                            };

                            model.Add(addSDGToprojectViewModel);
                        }*/

            return View(model);
        }
    }
}
