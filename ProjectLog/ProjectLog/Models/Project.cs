using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class Project
    {
        public Project()
        {
            Sdgprojects = new HashSet<Sdgproject>();
            StaffProjects = new HashSet<StaffProject>();
        }

        public int ProjectId { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectManager { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string ProjectStartDate { get; set; }
        public string UpdatedBy { get; set; }
        public string PhotoName { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Sdgproject> Sdgprojects { get; set; }
        public virtual ICollection<StaffProject> StaffProjects { get; set; }
    }
}
