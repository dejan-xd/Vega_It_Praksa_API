using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VegaITPraksa.Data;
using VegaITPraksa.Models;
using VegaITPraksa.Services;

namespace VegaITPraksa.Repository
{
    public class ProjectRepository : IProjectService
    {

        private readonly DataContext _db;

        public ProjectRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Project> Create(Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();

            return project;
        }

        public async Task Delete(int id)
        {
            var projectToDelete = await _db.Projects.FindAsync(id);
            _db.Projects.Remove(projectToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> Get()
        {
            return await _db.Projects.Include(i => i.Customer).ToListAsync();
            //return await _db.Project.ToListAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await _db.Projects.Include(i => i.Customer).FirstOrDefaultAsync(i => i.ProjectId == id);
            //return await _db.Project.FindAsync(id);
        }

        public async Task Update(Project project)
        {
            _db.Entry(project).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
