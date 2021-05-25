using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegaITPraksa.DTO;
using VegaITPraksa.Models;
using VegaITPraksa.Services;

namespace VegaITPraksa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {

        private readonly ITeamMemberService _teamMemberService;
        private readonly IMapper _mapper;


        public TeamMembersController(ITeamMemberService teamMemberService, IMapper mapper)
        {
            _teamMemberService = teamMemberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamMemberDTO>> GetAllTeamMembers()
        {
            var teamMember = await _teamMemberService.Get();
            var mapperTeamMember = _mapper.Map<TeamMemberDTO[]>(teamMember);

            return mapperTeamMember;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMemberDTO>> GetTeamMember(int id)
        {
            var teamMember = await _teamMemberService.Get(id);
            var mapperTeamMemberId = _mapper.Map<TeamMemberDTO>(teamMember);

            return mapperTeamMemberId;
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
