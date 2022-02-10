using ProjectLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.ViewModel
{
    public class SDGProjectViewModel
    {
        public Sdg sdg { get; set; }

        public List<Project> project { get; set; }
    }
}
