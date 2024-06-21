using Moq;
using Xunit;
using StockApp.Application.Services;
using StockApp.Application.Interfaces;
using StockApp.Domain.Interfaces;
using StockApp.Domain.Entities;
using StockApp.Application.DTOs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _configurationMock = new Mock<IConfiguration>();

        _configurationMock.Setup(config => config["JwtSettings:SecretKey"]).Returns("ChaveSecretaParaJwtTokenQueTemQueTerMaisQue32CaractereParaFuncionar");
        _configurationMock.Setup(config => config["JwtSettings:Issuer"]).Returns("SeuIssuer");
        _configurationMock.Setup(config => config["JwtSettings:Audience"]).Returns("SuaAudience");
        _configurationMock.Setup(config => config["JwtSettings:AccessTokenExpirationMinutes"]).Returns("60");

        _authService = new AuthService(_userRepositoryMock.Object, _configurationMock.Object);
    }

    [Fact]
    public async Task AuthenticateAsync_ValidCredentials_ReturnsToken()
    {
 
        var username = "testuser";
        var password = "password";
        var user = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = "User"
        };

        _userRepositoryMock.Setup(repo => repo.GetByUsernameAsync(username)).ReturnsAsync(user);

        var result = await _authService.AuthenticateAsync(username, password);

        Assert.NotNull(result);
        Assert.IsType<TokenResponseDTO>(result);
    }

    [Fact]
    public async Task AuthenticateAsync_InvalidPassword_ReturnsNull()
    {
        var username = "testuser";
        var password = "wrongpassword";
        var user = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            Role = "User"
        };

        _userRepositoryMock.Setup(repo => repo.GetByUsernameAsync(username)).ReturnsAsync(user);

        var result = await _authService.AuthenticateAsync(username, password);

        Assert.Null(result);
    }

    [Fact]
    public async Task AuthenticateAsync_UserNotFound_ReturnsNull()
    {
        var username = "nonexistentuser";
        var password = "password";

        _userRepositoryMock.Setup(repo => repo.GetByUsernameAsync(username)).ReturnsAsync((User)null);

        var result = await _authService.AuthenticateAsync(username, password);


        Assert.Null(result);
    }
}
