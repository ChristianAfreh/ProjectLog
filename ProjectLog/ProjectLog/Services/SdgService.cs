using ProjectLog.Models;
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

    }
}
