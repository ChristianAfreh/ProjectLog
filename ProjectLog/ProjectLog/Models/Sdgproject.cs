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

        public virtual Sdg Goal { get; set; }
        public virtual Project Project { get; set; }
    }
}
