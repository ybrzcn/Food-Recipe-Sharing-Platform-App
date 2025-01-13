using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("GetComments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        public async Task<IActionResult> GetComments()
        {
            var values = await _commentRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetCommentById/{id}")]
        [ProducesResponseType(200, Type = typeof(Comment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCommentsByRecipeIdAsync/{recipeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByRecipeIdAsync(Guid recipeId)
        {
            var values = await _commentRepository.GetCommentsByRecipeIdAsync(recipeId);
            if (values == null || !values.Any()) 
                return NotFound("Comments not found.");

            return Ok(values);
        }

        [HttpGet("GetCommentsByUserIdAsync/{userId}")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByUserIdAsync(Guid userId)
        {
            var values = await _commentRepository.GetCommentsByUserIdAsync(userId);
            if (values == null || !values.Any())
                return NotFound("Comments not found.");

            return Ok(values);
        }

        [HttpPost("CreateComment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateComment(CommentDto dto)
        {
            await _commentRepository.CreateAsync(dto);
            return Ok("Comment created successfully.");
        }

        [HttpDelete("DeleteComment/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            await _commentRepository.DeleteAsync(id);
            return Ok("Comment deleted successfully.");
        }

        [HttpPut("UpdateComment/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateComment(Guid id, CommentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _commentRepository.UpdateAsync(dto);
            return Ok("Comment updated successfully.");
        }
    }
}
