using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using StockApp.API;
using StockApp.Application.DTOs;
using Xunit;

namespace StockApp.IntegrationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task RegisterAndLogin_ValidCredentials_ReturnsToken()
        {
            var adminLoginDto = new UserLoginDTO
            {
                Username = "admin",
                Password = "admin"
            };

            var loginResponse = await _client.PostAsJsonAsync("/api/token/login", adminLoginDto);
            loginResponse.EnsureSuccessStatusCode();

            var tokenResponse = await loginResponse.Content.ReadFromJsonAsync<TokenResponseDTO>();
            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.Token);

            var userRegisterDto = new UserRegisterDTO
            {
                Username = "testuser",
                Password = "password",
                Role = "User" 
            };

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.Token);
            var registerResponse = await _client.PostAsJsonAsync("/api/users/register", userRegisterDto);
            registerResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, registerResponse.StatusCode);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsUnauthorized()
        {
            var userLoginDto = new UserLoginDTO
            {
                Username = "invaliduser",
                Password = "invalidpassword"
            };

            var loginResponse = await _client.PostAsJsonAsync("/api/token/login", userLoginDto);

            Assert.Equal(HttpStatusCode.Unauthorized, loginResponse.StatusCode);
        }
    }
}
