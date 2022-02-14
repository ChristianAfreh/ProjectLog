using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLog.Models;
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
        public string date { get; set; }

        public SelectList statuses { get; set; }

        public IFormFile Upload{ get; set; }

        public string? Photopath{ get; set; }

        public int ProjectId { get; set; }
        
    }
}
