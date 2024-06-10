### Descrição Detalhada do Repositório `tp2-stockapp`

#### Visão Geral

O repositório `tp2-stockapp` é um projeto desenvolvido em C# utilizando .NET Core, seguindo os princípios da Clean Architecture. A aplicação serve para gerenciar o estoque de produtos de uma empresa, permitindo o cadastro, atualização, visualização e remoção de itens no estoque. A aplicação possui endpoints documentados utilizando Swagger, mas ainda não implementa autenticação JWT. A comunicação com o banco de dados é realizada via Azure SQL Server, utilizando Entity Framework.

#### Tecnologias Utilizadas

- **Backend**:
  - **C#**: Linguagem de programação.
  - **.NET Core**: Framework para construção da aplicação.
  - **Swagger**: Ferramenta para documentação de APIs.
  - **Entity Framework**: ORM (Object-Relational Mapping) para interação com o banco de dados.
  - **Azure SQL Server**: Serviço de banco de dados relacional na nuvem da Microsoft.

#### Camadas da Arquitetura

A arquitetura da aplicação é organizada em diversas camadas, cada uma com responsabilidades específicas:

1. **Application**
2. **Domain**
3. **Domain.Test**
4. **Infra.IoC**
5. **Infra.Data**
6. **API**

#### Detalhamento das Camadas

1. **Application**:
   - **Função**: Esta camada contém a lógica de aplicação, incluindo os casos de uso e os serviços de aplicação.
   - **Componentes**:
     - **DTOs (Data Transfer Objects)**: Objetos utilizados para transferência de dados entre as camadas.
     - **Mediators**: Implementação do padrão Mediator para tratar as requisições e respostas.
     - **Services**: Serviços específicos da aplicação que orquestram as operações de negócio.

2. **Domain**:
   - **Função**: Esta camada representa o núcleo da aplicação, contendo as entidades de domínio e a lógica de negócio.
   - **Componentes**:
     - **Entities**: Entidades de domínio que representam os objetos de negócio.
     - **Interfaces**: Contratos que definem os serviços e repositórios utilizados pela aplicação.
     - **Specifications**: Regras de negócio e validações específicas do domínio.

3. **Domain.Test**:
   - **Função**: Esta camada contém os testes unitários para a lógica de negócio na camada de domínio.
   - **Componentes**:
     - **Unit Tests**: Testes que validam o comportamento das entidades de domínio e das regras de negócio.

4. **Infra.IoC**:
   - **Função**: Esta camada é responsável pela configuração da Injeção de Dependências (IoC - Inversion of Control).
   - **Componentes**:
     - **Dependency Injection Configurations**: Configurações para registrar e resolver dependências entre as camadas.

5. **Infra.Data**:
   - **Função**: Esta camada contém a implementação dos repositórios e a configuração do banco de dados.
   - **Componentes**:
     - **Repositories**: Implementações dos repositórios utilizando Entity Framework para interagir com o Azure SQL Server.
     - **Migrations**: Configurações e migrações do banco de dados para gerenciar a estrutura de dados.

6. **API**:
   - **Função**: Esta camada expõe os endpoints da API para interação com a aplicação.
   - **Componentes**:
     - **Controllers**: Controladores que definem os endpoints da API utilizando ASP.NET Core.
     - **Swagger Configuration**: Configurações para a documentação da API com Swagger.
     - **Middlewares**: Incluem configurações para tratamento de erros, log e outras funcionalidades transversais.

#### Diagrama de Arquitetura

```plaintext
                          +---------------------------------+
                          |              API               |
                          |        (Controllers, Swagger)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |            Application          |
                          |         (DTOs, Mediators)       |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |               Domain            |
                          |  (Entities, Interfaces, Specs)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |          Infra.IoC              |
                          |  (Dependency Injection Config)  |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |           Infra.Data            |
                          |  (Repositories, Migrations)     |
                          +---------------+-----------------+
                                          |
                                          v
                          +---------------+-----------------+
                          |         Azure SQL Server        |
                          |      (Entity Framework)         |
                          +---------------------------------+
```

