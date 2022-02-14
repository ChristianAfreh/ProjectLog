
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
            var photostring = new ProjectPhoto
            {
                PhotoPath = filename,
                ProjectId = projectId
            };
             _context.ProjectPhotos.Add(photostring);
             _context.SaveChanges();
            return "Added";
        }

        public Project AddProject(AddProjectViewModel model)
        {
            Project project = new Project()
            {
                Title = model.Title,
                Description = model.Description,
                ProjectManager = model.ProjectManager,
                CreatedOn = DateTime.Now,
                StatusId = model.Status



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
                    ProjectId = projectId
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
                    CreatedOn = DateTime.Now
                };

                _context.StaffProjects.Add(staffproject);
                _context.SaveChanges();
            }

        }

        public void DeleteProject(int Id)
        {
            Project projectToDelete = _context.Projects.Include(x => x.Status)
                 .Include(x => x.Sdgprojects)
                 .Include(x => x.ProjectPhotos)
                 .Include(x => x.StaffProjects)
                .Where(c => c.ProjectId == Id).FirstOrDefault();
            if (projectToDelete != null)
            {
                foreach (var Sdgproject in projectToDelete.Sdgprojects)
                {
                    _context.Remove(Sdgproject);
                }

                foreach (var projectPhoto in projectToDelete.ProjectPhotos)
                {
                    _context.Remove(projectPhoto);
                }
                foreach (var staffProject in projectToDelete.StaffProjects)
                {
                    _context.Remove(staffProject);
                }


                _context.Projects.Remove(projectToDelete);
                 _context.SaveChanges();
            }

            
            
        }

       /* public AllProjectViewModel GetAllProjects()
        {
            var projects = _context.Projects.Include(x => x.Status).ToList();

            AllProjectViewModel allProjectViewModel = new AllProjectViewModel();
            
            if (projects.Count() != 0)
            {

                allProjectViewModel.AllProject = projects.Select(x => new ProjectViewModel()
                {
                    ProjectId = x.ProjectId,
                    Title = x.Title,
                    ProjectManager = x.ProjectManager,
                    CreatedOn = x.CreatedOn,
                    StatusName = x.Status.Name,
                }).ToList();
            }

            return allProjectViewModel;

        }*/

        public List<Project> GetAllProjects()
        {
            var projects = _context.Projects.Include(x => x.Status).ToList();

            return projects;
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
            var project = _context.Projects.Include(x => x.ProjectPhotos).FirstOrDefault(x => x.ProjectId == projectId);
            var defaultPhotoPath = "1.png";

            if (project.ProjectPhotos == null)
            {
                var projectDetails = new AddProjectViewModel()
                {
                    Title = project.Title,
                    Description = project.Description,
                    ProjectManager = project.ProjectManager,
                    Status = project.StatusId,
                    Photopath = defaultPhotoPath,
                    statuses = new SelectList(_context.Statuses.Select(s => new { Id = s.StatusId, Text = $"{s.Name}" }), "Id", "Text"),
                    ProjectId = projectId
                };
                return projectDetails;

            }
            else
            {
                var projectDetails = new AddProjectViewModel()
                {
                    Title = project.Title,
                    Description = project.Description,
                    ProjectManager = project.ProjectManager,
                    Status = project.StatusId,
                    Photopath = project.ProjectPhotos.FirstOrDefault().PhotoPath,
                    statuses = new SelectList(_context.Statuses.Select(s => new { Id = s.StatusId, Text = $"{s.Name}" }), "Id", "Text"),
                    ProjectId = projectId
                };
                return projectDetails;

            }

        }

       

        public void UpdateProject(AddProjectViewModel model)
        {
            Project project = _context.Projects.FirstOrDefault(e => e.ProjectId == model.ProjectId);

            if( project!= null)
            {
                project.Title = model.Title;
                project.Description = model.Description;
                project.ProjectManager = model.ProjectManager;
                project.StatusId = model.Status;
                project.UpdatedOn = DateTime.Now;
            };
           
            _context.Projects.Update(project);
            _context.SaveChanges();
            
        }

        
    }
}
