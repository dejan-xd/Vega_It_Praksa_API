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

            //return await _teamMemberService.Get();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMemberDTO>> GetTeamMember(int id)
        {
            var teamMember = await _teamMemberService.Get(id);
            var mapperTeamMemberId = _mapper.Map<TeamMemberDTO>(teamMember);
            return mapperTeamMemberId;

            //return await _teamMemberService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<TeamMemberDTO>> PostTeamMember(TeamMemberDTO teamMemberDto)
        {
            var mapperTeamMember = _mapper.Map<TeamMember>(teamMemberDto);
            var newTeamMember = await _teamMemberService.Create(mapperTeamMember);

            return CreatedAtAction(nameof(GetTeamMember), new { id = newTeamMember.TeamMemberId }, newTeamMember);
        }

        [HttpPut]
        public async Task<ActionResult> PutTeamMember(int id, TeamMemberDTO teamMemberDto)
        {
            if (id != teamMemberDto.TeamMemberId)
            {
                return BadRequest();
            }

            var mapperTeamMember = _mapper.Map<TeamMember>(teamMemberDto);

            await _teamMemberService.Update(mapperTeamMember);

            return NoContent();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTeamMember(int id)
        {
            var teamMemberToDelete = await _teamMemberService.Get(id);
            if (teamMemberToDelete == null)
                return NotFound();

            await _teamMemberService.Delete(teamMemberToDelete.TeamMemberId);
            return NoContent();
        }

    }
}
