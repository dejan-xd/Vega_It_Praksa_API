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
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            var project = await _projectService.Get();
            var mapperProject = _mapper.Map<ProjectDTO[]>(project);

            return mapperProject;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await _projectService.Get(id);
            var mapperProject = _mapper.Map<ProjectDTO>(project);

            return mapperProject;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectDTO projectDto)
        {
            var mapperProject = _mapper.Map<Project>(projectDto);
            var newProject = await _projectService.Create(mapperProject);

            return CreatedAtAction(nameof(GetProject), new { id = newProject.ProjectId }, newProject);
        }

        [HttpPut]
        public async Task<ActionResult> PutProject(int id, ProjectDTO projectDto)
        {
            if (id != projectDto.ProjectId)
            {
                return BadRequest();
            }

            var mapperProject = _mapper.Map<Project>(projectDto);

            await _projectService.Update(mapperProject);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var projectToDelete = await _projectService.Get(id);
            if (projectToDelete == null)
                return NotFound();

            await _projectService.Delete(projectToDelete.ProjectId);
            return NoContent();
        }
    }
}
