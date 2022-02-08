using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;

namespace ProjectLog.Services
{
    public interface ISdgService
    {
        public List<Sdg> GetAllSdgs();

        public SDGProjectViewModel GetProjectUnderSDG(int id);
    }
}
