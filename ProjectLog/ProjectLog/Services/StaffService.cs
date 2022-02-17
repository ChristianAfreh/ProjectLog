using ProjectLog.Models;
using ProjectLog.Services.IService;
using ProjectLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Services
{
    public class StaffService : IStaffService
    {

        private readonly ProjectLogDBContext _context;
        public StaffService(ProjectLogDBContext context)
        {
            _context = context;
        }
        public List<staff> GetAllStaff()
        {
            var result = _context.staff.ToList();
            return result;
        }

        public List<StaffProject> GetSelectedStaff(int projectId)
        {
            var selectedStaff = _context.StaffProjects.Where(x => x.ProjectId == projectId).ToList();
            return selectedStaff;
        }

        public void RemoveStaffUnderProject(int projectId)
        {
            StaffProject staffproject = _context.StaffProjects.Where(x => x.ProjectId == projectId).FirstOrDefault();

            if (staffproject != null)
            {
                _context.StaffProjects.Remove(staffproject);
                _context.SaveChanges();
            }
        }
    }
}
