using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class StaffProject
    {
        public int StaffProjectId { get; set; }
        public int ProjectId { get; set; }
        public int StaffId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Project Project { get; set; }
        public virtual staff Staff { get; set; }
    }
}
