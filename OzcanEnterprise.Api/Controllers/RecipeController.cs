using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;
using OzcanEnterprise.Library.Repositories;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("GetRecipes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Recipe>))]
        public async Task<IActionResult> GetRecipes()
        {
            var values = await _recipeRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetRecipeById/{id}")]
        [ProducesResponseType(200, Type = typeof(Recipe))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            var value = await _recipeRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetRecipesByCategoryId/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecipeDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecipesByCategoryId(Guid categoryId)
        {
            var values = await _recipeRepository.GetRecipesByCategoryIdAsync(categoryId);
            if (values == null || !values.Any())
                return NotFound("Recipe not found.");

            return Ok(values);
        }

        [HttpGet("GetRecipesByAuthorId/{authorId}")]
        [ProducesResponseType(200, Type = typeof(RecipeDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecipesByAuthorId(Guid authorId)
        {
            var values = await _recipeRepository.GetRecipesByAuthorIdAsync(authorId);
            if (values == null || !values.Any())
                return NotFound("Recipes not found.");

            return Ok(values);
        }

        [HttpPost("CreateRecipe")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRecipe(RecipeDto dto)
        {
            await _recipeRepository.CreateAsync(dto);
            return Ok("Recipe created successfully.");
        }

        [HttpDelete("DeleteRecipe/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            await _recipeRepository.DeleteAsync(id);
            return Ok("Recipe deleted successfully.");
        }

        [HttpPut("UpdateRecipe/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateRecipe(Guid id, RecipeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _recipeRepository.UpdateAsync(dto);
            return Ok("Recipe updated successfully.");
        }
    }
}
