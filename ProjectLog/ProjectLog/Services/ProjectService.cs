
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLog.Models;
using ProjectLog.Services.IService;
using ProjectLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Project> GetAllProjects()
        {
            var projects = _context.Projects.ToList();
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
    }
}
