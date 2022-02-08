using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class Status
    {
        public Status()
        {
            Projects = new HashSet<Project>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
