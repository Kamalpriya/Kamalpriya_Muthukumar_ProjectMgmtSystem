using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    // 2b. Project service with CRUD api implementations
    public class ProjectService : IProjectRepository
    {
        private static List<Project> Projects;
        private static int cnt = 4;

        public ProjectService()
        {
            Projects = new List<Project>()
            {
                new Project(){Id=1, Name="TestProject1", Detail="This is a test project", CreatedOn=DateTime.Now},
                new Project(){Id=2, Name="TestProject2", Detail="This is a test project", CreatedOn=DateTime.Now},
                new Project(){Id=3, Name="TestProject3", Detail="This is a test project", CreatedOn=DateTime.Now},
                new Project(){Id=4, Name="TestProject4", Detail="This is a test project", CreatedOn=DateTime.Now}
            };
        }
        public Project CreateProject(Project project)
        {
            project.Id = ++cnt;
            Projects.Add(project);
            return project;
        }

        public string DeleteProject(int id)
        {
            Project Project = GetProjectById(id);
            Projects.Remove(Project);
            cnt--;
            return "Project deleted";
        }

        public List<Project> GetAllProjects()
        {
            return Projects;
        }

        public Project GetProjectById(int id)
        {
            foreach (var Project in Projects)
            {
                if(Project.Id == id)
                {
                    return Project;
                }
            }
            return null;
        }

        public Project UpdateProject(int id, Project inpProject)
        {
            Project project = GetProjectById(id);
            Projects.Remove(project);  
            Projects.Add(inpProject);  
            return GetProjectById(inpProject.Id);
        }
    }
}