Neste diagrama:

- **API**: Contém os controllers que definem os endpoints da API e a configuração do Swagger para documentação.
- **Application**: Contém a lógica de aplicação, incluindo os DTOs e os mediators que tratam as requisições.
- **Domain**: Contém as entidades de domínio, interfaces e especificações que implementam a lógica de negócio.
- **Infra.IoC**: Contém as configurações para injeção de dependências.
- **Infra.Data**: Contém as implementações dos repositórios e a configuração do Entity Framework para interação com o Azure SQL Server.
- **Azure SQL Server**: Banco de dados relacional utilizado para armazenar os dados da aplicação.

# Tarefas para Avaliação:

### Tarefas para Implementação do Controlador `ProductsController` em .NET 6

#### Introdução

O controlador `ProductsController` será responsável por gerenciar os endpoints relacionados à entidade `Product`. Ele permitirá a realização de operações CRUD (Create, Read, Update, Delete) e será estruturado conforme os princípios de Clean Architecture. Dividiremos a implementação do controlador em quatro tarefas, utilizando a pontuação Fibonacci para priorizar e categorizar a complexidade das tarefas. 

#### Tarefas

1. **(5 pontos) Criação do Controlador e Endpoints de Leitura (`GetAll` e `GetById`)**
   - **Descrição**: Crie o controlador `ProductsController` e implemente os métodos para obter todos os produtos e obter um produto por ID.
   - **Código**:
     ```csharp
     using Microsoft.AspNetCore.Mvc;
     using System.Collections.Generic;
     using System.Threading.Tasks;
     using tp2_stockapp_ava.Domain.Entities;
     using tp2_stockapp_ava.Domain.Interfaces;

     namespace tp2_stockapp_ava.API.Controllers
     {
         [ApiController]
         [Route("api/[controller]")]
         public class ProductsController : ControllerBase
         {
             private readonly IProductRepository _productRepository;

             public ProductsController(IProductRepository productRepository)
             {
                 _productRepository = productRepository;
             }

             [HttpGet]
             public async Task<ActionResult<IEnumerable<Product>>> GetAll()
             {
                 var products = await _productRepository.GetAllAsync();
                 return Ok(products);
             }

             [HttpGet("{id}")]
             public async Task<ActionResult<Product>> GetById(int id)
             {
                 var product = await _productRepository.GetByIdAsync(id);
                 if (product == null)
                 {
                     return NotFound();
                 }
                 return Ok(product);
             }
         }
     }
     ```

2. **(8 pontos) Implementação dos Endpoints de Criação (`Create`)**
   - **Descrição**: Implemente o método para adicionar um novo produto.
   - **Código**:
     ```csharp
     [HttpPost]
     public async Task<ActionResult<Product>> Create(Product product)
     {
         await _productRepository.AddAsync(product);
         return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
     }
     ```

3. **(8 pontos) Implementação dos Endpoints de Atualização (`Update`)**
   - **Descrição**: Implemente o método para atualizar um produto existente.
   - **Código**:
     ```csharp
     [HttpPut("{id}")]
     public async Task<IActionResult> Update(int id, Product product)
     {
         if (id != product.Id)
         {
             return BadRequest();
         }
         await _productRepository.UpdateAsync(product);
         return NoContent();
     }
     ```

4. **(13 pontos) Implementação dos Endpoints de Deleção (`Delete`) e Configuração no `Program.cs`**
   - **Descrição**: Implemente o método para deletar um produto existente e configure o `Program.cs` para registrar o repositório e mapear as rotas.
   - **Código**:
     ```csharp
     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(int id)
     {
         var product = await _productRepository.GetByIdAsync(id);
         if (product == null)
         {
             return NotFound();
         }
         await _productRepository.DeleteAsync(id);
         return NoContent();
     }
     ```

     - **Código no `Program.cs`**:
       ```csharp
       var builder = WebApplication.CreateBuilder(args);

       // Add services to the container.
       builder.Services.AddControllers();
       builder.Services.AddScoped<IProductRepository, ProductRepository>();  // Registro do repositório

       var app = builder.Build();

       // Configure the HTTP request pipeline.
       if (app.Environment.IsDevelopment())
       {
           app.UseDeveloperExceptionPage();
       }

       app.UseRouting();
       app.UseAuthorization();

       app.MapControllers();

       app.Run();
       ```


