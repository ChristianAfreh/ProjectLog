using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectLog.Models;
//using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectLog.Services
{
    public class SdgService : ISdgService
    {
        private readonly ProjectLogDBContext _context;
        public SdgService(ProjectLogDBContext context)
        {
            _context = context;
        }


        public NumberOfProjectsUnderSDG GetTotalNumberOfProjectUnderSdg()
        {

            var result = _context.Sdgs.ToList();
            List<int> number = new List<int>();
            for (int i = 0; i < result.Count; i++)
            {
                number.Add(_context.Sdgprojects.Where(x => x.GoalId == i + 1).Count());
            }

            NumberOfProjectsUnderSDG numberOfProjectsUnderSDG = new NumberOfProjectsUnderSDG()
            {
                _Sdg=result,
                numberUnderSdg =number
            };
          
           
            return numberOfProjectsUnderSDG;
        }

        public SDGProjectViewModel GetProjectUnderSDG(int id)
        {
            List<Project> project = new List<Project>();
            var result = _context.Sdgprojects.Where(x => x.GoalId == id).ToList();
            var sdg = _context.Sdgs.Find(id);

            List<int> number = new List<int>();
            

            foreach (var item in result)
            {
                number.Add(_context.StaffProjects.Where(x => x.ProjectId == item.ProjectId).Count());
                project.Add(_context.Projects.Find(item.ProjectId));
              
            }

            SDGProjectViewModel sDGProjectViewModel = new SDGProjectViewModel()
            {
                sdg = sdg,
                project = project,
                NumberOfStaff =number
            };

            return sDGProjectViewModel;
        }

        public List<Sdg> GetAllSdgs()
        {
            var result = _context.Sdgs.ToList();
            return result;
        }

        public List<Sdgproject> GetSelectedSDGs(int projectId)
        {
            var selectedSdg = _context.Sdgprojects.Where(x => x.ProjectId == projectId).ToList();
            return selectedSdg;
        }
    }
}
