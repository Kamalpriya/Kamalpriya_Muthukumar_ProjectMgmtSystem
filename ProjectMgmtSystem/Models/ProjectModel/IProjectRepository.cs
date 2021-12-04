using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    public interface IProjectRepository
    {
        public Project CreateProject(Project Project);
        public Project UpdateProject(int id, Project Project);
        public List<Project> GetAllProjects();
        public Project GetProjectById(int id);
        public string DeleteProject(int id);
    }
}
