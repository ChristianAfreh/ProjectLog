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
    }
}
