using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class staff
    {
        public staff()
        {
            StaffProjects = new HashSet<StaffProject>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<StaffProject> StaffProjects { get; set; }
    }
}
