using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.ViewModel
{
    public class AddProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string ProjectManager { get; set; }

        public int Status { get; set; }

        public IFormFile Upload{ get; set; }
    }
}
