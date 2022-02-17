using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class Sdgproject
    {
        public int SdgprojectId { get; set; }
        public int GoalId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Sdg Goal { get; set; }
        public virtual Project Project { get; set; }
    }
}
