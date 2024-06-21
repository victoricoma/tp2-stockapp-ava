using Microsoft.AspNetCore.Mvc;
using Moq;
using StockApp.API.Controllers;
using StockApp.Application.DTOs;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;

namespace StockApp.Domain.Test
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task Register_ValidUser_ReturnsOk()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UsersController>>();
            var usersController = new UsersController(userRepositoryMock.Object, loggerMock.Object);

            var userEntity = new User
            {
                Username = "testuser",
                PasswordHash = "hashed_password", // Simulating hashed password storage
                Role = "User"
            };

            userRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var userRegisterDto = new UserRegisterDTO
            {
                Username = userEntity.Username,
                Password = "password",
                Role = userEntity.Role
            };

            // Act
            var result = await usersController.Register(userRegisterDto) as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<UsersController>>();
            var usersController = new UsersController(userRepositoryMock.Object, loggerMock.Object);

            var invalidUserEntity = new UserRegisterDTO
            {
                Username = "", // Invalid username
                Password = "hashed_password",
                Role = "User"
            };

            // Act
            var result = await usersController.Register(invalidUserEntity);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
