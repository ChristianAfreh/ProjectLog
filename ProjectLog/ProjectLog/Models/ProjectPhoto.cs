using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectLog.Models
{
    public partial class ProjectPhoto
    {
        public string PhotoPath { get; set; }
        public int ProjectId { get; set; }
        public int ProjectPhotoId { get; set; }

        public virtual Project Project { get; set; }
    }
}
