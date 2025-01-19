using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpGet("GetRatings")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Rating>))]
        public async Task<IActionResult> GetRatings()
        {
            var values = await _ratingRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetRatingById/{id}")]
        [ProducesResponseType(200, Type = typeof(Rating))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetRatingById(Guid id)
        {
            var value = await _ratingRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetRatingsByRecipeId/{recipeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RatingDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRatingsByRecipeId(Guid recipeId)
        {
            var values = await _ratingRepository.GetRatingsByRecipeIdAsync(recipeId);
            if (values == null || !values.Any())
                return NotFound("Ratings not found.");

            return Ok(values);
        }

        [HttpGet("GetRatingsByUserId/{userId}")]
        [ProducesResponseType(200, Type = typeof(RatingDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRatingsByUserId(Guid userId)
        {
            var values = await _ratingRepository.GetRatingsByUserIdAsync(userId);
            if (values == null || !values.Any())
                return NotFound("Rating not found.");

            return Ok(values);
        }

        [HttpPost("CreateRating")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRating(RatingDto dto)
        {
            await _ratingRepository.CreateAsync(dto);
            return Ok("Rating created successfully.");
        }

        [HttpDelete("DeleteRating/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRating(Guid id)
        {
            await _ratingRepository.DeleteAsync(id);
            return Ok("Rating deleted successfully.");
        }

        [HttpPut("UpdateRating/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateRating(Guid id, RatingDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ratingRepository.UpdateAsync(dto);
            return Ok("Rating updated successfully.");
        }
    }
}
