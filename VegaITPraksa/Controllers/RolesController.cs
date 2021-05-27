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
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _roleService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            return await _roleService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> PostRole(RoleDTO roleDto)
        {
            var mapperRole = _mapper.Map<Role>(roleDto);
            var newRole = await _roleService.Create(mapperRole);

            return CreatedAtAction(nameof(GetRole), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut]
        public async Task<ActionResult> PutRole(int id, RoleDTO roleDto)
        {
            if (id != roleDto.RoleId)
            {
                return BadRequest();
            }

            var mapperRole = _mapper.Map<Role>(roleDto);

            await _roleService.Update(mapperRole);

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
