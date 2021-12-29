﻿using Microsoft.EntityFrameworkCore;
using PMS.ApplicationDomainLayer.ProjectModel;
using PMS.DataAccessLayer;
using PMS.PersistenceLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.PersistenceLayer.Service
{
    public class ProjectService : IGenericRepository<Project>
    {
        private readonly AppDBContext _context;

        public ProjectService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var result = _context.Projects.FirstOrDefault(Project => Project.Id == id);
            _context.Projects.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(Project => Project.Id == id);
        }

        public async Task<Project> UpdateAsync(int id, Project inpProject)
        {
            var result = _context.Projects.FirstOrDefault(Project => Project.Id == id);
            _context.Projects.Remove(result);
            _context.Projects.Add(inpProject);
            await _context.SaveChangesAsync();
            return inpProject;
        }
    }
}