5. **(3 pontos) Configuração do AppSettings para JWT**
   - **Descrição**: Adicione as configurações necessárias no `appsettings.json` para JWT.
   - **Código**:
     ```json
     {
       "Jwt": {
         "Key": "ChaveSecretaParaJwtToken",
         "Issuer": "SeuIssuer",
         "Audience": "SuaAudience",
         "ExpireMinutes": 60
       }
     }
     ```

6. **(3 pontos) Criação do DTO `UserLoginDto`**
   - **Descrição**: Crie o DTO `UserLoginDto` para o login do usuário.
   - **Código**:
     ```csharp
     public class UserLoginDto
     {
         public string Username { get; set; }
         public string Password { get; set; }
     }
     ```

7. **(3 pontos) Criação do DTO `UserRegisterDto`**
   - **Descrição**: Crie o DTO `UserRegisterDto` para o registro do usuário.
   - **Código**:
     ```csharp
     public class UserRegisterDto
     {
         public string Username { get; set; }
         public string Password { get; set; }
         public string Role { get; set; }  // Ex: Admin, User
     }
     ```

8. **(5 pontos) Criação do DTO `TokenResponseDto`**
   - **Descrição**: Crie o DTO `TokenResponseDto` para a resposta do token JWT.
   - **Código**:
     ```csharp
     public class TokenResponseDto
     {
         public string Token { get; set; }
         public DateTime Expiration { get; set; }
     }
     ```

9. **(5 pontos) Criação do Serviço de Autenticação**
   - **Descrição**: Crie o serviço de autenticação que gerará o token JWT.
   - **Código**:
     ```csharp
     public interface IAuthService
     {
         Task<TokenResponseDto> AuthenticateAsync(string username, string password);
     }

     public class AuthService : IAuthService
     {
         private readonly IUserRepository _userRepository;
         private readonly IConfiguration _configuration;

         public AuthService(IUserRepository userRepository, IConfiguration configuration)
         {
             _userRepository = userRepository;
             _configuration = configuration;
         }

         public async Task<TokenResponseDto> AuthenticateAsync(string username, string password)
         {
             var user = await _userRepository.GetByUsernameAsync(username);
             if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
             {
                 return null;
             }

             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
                     new Claim(ClaimTypes.Name, user.Username),
                     new Claim(ClaimTypes.Role, user.Role)
                 }),
                 Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             return new TokenResponseDto
             {
                 Token = tokenHandler.WriteToken(token),
                 Expiration = token.ValidTo
             };
         }
     }
     ```

10. **(5 pontos) Criação do Controlador `TokenController`**
    - **Descrição**: Crie o controlador `TokenController` para gerenciar a autenticação.
    - **Código**:
      ```csharp
      using Microsoft.AspNetCore.Mvc;
      using System.Threading.Tasks;
      using tp2_stockapp_ava.Domain.DTOs;

      namespace tp2_stockapp_ava.API.Controllers
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
              public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
              {
                  var token = await _authService.AuthenticateAsync(userLoginDto.Username, userLoginDto.Password);
                  if (token == null)
                  {
                      return Unauthorized();
                  }

                  return Ok(token);
              }
          }
      }
      ```

11. **(8 pontos) Criação do Controlador `UserController` e Endpoint para Criar Usuário**
    - **Descrição**: Crie o controlador `UserController` e o endpoint para registrar novos usuários.
    - **Código**:
      ```csharp
      using Microsoft.AspNetCore.Mvc;
      using System.Threading.Tasks;
      using tp2_stockapp_ava.Domain.DTOs;
      using tp2_stockapp_ava.Domain.Entities;
      using tp2_stockapp_ava.Domain.Interfaces;

      namespace tp2_stockapp_ava.API.Controllers
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
              public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
              {
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
      ```

