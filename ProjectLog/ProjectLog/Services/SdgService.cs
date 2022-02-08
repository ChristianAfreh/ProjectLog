using Microsoft.Data.SqlClient;
using ProjectLog.Models;
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
        public List<Sdg> GetAllSdgs()
        {
            var result = _context.Sdgs.ToList();
            return result;
        }

        public SDGProjectViewModel GetProjectUnderSDG(int id)
        {
            List<Project> project = new List<Project>();
            var result = _context.Sdgprojects.Where(x => x.GoalId == id).ToList();
            var sdg = _context.Sdgs.Find(id);

            foreach (var item in result)
            {

                project.Add(_context.Projects.Find(item.ProjectId));
            }

            SDGProjectViewModel sDGProjectViewModel = new SDGProjectViewModel()
            {
                sdg = sdg,
                project = project
            };

            //var result = _context.Sdgprojects.FromSql(" select SDGProject.ProjectID, Project.Title ,Project.Description,Project.ProjectIDFROM SDGProject join  Projecton SDGProject.ProjectID = Project.ProjectID where SDGProject.GoalID = 2");

            return sDGProjectViewModel;
        }
    }
}
