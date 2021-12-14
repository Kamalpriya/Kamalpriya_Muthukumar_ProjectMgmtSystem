using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    // 2b. Project service with CRUD api implementations (Sprint I)

    // 1. Implementation of project repository interface (Sprint II)
    public class ProjectService : IProjectRepository
    {
        private readonly AppDBContext _context;

        public ProjectService(AppDBContext context)
        {
            _context = context;
        }

        async Task<Project> IProjectRepository.CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        async Task<Project> IProjectRepository.DeleteProjectAsync(int id)
        {
            var result = _context.Projects.FirstOrDefault(Project => Project.Id == id);
            _context.Projects.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        async Task<List<Project>> IProjectRepository.GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        async Task<Project> IProjectRepository.GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(Project => Project.Id == id);
        }

        async Task<Project> IProjectRepository.UpdateProjectAsync(int id, Project inpProject)
        {
            var result = _context.Projects.FirstOrDefault(Project => Project.Id == id);
            _context.Projects.Remove(result);
            _context.Projects.Add(inpProject);
            await _context.SaveChangesAsync();
            return inpProject;
        }
    }
}
