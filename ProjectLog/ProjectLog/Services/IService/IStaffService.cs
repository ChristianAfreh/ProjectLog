using ProjectLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Services.IService
{
    public interface IStaffService
    {
        public List<staff> GetAllStaff();
    }
}
