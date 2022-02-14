using System;
using System.Collections.Generic;

namespace ProjectLog.ViewModel
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string ProjectManager { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class AllProjectViewModel
    {
        public List<ProjectViewModel> AllProject { get; set; }
    }
}
