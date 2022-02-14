﻿
using ProjectLog.Models;
using ProjectLog.ViewModel;
using System.Collections.Generic;

namespace ProjectLog.Services.IService
{
    public interface IProjectService
    {
        public Project GetProjectById(int Id);

        public AllProjectViewModel GetAllProjects();

        public Project AddProject(AddProjectViewModel model);

        public AddProjectViewModel GetAllStatus();

        public string AddImagetoProject(string filename, int projectId);

        public void AddSDGToProject(int SDGID, int projectId);
        public void AddStaffToProject(int StaffId, int projectId);
        public void DeleteProject(int Id);
    }
}
