using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;

namespace ProjectLog.Services.IService
{
    public interface IProjectService
    {
        public Project GetProjectById(int Id);

        public List<Project> GetAllProjects();

        public Project AddProject(AddProjectViewModel model);

        public Project DeleteProject(int ProjectId);



    }
}
