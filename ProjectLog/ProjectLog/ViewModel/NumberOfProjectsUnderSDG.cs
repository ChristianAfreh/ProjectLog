using ProjectLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.ViewModel
{
    public class NumberOfProjectsUnderSDG
    {
      public  List<Sdg> _Sdg { get; set; }
      public  List<int> numberUnderSdg { get; set; }
    }
}
