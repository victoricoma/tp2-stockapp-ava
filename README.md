# Descrição Detalhada do Repositório `tp2-stockapp`
![Logo Quadrado HelPr](https://github.com/victoricoma/tp2-stockapp-ava/assets/31005408/0d9e2fad-2213-4d3f-9b38-b611e0449246)

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
## Documentação feito por:
![2](https://github.com/victoricoma/tp2-stockapp-ava/assets/31005408/55069c14-9f55-4368-b83a-104eb59f2463)
# Melhorias Aplicadas:
### Pontos de Melhoria nas Tarefas Anteriores

1. **Documentação e Comentários XML na API**:
   - **Tarefa 46**: Adiciona comentários XML nos controladores e métodos da API, melhorando a documentação automática com Swagger e a compreensão do código.

2. **Configuração de CORS**:
   - **Tarefa 22**: Configura CORS (Cross-Origin Resource Sharing) para permitir requisições de diferentes origens, facilitando a integração com frontend e outras APIs.

3. **Paginação**:
   - **Tarefa 23**: Implementa paginação nos endpoints de leitura para melhorar a performance e usabilidade ao lidar com grandes volumes de dados.

4. **Logging**:
   - **Tarefa 24**: Adiciona logging usando Serilog para registrar requisições e erros, facilitando a depuração e manutenção do sistema.

5. **Caching**:
   - **Tarefa 25**: Implementa caching usando Redis para melhorar a performance das leituras frequentes.

6. **Relatórios de Estoque Baixo**:
   - **Tarefa 26**: Adiciona um endpoint para gerar relatórios de produtos com estoque baixo, ajudando na gestão do estoque.

7. **Atualização em Massa**:
   - **Tarefa 27**: Implementa um endpoint de atualização em massa para facilitar a administração de múltiplos produtos.

8. **Exportação de Relatórios**:
   - **Tarefa 28**: Adiciona suporte à exportação de relatórios em formato CSV, permitindo a análise offline e integração com outras ferramentas.

9. **Autenticação Multi-Fator (MFA)**:
   - **Tarefa 29**: Implementa autenticação multi-fator para aumentar a segurança do sistema.

10. **Reposição Automática de Estoque**:
    - **Tarefa 30**: Adiciona funcionalidade para repor automaticamente o estoque de produtos com baixo estoque, garantindo disponibilidade contínua.

11. **Upload de Imagem de Produtos**:
    - **Tarefa 31**: Implementa a funcionalidade de upload de imagem para os produtos, melhorando a apresentação visual no frontend.

12. **Notificações em Tempo Real**:
    - **Tarefa 32**: Implementa notificações em tempo real usando SignalR para alterações no estoque, proporcionando atualizações instantâneas aos usuários.

13. **Auditoria de Mudanças no Estoque**:
    - **Tarefa 33**: Adiciona auditoria de mudanças no estoque para registrar e monitorar alterações, melhorando a rastreabilidade.

14. **Sistema de Permissões Granulares**:
    - **Tarefa 34**: Implementa um sistema de permissões granulares para controlar o acesso a diferentes funcionalidades com base em roles.

15. **Integração com API Externa para Cotação de Preços**:
    - **Tarefa 35**: Adiciona integração com uma API externa para obter cotações de preços dos produtos, auxiliando na precificação dinâmica.

16. **Filtragem Avançada nos Relatórios**:
    - **Tarefa 36**: Implementa funcionalidade de filtragem avançada nos relatórios de produtos, facilitando a análise e a tomada de decisões.

17. **Backup Automático do Banco de Dados**:
    - **Tarefa 37**: Adiciona funcionalidade de backup automático do banco de dados para garantir a segurança e a recuperação de dados.

18. **Importação de Dados em Massa**:
    - **Tarefa 38**: Implementa a funcionalidade para importar dados de produtos em massa a partir de um arquivo CSV, agilizando a inserção de grandes volumes de dados.

19. **Notificações por Email**:
    - **Tarefa 39**: Adiciona sistema de notificações por email para alertar sobre eventos importantes como baixo estoque.

20. **Relatórios Gráficos**:
    - **Tarefa 40**: Implementa funcionalidade de geração de relatórios gráficos de estoque e vendas, facilitando a visualização de dados e tendências.

21. **Avaliação de Produtos pelos Clientes**:
    - **Tarefa 41**: Adiciona funcionalidade para que os clientes possam avaliar os produtos, proporcionando feedback valioso.

22. **Busca Avançada**:
    - **Tarefa 42**: Implementa busca avançada com suporte a filtros e ordenação, melhorando a experiência do usuário na busca de produtos.

23. **Recomendação de Produtos**:
    - **Tarefa 43**: Adiciona sistema de recomendação de produtos baseado no histórico de compras dos clientes, incentivando vendas cruzadas.

24. **Carrinho de Compras**:
    - **Tarefa 44**: Implementa funcionalidade de carrinho de compras para os clientes, facilitando a gestão de pedidos.

25. **Checkout e Processamento de Pagamentos**:
    - **Tarefa 45**: Adiciona funcionalidade de checkout e integração com um serviço de processamento de pagamentos, completando o ciclo de vendas.

26. **Recuperação de Senha**:
    - **Tarefa 51**: Adiciona uma funcionalidade para recuperação de senha via email, aumentando a segurança e usabilidade do sistema.

27. **Autenticação com Redes Sociais**:
    - **Tarefa 52**: Implementa autenticação usando provedores de redes sociais como Google e Facebook, facilitando o login para os usuários.

28. **Testes de Carga**:
    - **Tarefa 53**: Configura e executa testes de carga para avaliar o desempenho da API sob condições de alta carga.

29. **Webhook**:
    - **Tarefa 54**: Implementa uma funcionalidade de webhook para notificar sistemas externos sobre eventos importantes.

30. **Suporte a GraphQL**:
    - **Tarefa 55**: Adiciona suporte a GraphQL para consultas mais flexíveis e eficientes.

31. **Análise de Sentimento**:
    - **Tarefa 56**: Adiciona uma funcionalidade para analisar o sentimento das avaliações dos produtos.

32. **Integração com Serviço de Mensagens (SMS)**:
    - **Tarefa 57**: Adiciona suporte para envio de mensagens SMS para notificações críticas.

33. **Pesquisa de Texto Completo**:
    - **Tarefa 58**: Implementa uma funcionalidade de pesquisa de texto completo para melhorar a busca de produtos.

34. **Sistema de Backup Incremental**:
    - **Tarefa 59**: Adiciona um sistema de backup incremental para reduzir o tempo e os recursos necessários para backups.

35. **Agendamento de Tarefas**:
    - **Tarefa 60**: Implementa uma funcionalidade para agendamento de tarefas recorrentes.

36. **Integração com ERP Externo**:
    - **Tarefa 61**: Adiciona integração com um sistema ERP externo para sincronizar dados de produtos e estoque.

37. **Controle de Acesso Baseado em Claims**:
    - **Tarefa 62**: Adiciona um sistema de controle de acesso baseado em claims para gerenciar permissões detalhadas.

38. **Comparação de Produtos**:
    - **Tarefa 63**: Implementa uma funcionalidade para permitir que os usuários comparem diferentes produtos.

39. **Cache Distribuído com Redis**:
    - **Tarefa 64**: Adiciona suporte para cache distribuído usando Redis, melhorando a escalabilidade.

40. **Recomendação Personalizada com Machine Learning**:
    - **Tarefa 65**: Adiciona uma funcionalidade de recomendação personalizada usando modelos de machine learning.

41. **Monitoramento e Alertas com Prometheus e Grafana**:
    - **Tarefa 66**: Configura monitoramento e alertas usando Prometheus e Grafana para monitorar a saúde do sistema.

42. **Sistema de Workflow**:
    - **Tarefa 67**: Adiciona um sistema de workflow para gerenciar processos de negócios complexos.

43. **Análise Preditiva de Vendas**:
    - **Tarefa 68**: Adiciona uma funcionalidade para análise preditiva de vendas usando algoritmos de machine learning.

44. **Gestão de Inventário Just-in-Time**:
    - **Tarefa 69**: Adiciona uma funcionalidade para gestão de inventário just-in-time, otimizando o estoque com base na demanda.

45. **Sistema de Feedback com Análise de Sentimento**:
    - **Tarefa 70**: Adiciona um sistema de feedback para clientes com análise de sentimento para avaliar a satisfação.

# Tarefas para Avaliação:

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

21. **(3 pontos) Adicionar Validação de Dados no Modelo `Product`**
    - **Descrição**: Adicione anotações de validação de dados no modelo `Product`.
    - **Código**:
      ```csharp
      public class Product
      {
          public int Id { get; set; }

          [Required]
          public string Name { get; set; }

          [Required]
          public string Description { get; set; }

          [Range(0, double.MaxValue)]
          public decimal Price { get; set; }

          [Range(0, int.MaxValue)]
          public int Stock { get; set; }
      }
      ```

22. **(3 pontos) Configuração de Cors no `Program.cs`**
    - **Descrição**: Configure o CORS (Cross-Origin Resource Sharing) para permitir requisições de diferentes origens.
    - **Código**:
      ```csharp
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllers();
      builder.Services.AddCors(options =>
      {
          options.AddPolicy("AllowAll", builder =>
          {
              builder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
          });
      });

      var app = builder.Build();

      app.UseCors("AllowAll");

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
      ```

23. **(5 pontos) Implementar Paginação nos Endpoints de Leitura**
    - **Descrição**: Adicione suporte a paginação nos endpoints `GetAll` para produtos.
    - **Código**:
      ```csharp
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Product>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
      {
          var products = await _productRepository.GetAllAsync(pageNumber, pageSize);
          return Ok(products);
      }
      ```

24. **(5 pontos) Adicionar Logging usando Serilog**
    - **Descrição**: Configure o Serilog para logging de requisições e erros.
    - **Código**:
      ```csharp
      var builder = WebApplication.CreateBuilder(args);

      Log.Logger = new LoggerConfiguration()
          .WriteTo.Console()
          .CreateLogger();

      builder.Host.UseSerilog();

      builder.Services.AddControllers();

      var app = builder.Build();

      app.UseSerilogRequestLogging();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
      ```

25. **(8 pontos) Implementar Cache usando Redis**
    - **Descrição**: Adicione suporte a caching usando Redis para melhorar a performance das leituras.
    - **Código**:
      ```csharp
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddStackExchangeRedisCache(options =>
      {
          options.Configuration = builder.Configuration.GetConnectionString("Redis");
      });

      builder.Services.AddControllers();

      var app = builder.Build();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
      ```

26. **(8 pontos) Adicionar Relatório de Estoque Baixo**
    - **Descrição**: Implemente um endpoint para gerar relatórios de produtos com estoque baixo.
    - **Código**:
      ```csharp
      [HttpGet("low-stock")]
      public async Task<ActionResult<IEnumerable<Product>>> GetLowStock([FromQuery] int threshold)
      {
          var products = await _productRepository.GetLowStockAsync(threshold);
          return Ok(products);
      }
      ```

27. **(13 pontos) Implementar Endpoint de Atualização em Massa**
    - **Descrição**: Adicione um endpoint para atualizar múltiplos produtos em uma única requisição.
    - **Código**:
      ```csharp
      [HttpPut("bulk-update")]
      public async Task<IActionResult> BulkUpdate([FromBody] List<Product> products)
      {
          await _productRepository.BulkUpdateAsync(products);
          return NoContent();
      }
      ```

28. **(13 pontos) Adicionar Suporte a Exportação de Relatórios em CSV**
    - **Descrição**: Implemente a funcionalidade de exportar relatórios de produtos em formato CSV.
    - **Código**:
      ```csharp
      [HttpGet("export")]
      public IActionResult ExportToCsv()
      {
          var products = _productRepository.GetAll();
          var csv = new StringBuilder();
          csv.AppendLine("Id,Name,Description,Price,Stock");

          foreach (var product in products)
          {
              csv.AppendLine($"{product.Id},{product.Name},{product.Description},{product.Price},{product.Stock}");
          }

          return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "products.csv");
      }
      ```

29. **(13 pontos) Implementar Autenticação Multi-Fator (MFA)**
    - **Descrição**: Adicione suporte para autenticação multi-fator usando códigos OTP (One-Time Password).
    - **Código**:
      ```csharp
      public class MfaService : IMfaService
      {
          public string GenerateOtp()
          {
              var otp = new Random().Next(100000, 999999).ToString();
              // Armazenar OTP no cache ou banco de dados para validação posterior
              return otp;
          }

          public bool ValidateOtp(string userOtp, string storedOtp)
          {
              return userOtp == storedOtp;
          }
      }
      ```

30. **(21 pontos) Implementar Função de Reposição Automática de Estoque**
    - **Descrição**: Adicione uma funcionalidade para repor automaticamente o estoque de produtos com baixo estoque.
    - **Código**:
      ```csharp
      public class InventoryService : IInventoryService
      {
          private readonly IProductRepository _productRepository;

          public InventoryService(IProductRepository productRepository)
          {
              _productRepository = productRepository;
          }

          public async Task ReplenishStockAsync()
          {
              var lowStockProducts = await _productRepository.GetLowStockAsync(10); // threshold de exemplo
              foreach (var product in lowStockProducts)
              {
                  product.Stock += 50; // quantidade de reposição de exemplo
                  await _productRepository.UpdateAsync(product);
              }
          }
      }
      ```

31. **(21 pontos) Adicionar Funcionalidade de Upload de Imagem de Produtos**
    - **Descrição**: Implemente a funcionalidade de upload de imagem para os produtos.
    - **Código**:
      ```csharp
      [HttpPost("{id}/upload-image")]
      public async Task<IActionResult> UploadImage(int id, IFormFile image)
      {
          if (image == null || image.Length == 0)
          {
              return BadRequest("Invalid image.");
          }

          var filePath = Path.Combine("wwwroot/images", $"{id}.jpg");

          using (var stream = new FileStream(filePath, FileMode.Create))
          {
              await image.CopyToAsync(stream);
          }

          return Ok();
      }
      ```

32. **(34 pontos) Implementar Notificações em Tempo Real usando SignalR**
    - **Descrição**: Adicione suporte para notificações em tempo real usando SignalR para alterações no estoque.
    - **Código**:
      ```csharp
      public class StockHub : Hub
      {
          public async Task SendStockUpdate(string productId, int newStock)
          {
              await Clients.All.SendAsync("ReceiveStockUpdate", productId, newStock);
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSignalR();

      var app = builder.Build();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.MapHub<StockHub>("/stockhub");

      app.MapControllers();

      app.Run();
      ```

33. **(34 pontos) Implementar Auditoria de Mudanças no Estoque**
    - **Descrição**: Adicione uma funcionalidade para auditar todas as mudanças no estoque e registrar logs detalhados.
    - **Código**:
      ```csharp
      public class AuditService : IAuditService
      {
          private readonly IProductRepository _productRepository;
          private readonly ILogger<AuditService> _logger;

          public AuditService(IProductRepository productRepository, ILogger<AuditService> logger)
          {
              _productRepository = productRepository;
              _logger = logger;
          }

          public async Task AuditStockChange(int productId, int oldStock, int newStock)
          {
              var product = await _productRepository.GetByIdAsync(productId);
              _logger.LogInformation($"Product: {product.Name}, Old Stock: {oldStock}, New Stock: {newStock}");
          }
      }
      ```

34. **(21 pontos) Implementar Sistema de Permissões Granulares**
    - **Descrição**: Adicione um sistema de permissões granulares para controlar o acesso a diferentes funcionalidades com base em roles.
    - **Código**:
      ```csharp
      public class PermissionRequirement : IAuthorizationRequirement
      {
          public string Permission { get

; }

          public PermissionRequirement(string permission)
          {
              Permission = permission;
          }
      }

      public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
      {
          protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
          {
              if (context.User.HasClaim(c => c.Type == "Permission" && c.Value == requirement.Permission))
              {
                  context.Succeed(requirement);
              }
              return Task.CompletedTask;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddAuthorization(options =>
      {
          options.AddPolicy("CanManageStock", policy =>
              policy.Requirements.Add(new PermissionRequirement("CanManageStock")));
      });

      builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
      ```

35. **(34 pontos) Implementar Integração com API Externa para Cotação de Preços**
    - **Descrição**: Adicione uma funcionalidade para integrar com uma API externa para obter cotações de preços dos produtos.
    - **Código**:
      ```csharp
      public class PricingService : IPricingService
      {
          private readonly HttpClient _httpClient;

          public PricingService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task<decimal> GetProductPriceAsync(string productId)
          {
              var response = await _httpClient.GetAsync($"https://api.pricing.com/products/{productId}");
              response.EnsureSuccessStatusCode();

              var content = await response.Content.ReadAsStringAsync();
              var price = JsonConvert.DeserializeObject<decimal>(content);

              return price;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<IPricingService, PricingService>(client =>
      {
          client.BaseAddress = new Uri("https://api.pricing.com/");
      });
      ```

36. **(21 pontos) Adicionar Funcionalidade de Filtragem Avançada nos Relatórios**
    - **Descrição**: Implemente a funcionalidade de filtragem avançada nos relatórios de produtos.
    - **Código**:
      ```csharp
      [HttpGet("filtered")]
      public async Task<ActionResult<IEnumerable<Product>>> GetFiltered([FromQuery] string name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
      {
          var products = await _productRepository.GetFilteredAsync(name, minPrice, maxPrice);
          return Ok(products);
      }
      ```

37. **(21 pontos) Adicionar Funcionalidade de Backup Automático do Banco de Dados**
    - **Descrição**: Implemente a funcionalidade de backup automático do banco de dados para garantir a segurança dos dados.
    - **Código**:
      ```csharp
      public class BackupService : IBackupService
      {
          private readonly string _backupPath;

          public BackupService(IConfiguration configuration)
          {
              _backupPath = configuration["BackupPath"];
          }

          public void BackupDatabase()
          {
              var backupFile = Path.Combine(_backupPath, $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak");
              // Implementação do backup do banco de dados
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IBackupService, BackupService>();
      ```

38. **(21 pontos) Adicionar Função de Importação de Dados em Massa**
    - **Descrição**: Adicione a funcionalidade para importar dados de produtos em massa a partir de um arquivo CSV.
    - **Código**:
      ```csharp
      [HttpPost("import")]
      public async Task<IActionResult> ImportFromCsv(IFormFile file)
      {
          if (file == null || file.Length == 0)
          {
              return BadRequest("Invalid file.");
          }

          using (var stream = new StreamReader(file.OpenReadStream()))
          {
              while (!stream.EndOfStream)
              {
                  var line = await stream.ReadLineAsync();
                  var values = line.Split(',');

                  var product = new Product
                  {
                      Name = values[0],
                      Description = values[1],
                      Price = decimal.Parse(values[2]),
                      Stock = int.Parse(values[3])
                  };

                  await _productRepository.AddAsync(product);
              }
          }

          return Ok();
      }
      ```

39. **(21 pontos) Implementar Sistema de Notificações por Email**
    - **Descrição**: Adicione um sistema de notificações por email para alertar sobre eventos importantes como baixo estoque.
    - **Código**:
      ```csharp
      public class EmailNotificationService : IEmailNotificationService
      {
          private readonly SmtpClient _smtpClient;

          public EmailNotificationService(SmtpClient smtpClient)
          {
              _smtpClient = smtpClient;
          }

          public void SendLowStockAlert(string emailAddress, string productName)
          {
              var mailMessage = new MailMessage("noreply@stockapp.com", emailAddress)
              {
                  Subject = "Low Stock Alert",
                  Body = $"The product {productName} is low on stock."
              };

              _smtpClient.Send(mailMessage);
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IEmailNotificationService, EmailNotificationService>();
      ```

40. **(34 pontos) Implementar Sistema de Relatórios com Gráficos**
    - **Descrição**: Adicione uma funcionalidade para gerar relatórios gráficos de estoque e vendas.
    - **Código**:
      ```csharp
      public class ReportService : IReportService
      {
          public byte[] GenerateStockReport()
          {
              var chart = new Chart
              {
                  Width = 600,
                  Height = 400,
                  RenderType = RenderType.ImageTag,
                  ChartAreas = { new ChartArea() }
              };

              var series = new Series
              {
                  Name = "Stock",
                  ChartType = SeriesChartType.Bar
              };

              // Adicionar dados ao gráfico
              chart.Series.Add(series);

              using (var stream = new MemoryStream())
              {
                  chart.SaveImage(stream, ChartImageFormat.Png);
                  return stream.ToArray();
              }
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IReportService, ReportService>();
      ```

41. **(34 pontos) Implementar Funcionalidade de Avaliação de Produtos pelos Clientes**
    - **Descrição**: Adicione uma funcionalidade para que os clientes possam avaliar os produtos.
    - **Código**:
      ```csharp
      public class Review
      {
          public int Id { get; set; }
          public int ProductId { get; set; }
          public string UserId { get; set; }
          public int Rating { get; set; }
          public string Comment { get; set; }
          public DateTime Date { get; set; }
      }

      [HttpPost("{productId}/review")]
      public async Task<IActionResult> AddReview(int productId, [FromBody] Review review)
      {
          review.ProductId = productId;
          review.Date = DateTime.Now;

          await _reviewRepository.AddAsync(review);
          return Ok();
      }
      ```

42. **(34 pontos) Implementar Sistema de Busca Avançada**
    - **Descrição**: Adicione uma funcionalidade de busca avançada com suporte a filtros e ordenação.
    - **Código**:
      ```csharp
      [HttpGet("search")]
      public async Task<ActionResult<IEnumerable<Product>>> Search([FromQuery] string query, [FromQuery] string sortBy, [FromQuery] bool descending)
      {
          var products = await _productRepository.SearchAsync(query, sortBy, descending);
          return Ok(products);
      }
      ```

43. **(34 pontos) Implementar Sistema de Recomendação de Produtos**
    - **Descrição**: Adicione uma funcionalidade de recomendação de produtos baseada no histórico de compras dos clientes.
    - **Código**:
      ```csharp
      public class RecommendationService : IRecommendationService
      {
          private readonly IOrderRepository _orderRepository;

          public RecommendationService(IOrderRepository orderRepository)
          {
              _orderRepository = orderRepository;
          }

          public async Task<IEnumerable<Product>> GetRecommendationsAsync(string userId)
          {
              var userOrders = await _orderRepository.GetByUserIdAsync(userId);
              var recommendedProducts = userOrders.SelectMany(order => order.Products)
                                                  .GroupBy(product => product.Id)
                                                  .OrderByDescending(group => group.Count())
                                                  .Select(group => group.First())
                                                  .Take(5);

              return recommendedProducts;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IRecommendationService, RecommendationService>();
      ```

44. **(34 pontos) Implementar Funcionalidade de Carrinho de Compras**
    - **Descrição**: Adicione uma funcionalidade de carrinho de compras para os clientes.
    - **Código**:
      ```csharp
      public class CartItem
      {
          public int ProductId { get; set; }
          public int Quantity { get; set; }
      }

      [HttpPost("cart")]
      public async Task<IActionResult> AddToCart([FromBody] CartItem cartItem)
      {
          await _cartService.AddToCartAsync(cartItem);
          return Ok();
      }
      ```

45. **(34 pontos) Implementar Checkout e Processamento de Pagamentos**
    - **Descrição**: Adicione uma funcionalidade de checkout e integração com um serviço de processamento de pagamentos.
    - **Código**:
      ```csharp
      public class CheckoutService : ICheckoutService
      {
          private readonly IPaymentGateway _paymentGateway;

          public CheckoutService(IPaymentGateway paymentGateway)
          {
             

 _paymentGateway = paymentGateway;
          }

          public async Task<PaymentResult> ProcessCheckoutAsync(CheckoutRequest checkoutRequest)
          {
              // Processar o pagamento
              var paymentResult = await _paymentGateway.ProcessPaymentAsync(checkoutRequest.PaymentDetails);
              return paymentResult;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ICheckoutService, CheckoutService>();
      ```

46. **(3 pontos) Adicionar Comentários XML na API**
    - **Descrição**: Adicione comentários XML nos controladores e métodos da API para melhorar a documentação e o Swagger.
    - **Código**:
      ```csharp
      /// <summary>
      /// Obtém todos os produtos.
      /// </summary>
      /// <returns>Lista de produtos.</returns>
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Product>>> GetAll()
      {
          var products = await _productRepository.GetAllAsync();
          return Ok(products);
      }
      ```

47. **(3 pontos) Configurar Taxa de Limitação (Rate Limiting)**
    - **Descrição**: Implemente uma política de limitação de taxa para controlar a quantidade de requisições.
    - **Código**:
      ```csharp
      builder.Services.AddRateLimiter(options =>
      {
          options.GlobalLimiter = RateLimitPartition.GetFixedWindowLimiter(_ => RateLimitPolicies.PermitLimit(100, TimeSpan.FromMinutes(1)));
      });
      ```

48. **(5 pontos) Adicionar Cache de Respostas HTTP**
    - **Descrição**: Configure o cache de respostas HTTP para melhorar o desempenho.
    - **Código**:
      ```csharp
      [HttpGet]
      [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
      public async Task<ActionResult<IEnumerable<Product>>> GetAll()
      {
          var products = await _productRepository.GetAllAsync();
          return Ok(products);
      }
      ```

49. **(5 pontos) Implementar Suporte a Internacionalização (i18n)**
    - **Descrição**: Adicione suporte a internacionalização para permitir a tradução da API em diferentes idiomas.
    - **Código**:
      ```csharp
      builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

      var app = builder.Build();

      app.UseRequestLocalization(new RequestLocalizationOptions
      {
          DefaultRequestCulture = new RequestCulture("en-US"),
          SupportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("pt-BR") },
          SupportedUICultures = new[] { new CultureInfo("en-US"), new CultureInfo("pt-BR") }
      });
      ```

50. **(8 pontos) Adicionar Log de Auditoria de Usuários**
    - **Descrição**: Implemente logs detalhados de auditoria para ações de usuários, incluindo login e alterações de dados.
    - **Código**:
      ```csharp
      public class UserAuditService : IUserAuditService
      {
          private readonly ILogger<UserAuditService> _logger;

          public UserAuditService(ILogger<UserAuditService> logger)
          {
              _logger = logger;
          }

          public void LogUserAction(string username, string action)
          {
              _logger.LogInformation($"User: {username} performed action: {action} at {DateTime.UtcNow}");
          }
      }
      ```

51. **(8 pontos) Implementar Recuperação de Senha**
    - **Descrição**: Adicione uma funcionalidade para recuperação de senha via email.
    - **Código**:
      ```csharp
      [HttpPost("forgot-password")]
      public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
      {
          var user = await _userRepository.GetByUsernameAsync(forgotPasswordDto.Username);
          if (user == null)
          {
              return NotFound("User not found");
          }

          var resetToken = GenerateResetToken();
          // Enviar email com token de redefinição de senha

          return Ok();
      }

      private string GenerateResetToken()
      {
          // Implementação da geração de token
          return Guid.NewGuid().ToString();
      }
      ```

52. **(8 pontos) Adicionar Autenticação com Redes Sociais**
    - **Descrição**: Implemente autenticação usando provedores de redes sociais como Google e Facebook.
    - **Código**:
      ```csharp
      builder.Services.AddAuthentication()
          .AddGoogle(options =>
          {
              options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
              options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
          })
          .AddFacebook(options =>
          {
              options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
              options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
          });
      ```

53. **(13 pontos) Implementar Testes de Carga (Load Testing)**
    - **Descrição**: Configure e execute testes de carga para avaliar o desempenho da API sob condições de alta carga.
    - **Ferramentas**: Utilize ferramentas como Apache JMeter ou locust.io para executar os testes.

54. **(13 pontos) Adicionar Funcionalidade de Webhook**
    - **Descrição**: Implemente uma funcionalidade de webhook para notificar sistemas externos sobre eventos importantes.
    - **Código**:
      ```csharp
      [HttpPost("webhook")]
      public async Task<IActionResult> Webhook([FromBody] WebhookDto webhookDto)
      {
          // Implementação da lógica de webhook
          return Ok();
      }
      ```

55. **(13 pontos) Implementar Suporte a GraphQL**
    - **Descrição**: Adicione suporte a GraphQL para consultas mais flexíveis e eficientes.
    - **Código**:
      ```csharp
      builder.Services.AddGraphQLServer()
          .AddQueryType<Query>()
          .AddMutationType<Mutation>();

      public class Query
      {
          public IQueryable<Product> GetProducts([Service] IProductRepository productRepository) => productRepository.GetAll();
      }
      ```

56. **(21 pontos) Implementar Análise de Sentimento para Avaliações de Produtos**
    - **Descrição**: Adicione uma funcionalidade para analisar o sentimento das avaliações dos produtos.
    - **Código**:
      ```csharp
      public class SentimentAnalysisService : ISentimentAnalysisService
      {
          public string AnalyzeSentiment(string review)
          {
              // Implementação da análise de sentimento
              return "Positive"; // Exemplo de retorno
          }
      }
      ```

57. **(21 pontos) Implementar Integração com Serviço de Mensagens (SMS)**
    - **Descrição**: Adicione suporte para envio de mensagens SMS para notificações críticas.
    - **Código**:
      ```csharp
      public class SmsService : ISmsService
      {
          private readonly string _smsApiUrl;

          public SmsService(IConfiguration configuration)
          {
              _smsApiUrl = configuration["SmsApiUrl"];
          }

          public async Task SendSmsAsync(string phoneNumber, string message)
          {
              // Implementação do envio de SMS
          }
      }
      ```

58. **(21 pontos) Adicionar Funcionalidade de Pesquisa de Texto Completo**
    - **Descrição**: Implemente uma funcionalidade de pesquisa de texto completo para melhorar a busca de produtos.
    - **Ferramentas**: Utilize o ElasticSearch ou o Azure Cognitive Search para implementar essa funcionalidade.

59. **(21 pontos) Implementar Sistema de Backup Incremental**
    - **Descrição**: Adicione um sistema de backup incremental para reduzir o tempo e os recursos necessários para backups.
    - **Código**:
      ```csharp
      public class IncrementalBackupService : IBackupService
      {
          public void PerformBackup()
          {
              // Implementação do backup incremental
          }
      }
      ```

60. **(21 pontos) Adicionar Funcionalidade de Agendamento de Tarefas**
    - **Descrição**: Implemente uma funcionalidade para agendamento de tarefas recorrentes.
    - **Ferramentas**: Utilize Quartz.NET para implementar o agendamento de tarefas.

61. **(34 pontos) Implementar Integração com ERP Externo**
    - **Descrição**: Adicione integração com um sistema ERP externo para sincronizar dados de produtos e estoque.
    - **Código**:
      ```csharp
      public class ErpIntegrationService : IErpIntegrationService
      {
          private readonly HttpClient _httpClient;

          public ErpIntegrationService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task SyncDataAsync()
          {
              var response = await _httpClient.GetAsync("https://erp.external.com/api/products");
              response.EnsureSuccessStatusCode();

              var products = await response.Content.ReadAsAsync<List<Product>>();
              // Sincronizar dados com o banco de dados local
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<IErpIntegrationService, ErpIntegrationService>();
      ```

62. **(34 pontos) Implementar Controle de Acesso Baseado em Claims**
    - **Descrição**: Adicione um sistema de controle de acesso baseado em claims para gerenciar permissões detalhadas.
    - **Código**:
      ```csharp
      public class ClaimsAuthorizationRequirement : IAuthorizationRequirement
      {
          public string ClaimType { get; }
          public string ClaimValue { get; }

          public ClaimsAuthorizationRequirement(string claimType, string claimValue)
         

 {
              ClaimType = claimType;
              ClaimValue = claimValue;
          }
      }

      public class ClaimsAuthorizationHandler : AuthorizationHandler<ClaimsAuthorizationRequirement>
      {
          protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
          {
              if (context.User.HasClaim(c => c.Type == requirement.ClaimType && c.Value == requirement.ClaimValue))
              {
                  context.Succeed(requirement);
              }
              return Task.CompletedTask;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddAuthorization(options =>
      {
          options.AddPolicy("CanManageProducts", policy =>
              policy.Requirements.Add(new ClaimsAuthorizationRequirement("Permission", "CanManageProducts")));
      });

      builder.Services.AddSingleton<IAuthorizationHandler, ClaimsAuthorizationHandler>();
      ```

63. **(34 pontos) Implementar Funcionalidade de Comparação de Produtos**
    - **Descrição**: Adicione uma funcionalidade para permitir que os usuários comparem diferentes produtos.
    - **Código**:
      ```csharp
      [HttpPost("compare")]
      public async Task<ActionResult<IEnumerable<Product>>> CompareProducts([FromBody] List<int> productIds)
      {
          var products = await _productRepository.GetByIdsAsync(productIds);
          return Ok(products);
      }
      ```

64. **(34 pontos) Implementar Mecanismo de Cache Distribuído com Redis**
    - **Descrição**: Adicione suporte para cache distribuído usando Redis, melhorando a escalabilidade.
    - **Código**:
      ```csharp
      builder.Services.AddStackExchangeRedisCache(options =>
      {
          options.Configuration = builder.Configuration.GetConnectionString("Redis");
      });
      ```

65. **(34 pontos) Implementar Sistema de Recomendação Personalizada usando Machine Learning**
    - **Descrição**: Adicione uma funcionalidade de recomendação personalizada usando modelos de machine learning.
    - **Ferramentas**: Utilize bibliotecas como ML.NET ou TensorFlow.NET para treinar e implementar o modelo de recomendação.

66. **(34 pontos) Implementar Monitoramento e Alertas com Prometheus e Grafana**
    - **Descrição**: Configure monitoramento e alertas usando Prometheus e Grafana para monitorar a saúde do sistema.
    - **Código**:
      ```yaml
      # Configuração de exemplo para Prometheus
      global:
        scrape_interval: 15s

      scrape_configs:
        - job_name: 'aspnetcore'
          static_configs:
            - targets: ['localhost:5000']
      ```

67. **(34 pontos) Implementar Sistema de Workflow**
    - **Descrição**: Adicione um sistema de workflow para gerenciar processos de negócios complexos.
    - **Ferramentas**: Utilize ferramentas como Workflow Core para implementar o sistema de workflow.

68. **(55 pontos) Implementar Análise Preditiva de Vendas**
    - **Descrição**: Adicione uma funcionalidade para análise preditiva de vendas usando algoritmos de machine learning.
    - **Ferramentas**: Utilize ML.NET ou Azure Machine Learning para treinar modelos de previsão de vendas.
    - **Código**:
      ```csharp
      public class SalesPredictionService : ISalesPredictionService
      {
          public double PredictSales(int productId, int month, int year)
          {
              // Implementação da previsão de vendas usando modelo de machine learning
              return 1000.0; // Exemplo de retorno
          }
      }
      ```

69. **(55 pontos) Implementar Gestão de Inventário Just-in-Time**
    - **Descrição**: Adicione uma funcionalidade para gestão de inventário just-in-time, otimizando o estoque com base na demanda.
    - **Código**:
      ```csharp
      public class JustInTimeInventoryService : IJustInTimeInventoryService
      {
          public async Task OptimizeInventoryAsync()
          {
              // Implementação da otimização de inventário just-in-time
          }
      }
      ```

70. **(55 pontos) Implementar Sistema de Feedback com Análise de Sentimento**
    - **Descrição**: Adicione um sistema de feedback para clientes com análise de sentimento para avaliar a satisfação.
    - **Código**:
      ```csharp
      public class FeedbackService : IFeedbackService
      {
          private readonly ISentimentAnalysisService _sentimentAnalysisService;

          public FeedbackService(ISentimentAnalysisService sentimentAnalysisService)
          {
              _sentimentAnalysisService = sentimentAnalysisService;
          }

          public async Task SubmitFeedbackAsync(string userId, string feedback)
          {
              var sentiment = _sentimentAnalysisService.AnalyzeSentiment(feedback);
              // Armazenar feedback com o resultado da análise de sentimento
          }
      }
      ```

71. **(3 pontos) Criar Classe `Supplier` no Domínio**
    - **Descrição**: Adicione uma classe `Supplier` na camada `Domain` para representar os fornecedores.
    - **Código**:
      ```csharp
      public class Supplier
      {
          public int Id { get; set; }
          public string Name { get; set; }
          public string ContactEmail { get; set; }
          public string PhoneNumber { get; set; }
      }
      ```

72. **(3 pontos) Criar Interface de Repositório para `Supplier`**
    - **Descrição**: Crie uma interface de repositório para `Supplier` na camada `Domain`.
    - **Código**:
      ```csharp
      public interface ISupplierRepository
      {
          Task<Supplier> GetByIdAsync(int id);
          Task<IEnumerable<Supplier>> GetAllAsync();
          Task AddAsync(Supplier supplier);
          Task UpdateAsync(Supplier supplier);
          Task DeleteAsync(int id);
      }
      ```

73. **(3 pontos) Implementar Repositório `Supplier` na Camada `Infra.Data`**
    - **Descrição**: Implemente o repositório `Supplier` na camada `Infra.Data` utilizando Entity Framework.
    - **Código**:
      ```csharp
      public class SupplierRepository : ISupplierRepository
      {
          private readonly AppDbContext _context;

          public SupplierRepository(AppDbContext context)
          {
              _context = context;
          }

          public async Task<Supplier> GetByIdAsync(int id)
          {
              return await _context.Suppliers.FindAsync(id);
          }

          public async Task<IEnumerable<Supplier>> GetAllAsync()
          {
              return await _context.Suppliers.ToListAsync();
          }

          public async Task AddAsync(Supplier supplier)
          {
              _context.Suppliers.Add(supplier);
              await _context.SaveChangesAsync();
          }

          public async Task UpdateAsync(Supplier supplier)
          {
              _context.Suppliers.Update(supplier);
              await _context.SaveChangesAsync();
          }

          public async Task DeleteAsync(int id)
          {
              var supplier = await _context.Suppliers.FindAsync(id);
              if (supplier != null)
              {
                  _context.Suppliers.Remove(supplier);
                  await _context.SaveChangesAsync();
              }
          }
      }
      ```

74. **(5 pontos) Criar Controlador `SuppliersController`**
    - **Descrição**: Crie um controlador `SuppliersController` para gerenciar os fornecedores.
    - **Código**:
      ```csharp
      [ApiController]
      [Route("api/[controller]")]
      public class SuppliersController : ControllerBase
      {
          private readonly ISupplierRepository _supplierRepository;

          public SuppliersController(ISupplierRepository supplierRepository)
          {
              _supplierRepository = supplierRepository;
          }

          [HttpGet]
          public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
          {
              var suppliers = await _supplierRepository.GetAllAsync();
              return Ok(suppliers);
          }

          [HttpGet("{id}")]
          public async Task<ActionResult<Supplier>> GetById(int id)
          {
              var supplier = await _supplierRepository.GetByIdAsync(id);
              if (supplier == null)
              {
                  return NotFound();
              }
              return Ok(supplier);
          }

          [HttpPost]
          public async Task<ActionResult<Supplier>> Create(Supplier supplier)
          {
              await _supplierRepository.AddAsync(supplier);
              return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
          }

          [HttpPut("{id}")]
          public async Task<IActionResult> Update(int id, Supplier supplier)
          {
              if (id != supplier.Id)
              {
                  return BadRequest();
              }

              await _supplierRepository.UpdateAsync(supplier);
              return NoContent();
          }

          [HttpDelete("{id}")]
          public async Task<IActionResult> Delete(int id)
          {
              await _supplierRepository.DeleteAsync(id);
              return NoContent();
          }
      }
      ```

75. **(8 pontos) Criar Procedure em MySQL para Relatório de Vendas**
    - **Descrição**: Crie uma procedure em MySQL que gera um relatório de vendas.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE PROCEDURE GetSalesReport()
      BEGIN
          SELECT p.Name, SUM(o.Quantity) AS TotalSold, SUM(o.Quantity * p.Price) AS TotalRevenue
          FROM Orders o
          JOIN Products p ON o.ProductId = p.Id
          GROUP BY p.Name;
      END //
      DELIMITER ;
      ```

76. **(8 pontos) Criar Endpoint para Chamar Procedure de Relatório de Vendas**
    - **Descrição**: Crie um endpoint para chamar a procedure `GetSalesReport` e retornar os resultados.
    - **Código**:
      ```csharp
      [HttpGet("sales-report")]
      public async Task<IActionResult> GetSalesReport()
      {
          var connectionString = _configuration.GetConnectionString("DefaultConnection");
          using (var connection = new MySqlConnection(connectionString))
          {
              await connection.OpenAsync();
              using (var command = new MySqlCommand("GetSalesReport", connection))
              {
                  command.CommandType = CommandType.StoredProcedure;
                  using (var reader = await command.ExecuteReaderAsync())
                  {
                      var salesReport = new List<SalesReportDto>();
                      while (await reader.ReadAsync())
                      {
                          salesReport.Add(new SalesReportDto
                          {
                              ProductName = reader.GetString("Name"),
                              TotalSold = reader.GetInt32("TotalSold"),
                              TotalRevenue = reader.GetDecimal("TotalRevenue")
                          });
                      }
                      return Ok(salesReport);
                  }
              }
          }
      }
      ```

77. **(8 pontos) Criar Triggers para Atualização Automática de Estoque**
    - **Descrição**: Crie triggers em MySQL para atualizar automaticamente o estoque quando um pedido for inserido ou deletado.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE TRIGGER AfterOrderInsert
      AFTER INSERT ON Orders
      FOR EACH ROW
      BEGIN
          UPDATE Products
          SET Stock = Stock - NEW.Quantity
          WHERE Id = NEW.ProductId;
      END //

      CREATE TRIGGER AfterOrderDelete
      AFTER DELETE ON Orders
      FOR EACH ROW
      BEGIN
          UPDATE Products
          SET Stock = Stock + OLD.Quantity
          WHERE Id = OLD.ProductId;
      END //
      DELIMITER ;
      ```

78. **(13 pontos) Criar Dashboard de Vendas**
    - **Descrição**: Implemente um endpoint que retorna dados para um dashboard de vendas, agregando informações relevantes.
    - **Código**:
      ```csharp
      [HttpGet("dashboard-sales")]
      public async Task<IActionResult> GetDashboardSalesData()
      {
          var dashboardData = new DashboardSalesDto
          {
              TotalSales = await _context.Orders.SumAsync(o => o.Quantity * o.Price),
              TotalOrders = await _context.Orders.CountAsync(),
              TopSellingProducts = await _context.Products
                  .OrderByDescending(p => p.Orders.Sum(o => o.Quantity))
                  .Take(5)
                  .Select(p => new ProductSalesDto
                  {
                      ProductName = p.Name,
                      TotalSold = p.Orders.Sum(o => o.Quantity)
                  })
                  .ToListAsync()
          };

          return Ok(dashboardData);
      }
      ```

79. **(13 pontos) Implementar Funcionalidade de Busca por Fornecedores**
    - **Descrição**: Adicione uma funcionalidade de busca avançada para fornecedores com filtros.
    - **Código**:
      ```csharp
      [HttpGet("search")]
      public async Task<ActionResult<IEnumerable<Supplier>>> SearchSuppliers([FromQuery] string name, [FromQuery] string contactEmail)
      {
          var suppliers = await _supplierRepository.SearchAsync(name, contactEmail);
          return Ok(suppliers);
      }
      ```

80. **(13 pontos) Criar Procedure em MySQL para Relatório de Estoque**
    - **Descrição**: Crie uma procedure em MySQL que gera um relatório de estoque.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE PROCEDURE GetStockReport()
      BEGIN
          SELECT p.Name, p.Stock
          FROM Products p;
      END //
      DELIMITER ;
      ```

81. **(13 pontos) Criar Endpoint para Chamar Procedure de Relatório de Estoque**
    - **Descrição**: Crie um endpoint para chamar a procedure `GetStockReport` e retornar os resultados.
    - **Código**:
      ```csharp
      [HttpGet("stock-report")]
      public async Task<IActionResult> GetStockReport()
      {
          var connectionString = _configuration.GetConnectionString("DefaultConnection");
          using (var connection = new MySqlConnection(connectionString))
          {
              await connection.OpenAsync();
              using (var command = new MySqlCommand("GetStockReport", connection))
              {
                  command.CommandType = CommandType.StoredProcedure;
                  using (var reader = await command.ExecuteReaderAsync

())
                  {
                      var stockReport = new List<StockReportDto>();
                      while (await reader.ReadAsync())
                      {
                          stockReport.Add(new StockReportDto
                          {
                              ProductName = reader.GetString("Name"),
                              Stock = reader.GetInt32("Stock")
                          });
                      }
                      return Ok(stockReport);
                  }
              }
          }
      }
      ```

82. **(13 pontos) Implementar Sistema de Notificações Push**
    - **Descrição**: Adicione suporte para notificações push, alertando os usuários sobre eventos importantes.
    - **Código**:
      ```csharp
      public class PushNotificationService : IPushNotificationService
      {
          public async Task SendNotificationAsync(string message)
          {
              // Implementação do envio de notificações push
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IPushNotificationService, PushNotificationService>();
      ```

83. **(13 pontos) Criar Dashboard de Estoque**
    - **Descrição**: Implemente um endpoint que retorna dados para um dashboard de estoque, agregando informações relevantes.
    - **Código**:
      ```csharp
      [HttpGet("dashboard-stock")]
      public async Task<IActionResult> GetDashboardStockData()
      {
          var dashboardData = new DashboardStockDto
          {
              TotalProducts = await _context.Products.CountAsync(),
              TotalStockValue = await _context.Products.SumAsync(p => p.Stock * p.Price),
              LowStockProducts = await _context.Products
                  .Where(p => p.Stock < 10)
                  .Select(p => new ProductStockDto
                  {
                      ProductName = p.Name,
                      Stock = p.Stock
                  })
                  .ToListAsync()
          };

          return Ok(dashboardData);
      }
      ```

84. **(13 pontos) Implementar Funcionalidade de Busca por Produtos**
    - **Descrição**: Adicione uma funcionalidade de busca avançada para produtos com filtros.
    - **Código**:
      ```csharp
      [HttpGet("search")]
      public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery] string name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
      {
          var products = await _productRepository.SearchAsync(name, minPrice, maxPrice);
          return Ok(products);
      }
      ```

85. **(21 pontos) Criar Procedure em MySQL para Relatório de Compras**
    - **Descrição**: Crie uma procedure em MySQL que gera um relatório de compras.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE PROCEDURE GetPurchaseReport()
      BEGIN
          SELECT s.Name AS SupplierName, SUM(p.Quantity) AS TotalPurchased
          FROM Purchases p
          JOIN Suppliers s ON p.SupplierId = s.Id
          GROUP BY s.Name;
      END //
      DELIMITER ;
      ```

86. **(21 pontos) Criar Endpoint para Chamar Procedure de Relatório de Compras**
    - **Descrição**: Crie um endpoint para chamar a procedure `GetPurchaseReport` e retornar os resultados.
    - **Código**:
      ```csharp
      [HttpGet("purchase-report")]
      public async Task<IActionResult> GetPurchaseReport()
      {
          var connectionString = _configuration.GetConnectionString("DefaultConnection");
          using (var connection = new MySqlConnection(connectionString))
          {
              await connection.OpenAsync();
              using (var command = new MySqlCommand("GetPurchaseReport", connection))
              {
                  command.CommandType = CommandType.StoredProcedure;
                  using (var reader = await command.ExecuteReaderAsync())
                  {
                      var purchaseReport = new List<PurchaseReportDto>();
                      while (await reader.ReadAsync())
                      {
                          purchaseReport.Add(new PurchaseReportDto
                          {
                              SupplierName = reader.GetString("SupplierName"),
                              TotalPurchased = reader.GetInt32("TotalPurchased")
                          });
                      }
                      return Ok(purchaseReport);
                  }
              }
          }
      }
      ```

87. **(21 pontos) Criar Trigger para Registro de Auditoria de Compras**
    - **Descrição**: Crie um trigger em MySQL para registrar auditoria de compras.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE TRIGGER AfterPurchaseInsert
      AFTER INSERT ON Purchases
      FOR EACH ROW
      BEGIN
          INSERT INTO PurchaseAudit (PurchaseId, SupplierId, Quantity, PurchaseDate)
          VALUES (NEW.Id, NEW.SupplierId, NEW.Quantity, NEW.PurchaseDate);
      END //
      DELIMITER ;
      ```

88. **(21 pontos) Implementar Sistema de Cálculo de Impostos**
    - **Descrição**: Adicione um sistema para calcular impostos sobre as vendas.
    - **Código**:
      ```csharp
      public class TaxService : ITaxService
      {
          public decimal CalculateTax(decimal amount)
          {
              // Implementação do cálculo de impostos
              return amount * 0.15M; // Exemplo de taxa de imposto de 15%
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ITaxService, TaxService>();
      ```

89. **(21 pontos) Criar Endpoint para Relatório de Impostos**
    - **Descrição**: Implemente um endpoint para gerar um relatório de impostos sobre as vendas.
    - **Código**:
      ```csharp
      [HttpGet("tax-report")]
      public async Task<IActionResult> GetTaxReport()
      {
          var sales = await _context.Orders.ToListAsync();
          var taxReport = sales.Select(s => new TaxReportDto
          {
              OrderId = s.Id,
              TaxAmount = _taxService.CalculateTax(s.TotalAmount)
          }).ToList();

          return Ok(taxReport);
      }
      ```

90. **(21 pontos) Criar Sistema de Descontos e Promoções**
    - **Descrição**: Adicione um sistema para aplicar descontos e promoções nos produtos.
    - **Código**:
      ```csharp
      public class DiscountService : IDiscountService
      {
          public decimal ApplyDiscount(decimal price, decimal discountPercentage)
          {
              return price - (price * discountPercentage / 100);
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IDiscountService, DiscountService>();
      ```

91. **(34 pontos) Implementar Integração com Serviço de Entrega**
    - **Descrição**: Adicione integração com um serviço de entrega para calcular o frete e rastrear pedidos.
    - **Código**:
      ```csharp
      public class DeliveryService : IDeliveryService
      {
          private readonly HttpClient _httpClient;

          public DeliveryService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task<DeliveryInfo> GetDeliveryInfoAsync(string trackingNumber)
          {
              var response = await _httpClient.GetAsync($"https://api.delivery.com/track/{trackingNumber}");
              response.EnsureSuccessStatusCode();

              var content = await response.Content.ReadAsStringAsync();
              var deliveryInfo = JsonConvert.DeserializeObject<DeliveryInfo>(content);

              return deliveryInfo;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<IDeliveryService, DeliveryService>(client =>
      {
          client.BaseAddress = new Uri("https://api.delivery.com/");
      });
      ```

92. **(34 pontos) Implementar Sistema de Reviews com Moderação**
    - **Descrição**: Adicione um sistema para moderação de reviews dos produtos pelos clientes.
    - **Código**:
      ```csharp
      public class ReviewModerationService : IReviewModerationService
      {
          public bool ModerateReview(string review)
          {
              // Implementação da moderação de reviews
              return !review.Contains("inapropriado");
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IReviewModerationService, ReviewModerationService>();
      ```

93. **(34 pontos) Criar Dashboard de Compras**
    - **Descrição**: Implemente um endpoint que retorna dados para um dashboard de compras, agregando informações relevantes.
    - **Código**:
      ```csharp
      [HttpGet("dashboard-purchases")]
      public async Task<IActionResult> GetDashboardPurchasesData()
      {
          var dashboardData = new DashboardPurchasesDto
          {
              TotalPurchases = await _context.Purchases.CountAsync(),
              TotalSpent = await _context.Purchases.SumAsync(p => p.Quantity * p.Price),
              TopSuppliers = await _context.Suppliers
                  .OrderByDescending(s => s.Purchases.Sum(p => p.Quantity))
                  .Take(5)
                  .Select(s => new SupplierPurchasesDto
                  {
                      SupplierName = s.Name,
                      TotalPurchased = s.Purchases.Sum(p => p.Quantity)
                  })
                  .ToListAsync()
          };

          return Ok(dashboardData);
      }
      ```

94. **(34 pontos) Implementar Sistema de Alertas Personalizados**
    - **Descrição**: Adicione um sistema para alertar os usuários sobre eventos importantes personalizados.
    - **Código**:
      ```csharp
      public class AlertService : IAlertService
      {
          public async Task SendAlertAsync(string userId, string message)
          {
              // Implementação do envio de alertas personalizados
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IAlertService, AlertService>();
      ```

95. **(34 pontos) Criar Procedure em MySQL para Relatório de Lucros**
    - **Descrição**: Crie uma procedure em MySQL que gera um relatório



 de lucros.
    - **Código**:
      ```sql
      DELIMITER //
      CREATE PROCEDURE GetProfitReport()
      BEGIN
          SELECT p.Name, SUM(o.Quantity * (o.Price - p.Cost)) AS TotalProfit
          FROM Orders o
          JOIN Products p ON o.ProductId = p.Id
          GROUP BY p.Name;
      END //
      DELIMITER ;
      ```

96. **(34 pontos) Criar Endpoint para Chamar Procedure de Relatório de Lucros**
    - **Descrição**: Crie um endpoint para chamar a procedure `GetProfitReport` e retornar os resultados.
    - **Código**:
      ```csharp
      [HttpGet("profit-report")]
      public async Task<IActionResult> GetProfitReport()
      {
          var connectionString = _configuration.GetConnectionString("DefaultConnection");
          using (var connection = new MySqlConnection(connectionString))
          {
              await connection.OpenAsync();
              using (var command = new MySqlCommand("GetProfitReport", connection))
              {
                  command.CommandType = CommandType.StoredProcedure;
                  using (var reader = await command.ExecuteReaderAsync())
                  {
                      var profitReport = new List<ProfitReportDto>();
                      while (await reader.ReadAsync())
                      {
                          profitReport.Add(new ProfitReportDto
                          {
                              ProductName = reader.GetString("Name"),
                              TotalProfit = reader.GetDecimal("TotalProfit")
                          });
                      }
                      return Ok(profitReport);
                  }
              }
          }
      }
      ```

97. **(34 pontos) Implementar Sistema de Feedback por SMS**
    - **Descrição**: Adicione um sistema para coletar feedback dos clientes via SMS.
    - **Código**:
      ```csharp
      public class SmsFeedbackService : ISmsFeedbackService
      {
          private readonly ISmsService _smsService;

          public SmsFeedbackService(ISmsService smsService)
          {
              _smsService = smsService;
          }

          public async Task CollectFeedbackAsync(string phoneNumber, string feedback)
          {
              // Implementação da coleta de feedback via SMS
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ISmsFeedbackService, SmsFeedbackService>();
      ```

98. **(34 pontos) Implementar Sistema de Análise de Tendências de Mercado**
    - **Descrição**: Adicione um sistema para análise de tendências de mercado, auxiliando na tomada de decisões estratégicas.
    - **Código**:
      ```csharp
      public class MarketTrendAnalysisService : IMarketTrendAnalysisService
      {
          public async Task<MarketTrendDto> AnalyzeTrendsAsync()
          {
              // Implementação da análise de tendências de mercado
              return new MarketTrendDto
              {
                  Trend = "Aumento nas vendas de produtos eletrônicos",
                  Prediction = "Crescimento de 15% nas próximas semanas"
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IMarketTrendAnalysisService, MarketTrendAnalysisService>();
      ```

99. **(34 pontos) Implementar Funcionalidade de Devolução de Produtos**
    - **Descrição**: Adicione um sistema para gerenciar a devolução de produtos.
    - **Código**:
      ```csharp
      [HttpPost("return")]
      public async Task<IActionResult> ReturnProduct(ReturnProductDto returnProductDto)
      {
          var order = await _context.Orders.FindAsync(returnProductDto.OrderId);
          if (order == null)
          {
              return NotFound("Order not found");
          }

          // Processar devolução de produto
          return Ok();
      }
      ```

100. **(34 pontos) Implementar Integração com Sistema de CRM**
    - **Descrição**: Adicione integração com um sistema CRM para sincronizar dados de clientes.
    - **Código**:
      ```csharp
      public class CrmIntegrationService : ICrmIntegrationService
      {
          private readonly HttpClient _httpClient;

          public CrmIntegrationService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task SyncCustomerDataAsync()
          {
              var response = await _httpClient.GetAsync("https://api.crm.com/customers");
              response.EnsureSuccessStatusCode();

              var content = await response.Content.ReadAsStringAsync();
              var customers = JsonConvert.DeserializeObject<List<Customer>>(content);

              // Sincronizar dados de clientes com o banco de dados local
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<ICrmIntegrationService, CrmIntegrationService>(client =>
      {
          client.BaseAddress = new Uri("https://api.crm.com/");
      });
      ```

101. **(34 pontos) Criar Sistema de Feedback Anônimo**
    - **Descrição**: Adicione um sistema para coletar feedback anônimo dos clientes.
    - **Código**:
      ```csharp
      public class AnonymousFeedbackService : IAnonymousFeedbackService
      {
          public async Task CollectFeedbackAsync(string feedback)
          {
              // Implementação da coleta de feedback anônimo
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IAnonymousFeedbackService, AnonymousFeedbackService>();
      ```

102. **(34 pontos) Implementar Sistema de Métricas de Performance**
    - **Descrição**: Adicione um sistema para medir e monitorar a performance do sistema.
    - **Código**:
      ```csharp
      public class PerformanceMetricsService : IPerformanceMetricsService
      {
          public async Task<PerformanceMetricsDto> GetMetricsAsync()
          {
              // Implementação da coleta de métricas de performance
              return new PerformanceMetricsDto
              {
                  CpuUsage = 75.5,
                  MemoryUsage = 2048,
                  ResponseTime = 250
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IPerformanceMetricsService, PerformanceMetricsService>();
      ```

103. **(34 pontos) Implementar Sistema de Backup em Nuvem**
    - **Descrição**: Adicione um sistema para backup em nuvem, garantindo a segurança dos dados.
    - **Código**:
      ```csharp
      public class CloudBackupService : ICloudBackupService
      {
          public async Task PerformBackupAsync()
          {
              // Implementação do backup em nuvem
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ICloudBackupService, CloudBackupService>();
      ```

104. **(34 pontos) Implementar Sistema de Análise de Desempenho de Vendas**
    - **Descrição**: Adicione um sistema para análise detalhada do desempenho de vendas.
    - **Código**:
      ```csharp
      public class SalesPerformanceAnalysisService : ISalesPerformanceAnalysisService
      {
          public async Task<SalesPerformanceDto> AnalyzePerformanceAsync()
          {
              // Implementação da análise de desempenho de vendas
              return new SalesPerformanceDto
              {
                  TotalSales = 10000,
                  TotalOrders = 200,
                  AverageOrderValue = 50
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ISalesPerformanceAnalysisService, SalesPerformanceAnalysisService>();
      ```

105. **(34 pontos) Implementar Integração com Serviço de Análise de Dados**
    - **Descrição**: Adicione integração com um serviço de análise de dados para gerar insights e relatórios avançados.
    - **Código**:
      ```csharp
      public class DataAnalysisService : IDataAnalysisService
      {
          private readonly HttpClient _httpClient;

          public DataAnalysisService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task<DataAnalysisDto> AnalyzeDataAsync()
          {
              var response = await _httpClient.GetAsync("https://api.dataanalysis.com/analyze");
              response.EnsureSuccessStatusCode();

              var content = await response.Content.ReadAsStringAsync();
              var analysis = JsonConvert.DeserializeObject<DataAnalysisDto>(content);

              return analysis;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<IDataAnalysisService, DataAnalysisService>(client =>
      {
          client.BaseAddress = new Uri("https://api.dataanalysis.com/");
      });
      ```

106. **(34 pontos) Implementar Sistema de Prevenção de Fraude**
    - **Descrição**: Adicione um sistema para detectar e prevenir fraudes nas transações.
    - **Código**:
      ```csharp
      public class FraudDetectionService : IFraudDetectionService
      {
          public async Task<bool> DetectFraudAsync(TransactionDto transaction)
          {
              // Implementação da detecção de fraudes
              return transaction.Amount > 1000; // Exemplo de detecção de fraude
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IFraudDetectionService, FraudDetectionService>();
      ```

107. **(34 pontos) Implementar Sistema de Gestão de Inventário em Tempo Real**
    - **Descrição**: Adicione um sistema para gestão de inventário em tempo real, atualizando instantaneamente as quantidades de produtos.
    - **Código**:
      ```csharp
      public class RealTimeInventoryService : IRealTimeInventoryService
      {
          public async Task UpdateInventoryAsync(int productId, int quantity)
          {
              // Implementação da atualização de inventário em tempo real
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IRealTimeInventoryService, RealTimeInventoryService>();
      ```

108. **(34 pontos) Implementar Sistema de Relatórios Personalizados**
    - **Descrição**: Adicione um sistema para que os

 usuários possam criar e visualizar relatórios personalizados.
    - **Código**:
      ```csharp
      public class CustomReportService : ICustomReportService
      {
          public async Task<CustomReportDto> GenerateReportAsync(ReportParametersDto parameters)
          {
              // Implementação da geração de relatórios personalizados
              return new CustomReportDto
              {
                  Title = "Relatório Personalizado",
                  Data = new List<ReportDataDto>
                  {
                      new ReportDataDto { Key = "TotalVendas", Value = "10000" },
                      new ReportDataDto { Key = "TotalPedidos", Value = "200" }
                  }
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ICustomReportService, CustomReportService>();
      ```

109. **(34 pontos) Implementar Sistema de Gestão de Projetos**
    - **Descrição**: Adicione um sistema para gerenciar projetos internos da empresa, incluindo tarefas e cronogramas.
    - **Código**:
      ```csharp
      public class ProjectManagementService : IProjectManagementService
      {
          public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto)
          {
              // Implementação da criação de projetos
              return new ProjectDto
              {
                  Id = 1,
                  Name = createProjectDto.Name,
                  Description = createProjectDto.Description,
                  StartDate = createProjectDto.StartDate,
                  EndDate = createProjectDto.EndDate
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IProjectManagementService, ProjectManagementService>();
      ```

110. **(34 pontos) Implementar Sistema de Gestão de Recursos Humanos**
    - **Descrição**: Adicione um sistema para gerenciar informações e processos relacionados a recursos humanos.
    - **Código**:
      ```csharp
      public class HumanResourcesService : IHumanResourcesService
      {
          public async Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto)
          {
              // Implementação da adição de funcionários
              return new EmployeeDto
              {
                  Id = 1,
                  Name = createEmployeeDto.Name,
                  Position = createEmployeeDto.Position,
                  Salary = createEmployeeDto.Salary,
                  HireDate = createEmployeeDto.HireDate
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IHumanResourcesService, HumanResourcesService>();
      ```

111. **(34 pontos) Implementar Integração com Serviço de Pagamentos Externo**
    - **Descrição**: Adicione integração com um serviço de pagamentos externo para processar transações.
    - **Código**:
      ```csharp
      public class PaymentIntegrationService : IPaymentIntegrationService
      {
          private readonly HttpClient _httpClient;

          public PaymentIntegrationService(HttpClient httpClient)
          {
              _httpClient = httpClient;
          }

          public async Task<PaymentResultDto> ProcessPaymentAsync(PaymentRequestDto paymentRequest)
          {
              var response = await _httpClient.PostAsJsonAsync("https://api.payment.com/process", paymentRequest);
              response.EnsureSuccessStatusCode();

              var content = await response.Content.ReadAsStringAsync();
              var paymentResult = JsonConvert.DeserializeObject<PaymentResultDto>(content);

              return paymentResult;
          }
      }

      // Configuração no Program.cs
      builder.Services.AddHttpClient<IPaymentIntegrationService, PaymentIntegrationService>(client =>
      {
          client.BaseAddress = new Uri("https://api.payment.com/");
      });
      ```

112. **(34 pontos) Implementar Sistema de Rastreamento de Entregas**
    - **Descrição**: Adicione um sistema para rastrear as entregas dos pedidos dos clientes.
    - **Código**:
      ```csharp
      [HttpGet("track-delivery/{trackingNumber}")]
      public async Task<IActionResult> TrackDelivery(string trackingNumber)
      {
          var deliveryInfo = await _deliveryService.GetDeliveryInfoAsync(trackingNumber);
          if (deliveryInfo == null)
          {
              return NotFound("Delivery not found");
          }
          return Ok(deliveryInfo);
      }
      ```

113. **(34 pontos) Implementar Sistema de Gestão de Inventário**
    - **Descrição**: Adicione um sistema para gerenciar o inventário, incluindo adição, remoção e atualização de produtos.
    - **Código**:
      ```csharp
      public class InventoryManagementService : IInventoryManagementService
      {
          public async Task AddProductAsync(ProductDto product)
          {
              // Implementação da adição de produto ao inventário
          }

          public async Task RemoveProductAsync(int productId)
          {
              // Implementação da remoção de produto do inventário
          }

          public async Task UpdateProductAsync(ProductDto product)
          {
              // Implementação da atualização de produto no inventário
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IInventoryManagementService, InventoryManagementService>();
      ```

114. **(34 pontos) Implementar Sistema de Gestão de Fornecedores**
    - **Descrição**: Adicione um sistema para gerenciar os fornecedores da empresa, incluindo contratos e avaliações.
    - **Código**:
      ```csharp
      public class SupplierManagementService : ISupplierManagementService
      {
          public async Task<SupplierDto> AddSupplierAsync(CreateSupplierDto createSupplierDto)
          {
              // Implementação da adição de fornecedores
              return new SupplierDto
              {
                  Id = 1,
                  Name = createSupplierDto.Name,
                  ContactEmail = createSupplierDto.ContactEmail,
                  PhoneNumber = createSupplierDto.PhoneNumber
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ISupplierManagementService, SupplierManagementService>();
      ```

115. **(34 pontos) Implementar Sistema de Planejamento de Demanda**
    - **Descrição**: Adicione um sistema para planejamento de demanda, prevendo necessidades futuras com base em dados históricos.
    - **Código**:
      ```csharp
      public class DemandPlanningService : IDemandPlanningService
      {
          public async Task<DemandForecastDto> ForecastDemandAsync()
          {
              // Implementação do planejamento de demanda
              return new DemandForecastDto
              {
                  ProductId = 1,
                  ForecastedDemand = 100
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IDemandPlanningService, DemandPlanningService>();
      ```

116. **(34 pontos) Implementar Sistema de Gestão de Relacionamento com Clientes**
    - **Descrição**: Adicione um sistema para gerenciar o relacionamento com clientes, incluindo histórico de interações e preferências.
    - **Código**:
      ```csharp
      public class CustomerRelationshipManagementService : ICustomerRelationshipManagementService
      {
          public async Task<CustomerDto> AddCustomerAsync(CreateCustomerDto createCustomerDto)
          {
              // Implementação da adição de clientes
              return new CustomerDto
              {
                  Id = 1,
                  Name = createCustomerDto.Name,
                  Email = createCustomerDto.Email,
                  PhoneNumber = createCustomerDto.PhoneNumber
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ICustomerRelationshipManagementService, CustomerRelationshipManagementService>();
      ```

117. **(34 pontos) Implementar Sistema de Gestão de Contratos**
    - **Descrição**: Adicione um sistema para gerenciar contratos com fornecedores e clientes, incluindo renovação e expiração.
    - **Código**:
      ```csharp
      public class ContractManagementService : IContractManagementService
      {
          public async Task<ContractDto> AddContractAsync(CreateContractDto createContractDto)
          {
              // Implementação da adição de contratos
              return new ContractDto
              {
                  Id = 1,
                  SupplierId = createContractDto.SupplierId,
                  StartDate = createContractDto.StartDate,
                  EndDate = createContractDto.EndDate,
                  Terms = createContractDto.Terms
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IContractManagementService, ContractManagementService>();
      ```

118. **(34 pontos) Implementar Sistema de Avaliação de Desempenho de Funcionários**
    - **Descrição**: Adicione um sistema para avaliar o desempenho dos funcionários, incluindo feedback e metas.
    - **Código**:
      ```csharp
      public class EmployeePerformanceEvaluationService : IEmployeePerformanceEvaluationService
      {
          public async Task<EmployeeEvaluationDto> EvaluatePerformanceAsync(int employeeId)
          {
              // Implementação da avaliação de desempenho de funcionários
              return new EmployeeEvaluationDto
              {
                  EmployeeId = employeeId,
                  EvaluationScore = 85,
                  Feedback = "Excelente desempenho"
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IEmployeePerformanceEvaluationService, EmployeePerformanceEvaluationService>();
      ```

119. **(34 pontos) Implementar Sistema de Análise de Viabilidade de Projetos**
    - **Descrição**: Adicione um sistema para análise de viabilidade de novos projetos, incluindo custo-benefício e riscos.
    - **Código**:
      ```csharp
      public class ProjectFeasibilityAnalysisService : IProjectFeasibilityAnalysisService
      {
          public async Task<ProjectFeasibilityDto> AnalyzeFeasibilityAsync(int projectId)
          {
              // Implementação da análise de viabilidade de projetos
              return new ProjectFeasibilityDto
              {
                  ProjectId = projectId,
                  FeasibilityScore = 90,
                  Comments = "Projeto viável com alta taxa de retorno"
              };
          }
      }

      // Configuração no Program.cs


      builder.Services.AddSingleton<IProjectFeasibilityAnalysisService, ProjectFeasibilityAnalysisService>();
      ```

120. **(34 pontos) Implementar Sistema de Planejamento de Produção**
    - **Descrição**: Adicione um sistema para planejamento de produção, otimizando recursos e tempo.
    - **Código**:
      ```csharp
      public class ProductionPlanningService : IProductionPlanningService
      {
          public async Task<ProductionPlanDto> CreateProductionPlanAsync(CreateProductionPlanDto createProductionPlanDto)
          {
              // Implementação do planejamento de produção
              return new ProductionPlanDto
              {
                  PlanId = 1,
                  StartDate = createProductionPlanDto.StartDate,
                  EndDate = createProductionPlanDto.EndDate,
                  ResourcesRequired = createProductionPlanDto.ResourcesRequired
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IProductionPlanningService, ProductionPlanningService>();
      ```

121. **(34 pontos) Implementar Sistema de Automação de Processos**
    - **Descrição**: Adicione um sistema para automação de processos empresariais, reduzindo trabalho manual e aumentando a eficiência.
    - **Código**:
      ```csharp
      public class ProcessAutomationService : IProcessAutomationService
      {
          public async Task AutomateProcessAsync(ProcessDto process)
          {
              // Implementação da automação de processos
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IProcessAutomationService, ProcessAutomationService>();
      ```

122. **(34 pontos) Implementar Sistema de Monitoramento de Qualidade**
    - **Descrição**: Adicione um sistema para monitoramento de qualidade dos produtos, incluindo inspeções e testes.
    - **Código**:
      ```csharp
      public class QualityMonitoringService : IQualityMonitoringService
      {
          public async Task<QualityReportDto> MonitorQualityAsync(int productId)
          {
              // Implementação do monitoramento de qualidade
              return new QualityReportDto
              {
                  ProductId = productId,
                  QualityScore = 95,
                  Comments = "Produto de alta qualidade"
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IQualityMonitoringService, QualityMonitoringService>();
      ```

123. **(34 pontos) Implementar Sistema de Gestão de Recursos Financeiros**
    - **Descrição**: Adicione um sistema para gerenciar recursos financeiros, incluindo orçamento e despesas.
    - **Código**:
      ```csharp
      public class FinancialManagementService : IFinancialManagementService
      {
          public async Task<FinancialReportDto> GenerateReportAsync()
          {
              // Implementação da geração de relatórios financeiros
              return new FinancialReportDto
              {
                  TotalIncome = 100000,
                  TotalExpenses = 50000,
                  NetProfit = 50000
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<IFinancialManagementService, FinancialManagementService>();
      ```

124. **(34 pontos) Implementar Sistema de Análise de Competitividade**
    - **Descrição**: Adicione um sistema para analisar a competitividade da empresa, comparando com concorrentes.
    - **Código**:
      ```csharp
      public class CompetitivenessAnalysisService : ICompetitivenessAnalysisService
      {
          public async Task<CompetitivenessReportDto> AnalyzeCompetitivenessAsync()
          {
              // Implementação da análise de competitividade
              return new CompetitivenessReportDto
              {
                  CompanyScore = 85,
                  CompetitorScore = 80,
                  CompetitiveEdge = 5
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ICompetitivenessAnalysisService, CompetitivenessAnalysisService>();
      ```

125. **(34 pontos) Implementar Sistema de Gestão de Relacionamento com Fornecedores**
    - **Descrição**: Adicione um sistema para gerenciar o relacionamento com fornecedores, incluindo avaliação de desempenho e renovação de contratos.
    - **Código**:
      ```csharp
      public class SupplierRelationshipManagementService : ISupplierRelationshipManagementService
      {
          public async Task<SupplierDto> EvaluateSupplierAsync(int supplierId)
          {
              // Implementação da avaliação de fornecedores
              return new SupplierDto
              {
                  Id = supplierId,
                  Name = "Fornecedor Exemplo",
                  EvaluationScore = 90
              };
          }
      }

      // Configuração no Program.cs
      builder.Services.AddSingleton<ISupplierRelationshipManagementService, SupplierRelationshipManagementService>();
      ```