12. **(8 pontos) Configuração da Autenticação JWT no `Program.cs`**
    - **Descrição**: Configure a autenticação JWT no `Program.cs`.
    - **Código**:
      ```csharp
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddControllers();
      builder.Services.AddScoped<IUserRepository, UserRepository>();
      builder.Services.AddScoped<IAuthService, AuthService>();

      var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
      builder.Services.AddAuthentication(options =>
      {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
          options.RequireHttpsMetadata = false;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = builder.Configuration["Jwt:Issuer"],
              ValidAudience = builder.Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(key)
          };
      });

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
      ```

13. **(5 pontos) Adicionar Middleware de Autorização Baseada em Roles**
    - **Descrição**: Adicione middleware para autorização baseada em roles (funções) para proteger endpoints específicos.
    - **Código**:
      ```csharp
      [Authorize(Roles = "Admin")]
      [ApiController]
      [Route("api/[controller]")]
      public class AdminController : ControllerBase
      {
          // Endpoints para administradores
      }
      ```

14. **(5 pontos) Criação de Exceções Personalizadas para Autenticação**
    - **Descrição**: Crie exceções personalizadas para lidar com erros de autenticação.
    - **Código**:
      ```csharp
      public class AuthenticationException : Exception
      {
          public AuthenticationException(string message) : base(message) { }
      }

      public class AuthorizationException : Exception
      {
          public AuthorizationException(string message) : base(message) { }
      }
      ```

15. **(8 pontos) Configuração do Swagger para Usar JWT**
    - **Descrição**: Configure o Swagger para incluir o token JWT nos cabeçalhos de autorização.
    - **Código**:
      ```csharp
      builder.Services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

          var securitySchema = new OpenApiSecurityScheme
          {
              Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
              Name = "Authorization",
              In = ParameterLocation.Header,
              Type = SecuritySchemeType.Http,
              Scheme = "bearer",
              BearerFormat = "JWT",
              Reference = new OpenApiReference
              {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
              }
          };

          c.AddSecurityDefinition("Bearer", securitySchema);

          var securityRequirement = new OpenApi

SecurityRequirement
          {
              { securitySchema, new[] { "Bearer" } }
          };

          c.AddSecurityRequirement(securityRequirement);
      });
      ```

16. **(8 pontos) Adicionar Testes Unitários para o Serviço de Autenticação**
    - **Descrição**: Adicione testes unitários para o serviço de autenticação.
    - **Código**:
      ```csharp
      [Fact]
      public async Task AuthenticateAsync_ValidCredentials_ReturnsToken()
      {
          // Arrange
          var userRepositoryMock = new Mock<IUserRepository>();
          var configurationMock = new Mock<IConfiguration>();
          var authService = new AuthService(userRepositoryMock.Object, configurationMock.Object);

          userRepositoryMock.Setup(repo => repo.GetByUsernameAsync(It.IsAny<string>())).ReturnsAsync(new User
          {
              Username = "testuser",
              PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
              Role = "User"
          });

          configurationMock.Setup(config => config["Jwt:Key"]).Returns("ChaveSecretaParaJwtToken");
          configurationMock.Setup(config => config["Jwt:Issuer"]).Returns("SeuIssuer");
          configurationMock.Setup(config => config["Jwt:Audience"]).Returns("SuaAudience");

          // Act
          var result = await authService.AuthenticateAsync("testuser", "password");

          // Assert
          Assert.NotNull(result);
          Assert.IsType<TokenResponseDto>(result);
      }
      ```

17. **(13 pontos) Adicionar Testes Unitários para o Controlador `TokenController`**
    - **Descrição**: Adicione testes unitários para o controlador `TokenController`.
    - **Código**:
      ```csharp
      [Fact]
      public async Task Login_ValidCredentials_ReturnsToken()
      {
          // Arrange
          var authServiceMock = new Mock<IAuthService>();
          var tokenController = new TokenController(authServiceMock.Object);

          authServiceMock.Setup(service => service.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new TokenResponseDto
          {
              Token = "token",
              Expiration = DateTime.UtcNow.AddMinutes(60)
          });

          var userLoginDto = new UserLoginDto
          {
              Username = "testuser",
              Password = "password"
          };

          // Act
          var result = await tokenController.Login(userLoginDto) as OkObjectResult;

          // Assert
          Assert.NotNull(result);
          Assert.Equal(200, result.StatusCode);
          Assert.IsType<TokenResponseDto>(result.Value);
      }
      ```

