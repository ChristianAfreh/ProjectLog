using Microsoft.AspNetCore.Hosting;
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
            try
            {
                var projects = _projectService.GetAllProjects();
                return View(projects);
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

        //Adding a project
        [HttpGet]
        public IActionResult AddProject()
        {
            try
            {
                var x = _projectService.GetAllStatus();
                return View(x);
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

                    var project = _projectService.AddProject(model, uniqueFileName);
                    //_projectService.AddImagetoProject(uniqueFileName, project.ProjectId);
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
            try
            {
                ViewBag.projectId = id;
                List<Sdg> sdg = _sdgService.GetAllSdgs();

                var model = new List<AddSDGToProjectViewModel>();

                foreach (var Sdg in sdg)
                {
                    var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                    {
                        SDGId = Sdg.GoalId,
                        SDGName = Sdg.Name,
                        IsSelected = false,
                    };

                    model.Add(addSDGToprojectViewModel);
                }

                return View(model);
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
            try
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
            catch (Exception ex)
            {

                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
          
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

        //UPDATING A PROJECT
        [HttpGet]
        public IActionResult UpdateProject(int projectId)
        {
            try
            {
                var results = _projectService.GetProjectToUpdate(projectId);
                return View(results);
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

        [HttpPost]
        public IActionResult UpdateProject(AddProjectViewModel model, int projectId)
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
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Upload.CopyTo(new FileStream(filePath, FileMode.Create));

                        //_projectService.UpdateImageInProject(uniqueFileName, projectId);
                    }
                    _projectService.UpdateProject(model, uniqueFileName);               
                    
                    return RedirectToAction("UpdateSDGProject", new { projectId = projectId });

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

        //UPDATING AN SDG ON A PROJECT
        [HttpGet]
        public IActionResult UpdateSDGProject(int projectid)
        {
            try
            {
                ViewBag.projectId = projectid;
                List<Sdgproject> sdgProject = _sdgService.GetSelectedSDGs(projectid);
                List<Sdg> sdg = _sdgService.GetAllSdgs();
                var model = new List<AddSDGToProjectViewModel>();

                List<int> selectedGoals = sdgProject
                    .Select
                    (
                       x => x.GoalId
                    ).ToList();

                var otherGoals = sdg.Where(x => !selectedGoals.Contains(x.GoalId)).ToList();

                //var otherGoals = sdg.Where(x => otherGoalIds.Contains(x.GoalId)).ToList();

                foreach (var item in sdgProject)
                {
                    var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                    {
                        SDGId = item.GoalId,
                        SDGName = item.Goal.Name,
                        IsSelected = true,
                    };

                    model.Add(addSDGToprojectViewModel);
                }


                foreach (var item in otherGoals)
                {
                    var addSDGToprojectViewModel = new AddSDGToProjectViewModel
                    {
                        SDGId = item.GoalId,
                        SDGName = item.Name,
                        IsSelected = false,
                    };
                    model.Add(addSDGToprojectViewModel);
                }



                return View(model);
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
        [HttpPost]
        public IActionResult UpdateSDGProject(List<AddSDGToProjectViewModel> model,int projectid)
        {
            try
            {
                var selectedSDGUnderProject = _sdgService.GetSelectedSDGs(projectid);
               List<int> selectedsdg  = selectedSDGUnderProject.Select(x => x.GoalId).ToList();
                var othersdgs = selectedSDGUnderProject.Where(x => !selectedsdg.Contains(x.GoalId)).ToList();
                if (ModelState.IsValid)
                {
                    if (model.Count > 1)
                    {
                        for (int i = 0; i < model.Count; i++)
                        {
                            if (model[i].IsSelected)
                            {
                                _projectService.AddSDGToProject(model[i].SDGId, projectid);
                            }
                            else if (!model[i].IsSelected && selectedSDGUnderProject[i].GoalId == model[i].SDGId && selectedSDGUnderProject[i].ProjectId == projectid)
                            {
                                _sdgService.RemoveProjectUnderSdg(projectid);
                            }
                            else
                            {
                                //do Nothing
                            }
                        }
                        return RedirectToAction("UpdateStaffProject", new { projectId = projectid });

                    }

                    return RedirectToAction("UpdateStaffProject", new { projectId = projectid });
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

        //UPDATING STAFF ON AN SDG
        [HttpGet]
        public IActionResult UpdateStaffProject(int Projectid)
        {
            try
            {
                ViewBag.projectId = Projectid;
                List<staff> _staff = _staffService.GetAllStaff();
                List<StaffProject> sdgStaff = _staffService.GetSelectedStaff(Projectid);

                var model = new List<AddStaffToProjectViewModel>();

                List<int> selectedStaff = sdgStaff
                     .Select
                     (
                        x => x.StaffId
                     ).ToList();

                var otherStaff = _staff.Where(x => !selectedStaff.Contains(x.StaffId)).ToList();

                foreach (var item in sdgStaff)
                {
                    var addStaffToProjectViewModel = new AddStaffToProjectViewModel
                    {
                        StaffId = item.StaffId,
                        Name = item.Staff.FirstName + " " + item.Staff.LastName,
                        IsSelected = true,
                    };

                    model.Add(addStaffToProjectViewModel);
                }

                foreach (var item in otherStaff)
                {
                    var addStaffToProjectViewModel = new AddStaffToProjectViewModel
                    {
                        StaffId = item.StaffId,
                        Name = item.FirstName + " " + item.LastName,
                        IsSelected = false,
                    };

                    model.Add(addStaffToProjectViewModel);
                }

                return View(model);

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
        [HttpPost]
        public IActionResult UpdateStaffProject(List<AddStaffToProjectViewModel> model, int Projectid)
        {

            try
            {
                var selectedStaffUnderProject = _staffService.GetSelectedStaff(Projectid);
                if (ModelState.IsValid)
                {   if(model.Count > 1)
                    {
                        for (int i = 0; i < model.Count; i++)
                        {
                            if (model[i].IsSelected)
                            {
                                _projectService.AddStaffToProject(model[i].StaffId, Projectid);
                            }
                            else if (!model[i].IsSelected && selectedStaffUnderProject[i].StaffId == model[i].StaffId && selectedStaffUnderProject[i].ProjectId == Projectid)
                            {
                                _sdgService.RemoveProjectUnderSdg(Projectid);
                            }
                            else
                            {
                                //do Nothing
                            }
                        }
                        return RedirectToAction("ProjectList");
                    }
                    return RedirectToAction("ProjectList");
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

        public IActionResult DeleteProject(int Id)
        {
            try
            {
                _projectService.DeleteProject(Id);
                return RedirectToAction("ProjectList");
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
    }
}


