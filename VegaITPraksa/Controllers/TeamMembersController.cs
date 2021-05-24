using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegaITPraksa.Models;
using VegaITPraksa.Services;

namespace VegaITPraksa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {

        private readonly ITeamMemberService _teamMemberService;

        public TeamMembersController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamMember>> GetAllTeamMembers()
        {
            return await _teamMemberService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        {
            return await _teamMemberService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember([FromBody] TeamMember teamMember)
        {
            var newTeamMember = await _teamMemberService.Create(teamMember);
            return CreatedAtAction(nameof(GetTeamMember), new { id = newTeamMember.TeamMemberId }, newTeamMember);
        }

        [HttpPut]
        public async Task<ActionResult> PutNewTeamMember(int id, [FromBody] TeamMember teamMember)
        {
            if(id != teamMember.TeamMemberId)
            {
                return BadRequest();
            }

            await _teamMemberService.Update(teamMember);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTeamMember (int id)
        {
            var teamMemberToDelete = await _teamMemberService.Get(id);
            if (teamMemberToDelete == null)
                return NotFound();

            await _teamMemberService.Delete(teamMemberToDelete.TeamMemberId);
            return NoContent();


        }

    }
}
