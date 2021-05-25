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
    public class RoleRepository : IRoleService
    {

        private readonly DataContext _db;

        public RoleRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Role> Create(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();

            return role;
        }

        public async Task Delete(int id)
        {
            var roleToDelete = await _db.Roles.FindAsync(id);
            _db.Roles.Remove(roleToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _db.Roles.Include(i => i.TeamMembers).ToListAsync();
            //return await _db.Roles.ToListAsync();
        }

        public async Task<Role> Get(int id)
        {
            return await _db.Roles.Include(i => i.TeamMembers).FirstOrDefaultAsync(i => i.RoleId == id);
            //return await _db.Roles.FindAsync(id);
        }

        public async Task Update(Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
