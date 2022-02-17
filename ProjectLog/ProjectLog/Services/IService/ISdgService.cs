
using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;

namespace ProjectLog.Services
{
    public interface ISdgService
    {
        public List<Sdg> GetAllSdgs();
        public NumberOfProjectsUnderSDG GetTotalNumberOfProjectUnderSdg();

        public SDGProjectViewModel GetProjectUnderSDG(int id);

        public List<Sdgproject> GetSelectedSDGs(int projectId);

        public void RemoveProjectUnderSdg(int projectId);
    }
}
