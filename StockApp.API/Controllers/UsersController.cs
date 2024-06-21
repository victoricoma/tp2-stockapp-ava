using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using StockApp.Application.DTOs;
using Microsoft.Extensions.Logging;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            if (userRegisterDto == null)
            {
                _logger.LogError("Invalid user data received.");
                return BadRequest("Invalid user data.");
            }

            if (string.IsNullOrWhiteSpace(userRegisterDto.Username))
            {
                _logger.LogError("Invalid username.");
                return BadRequest("Username cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(userRegisterDto.Password))
            {
                _logger.LogError("Invalid password.");
                return BadRequest("Password cannot be empty.");
            }

            var user = new User
            {
                Username = userRegisterDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
                Role = userRegisterDto.Role
            };

            await _userRepository.AddAsync(user);

            _logger.LogInformation($"User {user.Username} registered successfully.");

            return Ok();
        }
    }
}
