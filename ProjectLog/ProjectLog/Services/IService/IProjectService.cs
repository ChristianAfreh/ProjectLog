using ProjectLog.Models;
using System.Collections.Generic;

namespace ProjectLog.Services.IService
{
    public interface IProjectService
    {
        public Project GetProjectById(int Id);

        public List<Project> GetAllProjects();

    }
}
