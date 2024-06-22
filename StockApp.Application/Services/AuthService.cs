using Microsoft.Extensions.Logging;
using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using StockApp.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Serilog.AspNetCore;
using StockApp.Domain.Validation;

namespace StockApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TokenResponseDTO> AuthenticateAsync(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(username);
                if (user == null)
                {
                    _logger.LogWarning($"User '{username}' not found.");
                    throw new AuthenticationException("Invalid username or password.");
                }

                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    _logger.LogWarning($"User '{username}' provided an invalid password.");
                    throw new AuthenticationException("Invalid username or password.");
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:AccessTokenExpirationMinutes"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"])), SecurityAlgorithms.HmacSha256Signature),
                    Audience = _configuration["JwtSettings:Audience"],
                    Issuer = _configuration["JwtSettings:Issuer"]
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new TokenResponseDTO
                {
                    Token = tokenHandler.WriteToken(token)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during authentication.");
                throw;
            }
        }
    }
}