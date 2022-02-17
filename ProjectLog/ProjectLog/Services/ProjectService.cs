
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLog.Models;
using ProjectLog.Services.IService;
using ProjectLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectLogDBContext _context;
        public ProjectService(ProjectLogDBContext context)
        {
            _context = context;
        }

        public string AddImagetoProject(string filename, int projectId)
        {
            //var photostring = new ProjectPhoto
            //{
            //    PhotoPath = filename,
            //    ProjectId = projectId
            //};
            // _context.ProjectPhotos.Add(photostring);
            // _context.SaveChanges();
            return "Added";
        }

        public Project AddProject(AddProjectViewModel model, string imageName)
        {
            Project project = new Project()
            {
                Title = model.Title,
                Description = model.Description,
                ProjectManager = model.ProjectManager,
                CreatedOn = DateTime.Now,
                StatusId = model.Status,
                CreatedBy = "Admin",
                IsDeleted = false,
                ProjectStartDate = model.date,
                PhotoName = imageName,


            };

            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public void AddSDGToProject(int SDGID, int projectId)
        {

            if (_context.Sdgprojects.Where(x => x.GoalId == SDGID && x.ProjectId == projectId).Any())
            {

            }
            else
            {
                Sdgproject sdgproject = new Sdgproject()
                {
                    GoalId = SDGID,
                    ProjectId = projectId,
                    CreatedOn =DateTime.Now,
                    CreatedBy = "Admin"
                };

                _context.Sdgprojects.Add(sdgproject);
                _context.SaveChanges();
            }

        }

        public void AddStaffToProject(int StaffId, int projectId)
        {


            if (_context.StaffProjects.Where(x => x.StaffId == StaffId && x.ProjectId == projectId).Any())
            {

            }
            else
            {
                StaffProject staffproject = new StaffProject()
                {
                    StaffId = StaffId,
                    ProjectId = projectId,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "Admin"
                };

                _context.StaffProjects.Add(staffproject);
                _context.SaveChanges();
            }

        }

        //Delete Project
        public void DeleteProject(int Id)
        {
            Project project = _context.Projects.Include(x=>x.Sdgprojects)
                .Include(x=>x.StaffProjects).Where(x => x.ProjectId == Id).FirstOrDefault();

            if(project != null)
            {
                project.IsDeleted = true;
                project.UpdatedBy = "UserAdmin";
                project.UpdatedOn = DateTime.Now;

                foreach (var Sdgproject in project.Sdgprojects)
               {
                   _context.Remove(Sdgproject);
                }

                foreach (var staffProject in project.StaffProjects)
                {
                    _context.Remove(staffProject);
                }
            }
            else
            {
                //do nothing
            }
            _context.Projects.Update(project);
            _context.SaveChanges();
            //Project projectToDelete = _context.Projects.Include(x => x.Status)
            //     .Include(x => x.Sdgprojects)
            //     .Include(x => x.ProjectPhotos)
            //     .Include(x => x.StaffProjects)
            //    .Where(c => c.ProjectId == Id).FirstOrDefault();
            //if (projectToDelete != null)
            //{
            //    foreach (var Sdgproject in projectToDelete.Sdgprojects)
            //    {
            //        _context.Remove(Sdgproject);
            //    }

            //    foreach (var projectPhoto in projectToDelete.ProjectPhotos)
            //    {
            //        _context.Remove(projectPhoto);
            //    }
            //    foreach (var staffProject in projectToDelete.StaffProjects)
            //    {
            //        _context.Remove(staffProject);
            //    }


            //    _context.Projects.Remove(projectToDelete);
            //     _context.SaveChanges();
            //}

            
            
        }

        public List<ProjectViewModel> GetAllProjects()
        {
            var projects = _context.Projects.Include(x => x.Status).Where(x=>x.IsDeleted == false).ToList();
           
            var defaultPhotoPath = "noImage.png";
            List<ProjectViewModel> allProjectViewModel = new List<ProjectViewModel>();

            if (projects.Count() != 0)
            {
                for (int i = 0; i < projects.Count(); i++)
                {
                    if (projects[i].PhotoName == null )
                    {
                        var projectViewModel = new ProjectViewModel()
                        {
                            ProjectId = projects[i].ProjectId,
                            ProjectManager = projects[i].ProjectManager,
                            Title = projects[i].Title,
                            CreatedOn = projects[i].CreatedOn,
                            StatusName = projects[i].Status.Name,
                            PhotoPath = defaultPhotoPath

                        };

                        allProjectViewModel.Add(projectViewModel);
                    }
                    else
                    {
                        var projectViewModel = new ProjectViewModel()
                        {
                            ProjectId = projects[i].ProjectId,
                            ProjectManager = projects[i].ProjectManager,
                            Title = projects[i].Title,
                            CreatedOn = projects[i].CreatedOn,
                            StatusName = projects[i].Status.Name,
                            PhotoPath = projects[i].PhotoName
                        };

                        allProjectViewModel.Add(projectViewModel);
                    }
                }
                /* allProjectViewModel.AllProject = projects.Select(x => new ProjectViewModel()
                 {
                     ProjectId = x.ProjectId,
                     Title = x.Title,
                     ProjectManager = x.ProjectManager,
                     CreatedOn = x.CreatedOn,
                     StatusName = x.Status.Name,
                     //PhotoPath = x.ProjectPhotos.FirstOrDefault().PhotoPath
                 }).ToList();*/

                }

                return allProjectViewModel;

        }

        public AddProjectViewModel GetAllStatus()
        {
            var x = new AddProjectViewModel()
            {
                statuses = new SelectList(_context.Statuses.Select(s => new { Id = s.StatusId, Text = $"{s.Name}" }), "Id", "Text"),

            };

            return x;
        }

        public Project GetProjectById(int Id)
        {
            var project = _context.Projects.Find(Id);
            var projectDetails = new Project()
            {
                Title = project.Title,
                Description = project.Description,
                ProjectManager = project.ProjectManager,
                CreatedOn = project.CreatedOn,
                UpdatedOn = project.UpdatedOn,

            };
            return projectDetails;
        }

        public AddProjectViewModel GetProjectToUpdate(int projectId)
        {
            //var project = _context.Projects.Include(x=>x.ProjectPhotos).SingleOrDefalut(x=> x.ProjectId == projectId);
            /*var project = _context.Projects.Include(x=>x.ProjectPhotos).FirstOrDefault(x=> x.ProjectId == projectId);*/
            var project = _context.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault();

            //var defaultPhotoPath = "noImage.png";

            AddProjectViewModel projectDetails = new AddProjectViewModel();

            if (project != null)
            {


                projectDetails = new AddProjectViewModel()
                {
                    Title = project.Title,
                    Description = project.Description,
                    ProjectManager = project.ProjectManager,
                    Status = project.StatusId,
                    Photopath = project.PhotoName,
                    statuses = new SelectList(_context.Statuses.Select(s => new { Id = s.StatusId, Text = $"{s.Name}" }), "Id", "Text"),
                    ProjectId = projectId
                };
                return projectDetails;

            }
           

            return projectDetails;

        }

        public void UpdateImageInProject(string filename, int projectId)
        {
            //ProjectPhoto projectPhoto = _context.ProjectPhotos.FirstOrDefault(e => e.ProjectId == projectId);
            //if( projectPhoto != null)
            //{
            //    projectPhoto.ProjectId = projectId;
            //    projectPhoto.PhotoPath = filename;
               
            //}


            //_context.ProjectPhotos.Update(projectPhoto);
            //_context.SaveChanges();


        }

        public void UpdateProject(AddProjectViewModel model, string ImageName)
        {
            Project project = _context.Projects.FirstOrDefault(e => e.ProjectId == model.ProjectId);

            if( project!= null)
            {
                project.Title = model.Title;
                project.Description = model.Description;
                project.ProjectManager = model.ProjectManager;
                project.StatusId = model.Status;
                project.UpdatedOn = DateTime.Now;
                project.UpdatedBy = "Admin";
                project.IsDeleted = false;
                if (model.Photopath != null && model.Upload.FileName == null)
                {
                    project.PhotoName = model.Photopath ;
                }
                else
                {
                    project.PhotoName = ImageName;
                }
               
            };
           
            _context.Projects.Update(project);
            _context.SaveChanges();
            
        }

        
    }
}
