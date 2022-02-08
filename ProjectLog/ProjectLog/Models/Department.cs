using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class Department
    {
        public Department()
        {
            staff = new HashSet<staff>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
