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
    public class TeamMemberRepository : ITeamMemberService
    {

        private readonly DataContext _db;

        public TeamMemberRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<TeamMember> Create(TeamMember teamMember)
        {
            _db.TeamMembers.Add(teamMember);
            await _db.SaveChangesAsync();

            return teamMember;
        }

        public async Task Delete(int id)
        {
            var teamMemberToDelete = await _db.TeamMembers.FindAsync(id);
            _db.TeamMembers.Remove(teamMemberToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeamMember>> Get()
        {
            return await _db.TeamMembers.ToListAsync();
        }

        public async Task<TeamMember> Get(int id)
        {
            return await _db.TeamMembers.FindAsync(id);
        }

        public async Task Update(TeamMember teamMember)
        {
            _db.Entry(teamMember).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
