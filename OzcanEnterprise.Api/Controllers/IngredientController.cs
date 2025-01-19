using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;
using OzcanEnterprise.Library.Repositories;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientController(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        [HttpGet("GetIngredients")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Ingredient>))]
        public async Task<IActionResult> GetIngredients()
        {
            var values = await _ingredientRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetIngredientById/{id}")]
        [ProducesResponseType(200, Type = typeof(Ingredient))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            var value = await _ingredientRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetIngredientsByRecipeId/{recipeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<IngredientDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByRecipeId(Guid recipeId)
        {
            var values = await _ingredientRepository.GetIngredientsByRecipeIdAsync(recipeId);
            if (values == null || !values.Any())
                return NotFound("Ingredients not found.");

            return Ok(values);
        }

        [HttpPost("CreateIngredient")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateIngredient(IngredientDto dto)
        {
            await _ingredientRepository.CreateAsync(dto);
            return Ok("Ingredient created successfully.");
        }

        [HttpDelete("DeleteIngredient/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            await _ingredientRepository.DeleteAsync(id);
            return Ok("Ingredient deleted successfully.");
        }

        [HttpPut("UpdateIngredient/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateIngredient(Guid id, IngredientDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ingredientRepository.UpdateAsync(dto);
            return Ok("Ingredient updated successfully.");
        }
    }
}
