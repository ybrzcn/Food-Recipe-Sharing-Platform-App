using Microsoft.AspNetCore.Mvc;
using OzcanEnterprise.Library.Dtos;
using OzcanEnterprise.Library.Entities;
using OzcanEnterprise.Library.Interfaces;
using OzcanEnterprise.Library.Repositories;

namespace OzcanEnterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { 
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _userRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("GetUserById/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var value = await _userRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCategoryByEmail/{email}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryByEmail(string email)
        {
            var value = await _userRepository.GetUserByEmailAsync(email);
            if (value == null) return NotFound("User not found.");
            return Ok(value);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
            await _userRepository.CreateAsync(dto);
            return Ok("User created successfully.");
        }

        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return Ok("User deleted successfully.");
        }

        [HttpPut("UpdateUser/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(Guid id, UserDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _userRepository.UpdateAsync(dto);
            return Ok("User updated successfully.");
        }
    }
}
