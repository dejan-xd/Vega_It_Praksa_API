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
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryService.Get(); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO categoryDto)
        {
            var mapperCategory = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryService.Create(mapperCategory);

            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, newCategory);
        }

        [HttpPut]
        public async Task<ActionResult> PutCategory(int id, CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
            {
                return BadRequest();
            }

            var mapperCategory = _mapper.Map<Category>(categoryDto);

            await _categoryService.Update(mapperCategory);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryService.Get(id);
            if (categoryToDelete == null)
                return NotFound();

            await _categoryService.Delete(categoryToDelete.CategoryId);
            return NoContent();
        }
    }
}
