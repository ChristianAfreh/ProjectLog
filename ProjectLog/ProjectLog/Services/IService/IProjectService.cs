
using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectLog.Services.IService
{
    public interface IProjectService
    {
        public Project GetProjectById(int Id);

        public List<Project> GetAllProjects();

        public Project AddProject(AddProjectViewModel model);

        public AddProjectViewModel GetAllStatus();

        public  string AddImagetoProject(string filename, int projectId);

        public void AddSDGToProject(int SDGID, int projectId);
        public void AddStaffToProject(int StaffId, int projectId);

        public AddProjectViewModel GetProjectToUpdate(int projectId);

        public void UpdateProject(AddProjectViewModel model);

        public void UpdateImageInProject(string filename, int projectId);
    }
}
