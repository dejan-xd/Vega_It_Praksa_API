using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaITPraksa.Models;

namespace VegaITPraksa.Services
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<TeamMember>> Get();
        Task<TeamMember> Get(int id);
        Task<TeamMember> Create(TeamMember teamMember);
        Task Update(TeamMember teamMember);
        Task Delete(int id);
    }
}
