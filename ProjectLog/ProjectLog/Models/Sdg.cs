using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class Sdg
    {
        public Sdg()
        {
            Sdgprojects = new HashSet<Sdgproject>();
        }

        public int GoalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sdgproject> Sdgprojects { get; set; }
    }
}
