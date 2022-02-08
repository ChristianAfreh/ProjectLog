using ProjectLog.Models;
using System.Collections.Generic;

namespace ProjectLog.Services
{
    public interface ISdgService
    {
        public List<Sdg> GetAllSdgs();

        public List<Project> GetProjectUnderSDG(int id);
    }
}
