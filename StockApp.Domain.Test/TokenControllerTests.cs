using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using StockApp.API.Controllers;
using StockApp.Application.Interfaces;
using StockApp.Application.DTOs;
using System.Threading.Tasks;

public class TokenControllerTests
{
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly TokenController _tokenController;

    public TokenControllerTests()
    {
        _authServiceMock = new Mock<IAuthService>();
        _tokenController = new TokenController(_authServiceMock.Object);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsToken()
    {
        // Arrange
        _authServiceMock.Setup(service => service.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new TokenResponseDTO
        {
            Token = "token",
            Expiration = DateTime.UtcNow.AddMinutes(60)
        });

        var userLoginDto = new UserLoginDTO
        {
            Username = "testuser",
            Password = "password"
        };

        // Act
        var result = await _tokenController.Login(userLoginDto) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<TokenResponseDTO>(result.Value);
    }

    [Fact]
    public async Task Login_EmptyCredentials_ReturnsBadRequest()
    {
        // Arrange
        var userLoginDto = new UserLoginDTO
        {
            Username = "",
            Password = ""
        };

        // Act
        var result = await _tokenController.Login(userLoginDto) as BadRequestResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }
}
