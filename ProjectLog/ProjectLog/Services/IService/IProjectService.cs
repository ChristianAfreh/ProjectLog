
using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectLog.Services.IService
{
    public interface IProjectService
    {
        public Project GetProjectById(int Id);

        public List<ProjectViewModel>  GetAllProjects();

        public Project AddProject(AddProjectViewModel model, string imageName);

        public AddProjectViewModel GetAllStatus();

        public  string AddImagetoProject(string filename, int projectId);

        public void AddSDGToProject(int SDGID, int projectId);
        public void AddStaffToProject(int StaffId, int projectId);

        public AddProjectViewModel GetProjectToUpdate(int projectId);

        public void UpdateProject(AddProjectViewModel model, string ImageName);

        public void UpdateImageInProject(string filename, int projectId);
        public void DeleteProject(int Id);
    }
}
