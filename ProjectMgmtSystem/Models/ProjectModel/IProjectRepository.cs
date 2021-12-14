using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    // 1. Repository interface for Project (Sprint II)
    public interface IProjectRepository
    {
        public Task<Project> CreateProjectAsync(Project project);
        public Task<Project> UpdateProjectAsync(int id, Project project);
        public Task<List<Project>> GetAllProjectsAsync();
        public Task<Project> GetProjectByIdAsync(int id);
        public Task<Project> DeleteProjectAsync(int id);
    }
}
