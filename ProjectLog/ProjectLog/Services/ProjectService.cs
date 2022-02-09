using Microsoft.EntityFrameworkCore;
using ProjectLog.Models;
using ProjectLog.Services.IService;
using ProjectLog.ViewModel;
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

        public List<Project> GetAllProjects()
        {
            var projects = _context.Projects.Include(x => x.Status).ToList();
            return projects;
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
