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
    public class RolesController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            var role = await _roleService.Get();
            var mapperRole = _mapper.Map<RoleDTO[]>(role);

            return mapperRole;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            return await _roleService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole([FromBody] Role role)
        {
            var newRole = await _roleService.Create(role);
            return CreatedAtAction(nameof(GetRole), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut]
        public async Task<ActionResult> PutNewRole(int id, [FromBody] Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            await _roleService.Update(role);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var roleToDelete = await _roleService.Get(id);
            if (roleToDelete == null)
                return NotFound();

            await _roleService.Delete(roleToDelete.RoleId);
            return NoContent();
        }
    }
}
