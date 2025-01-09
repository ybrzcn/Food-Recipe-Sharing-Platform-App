using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategories()
        {
            var values = await _categoryRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var value = await _categoryRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var value = await _categoryRepository.GetCategoryByNameAsync(name);
            if (value == null) return NotFound("Category not found.");
            return Ok(value);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategory(CategoryDto dto)
        {
            await _categoryRepository.CreateAsync(dto);
            return Ok("Category created successfully.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
            return Ok("Category deleted successfully.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _categoryRepository.UpdateAsync(dto);
            return Ok("Category updated successfully.");
        }
    }
}