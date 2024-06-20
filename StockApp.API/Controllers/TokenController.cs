using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Interfaces;
using StockApp.Application.DTOs;
using System.Threading.Tasks;

namespace StockApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;

        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var token = await _authService.AuthenticateAsync(userLoginDTO.Username, userLoginDTO.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