18. **(13 pontos) Adicionar Testes Unitários para o Controlador `UsersController`**
    - **Descrição**: Adicione testes unitários para o controlador `UsersController`.
    - **Código**:
      ```csharp
      [Fact]
      public async Task Register_ValidUser_ReturnsOk()
      {
          // Arrange
          var userRepositoryMock = new Mock<IUserRepository>();
          var usersController = new UsersController(userRepositoryMock.Object);

          var userRegisterDto = new UserRegisterDto
          {
              Username = "testuser",
              Password = "password",
              Role = "User"
          };

          // Act
          var result = await usersController.Register(userRegisterDto) as OkResult;

          // Assert
          Assert.NotNull(result);
          Assert.Equal(200, result.StatusCode);
      }
      ```

19. **(21 pontos) Testes de Integração para Controladores `TokenController` e `UsersController`**
    - **Descrição**: Adicione testes de integração para verificar o fluxo completo de registro e autenticação de usuários.
    - **Código**:
      ```csharp
      public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
      {
          private readonly HttpClient _client;

          public IntegrationTests(WebApplicationFactory<Startup> factory)
          {
              _client = factory.CreateClient();
          }

          [Fact]
          public async Task RegisterAndLogin_ValidCredentials_ReturnsToken()
          {
              // Arrange
              var userRegisterDto = new UserRegisterDto
              {
                  Username = "testuser",
                  Password = "password",
                  Role = "User"
              };

              var userLoginDto = new UserLoginDto
              {
                  Username = "testuser",
                  Password = "password"
              };

              // Register
              var registerResponse = await _client.PostAsJsonAsync("/api/users/register", userRegisterDto);
              registerResponse.EnsureSuccessStatusCode();

              // Login
              var loginResponse = await _client.PostAsJsonAsync("/api/token/login", userLoginDto);
              loginResponse.EnsureSuccessStatusCode();

              var tokenResponse = await loginResponse.Content.ReadFromJsonAsync<TokenResponseDto>();

              // Assert
              Assert.NotNull(tokenResponse);
              Assert.NotNull(tokenResponse.Token);
              Assert.True(tokenResponse.Expiration > DateTime.UtcNow);
          }
      }
      ```

20. **(34 pontos) Implementação de Middleware de Manipulação de Erros e Registro de Logs**
    - **Descrição**: Adicione um middleware para manipulação de erros e registro de logs detalhados.
    - **Código**:
      ```csharp
      public class ErrorHandlerMiddleware
      {
          private readonly RequestDelegate _next;
          private readonly ILogger<ErrorHandlerMiddleware> _logger;

          public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
          {
              _next = next;
              _logger = logger;
          }

          public async Task Invoke(HttpContext context)
          {
              try
              {
                  await _next(context);
              }
              catch (Exception ex)
              {
                  _logger.LogError(ex, ex.Message);
                  await HandleExceptionAsync(context, ex);
              }
          }

          private static Task HandleExceptionAsync(HttpContext context, Exception exception)
          {
              var code = HttpStatusCode.InternalServerError;

              var result = JsonSerializer.Serialize(new { error = exception.Message });
              context.Response.ContentType = "application/json";
              context.Response.StatusCode = (int)code;
              return context.Response.WriteAsync(result);
          }
      }

      public static class ErrorHandlerMiddlewareExtensions
      {
          public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
          {
              return builder.UseMiddleware<ErrorHandlerMiddleware>();
          }
      }
      ```

      - **Código no `Program.cs`**:
        ```csharp
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            c.AddSecurityDefinition("Bearer", securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "Bearer" } }
            };

            c.AddSecurityRequirement(securityRequirement);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseErrorHandlerMiddleware();  // Adicionando middleware de manipulação de erros

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        ```

