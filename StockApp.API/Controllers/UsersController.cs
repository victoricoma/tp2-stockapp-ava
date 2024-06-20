using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            if (userRegisterDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = new User
            {
                Username = userRegisterDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password),
                Role = userRegisterDto.Role
            };

            await _userRepository.AddAsync(user);
            return Ok();
        }
    }
}
