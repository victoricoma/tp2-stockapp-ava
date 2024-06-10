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

1. **(3 pontos) Criar o Modelo `Product` na Camada `Domain`**
   - **Descrição**: Adicione uma classe `Product` na camada `Domain` para representar os produtos.
   - **Código**:
     ```csharp
     public class Product
     {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Description { get; set; }
         public decimal Price { get; set; }
         public int Stock { get; set; }
     }
     ```

2. **(5 pontos) Criar Interface de Repositório para `Product`**
   - **Descrição**: Crie uma interface de repositório para `Product` na camada `Domain` para definir as operações CRUD.
   - **Código**:
     ```csharp
     public interface IProductRepository
     {
         Task<Product> GetByIdAsync(int id);
         Task<IEnumerable<Product>> GetAllAsync();
         Task AddAsync(Product product);
         Task UpdateAsync(Product product);
         Task DeleteAsync(int id);
     }
     ```

3. **(8 pontos) Implementar Repositório `Product` na Camada `Infra.Data`**
   - **Descrição**: Implemente o repositório `Product` na camada `Infra.Data` utilizando Entity Framework para interagir com o banco de dados Azure SQL Server.
   - **Código**:
     ```csharp
     public class ProductRepository : IProductRepository
     {
         private readonly AppDbContext _context;

         public ProductRepository(AppDbContext context)
         {
             _context = context;
         }

         public async Task<Product> GetByIdAsync(int id)
         {
             return await _context.Products.FindAsync(id);
         }

         public async Task<IEnumerable<Product>> GetAllAsync()
         {
             return await _context.Products.ToListAsync();
         }

         public async Task AddAsync(Product product)
         {
             _context.Products.Add(product);
             await _context.SaveChangesAsync();
         }

         public async Task UpdateAsync(Product product)
         {
             _context.Products.Update(product);
             await _context.SaveChangesAsync();
         }

         public async Task DeleteAsync(int id)
         {
             var product = await _context.Products.FindAsync(id);
             if (product != null)
             {
                 _context.Products.Remove(product);
                 await _context.SaveChangesAsync();
             }
         }
     }
     ```

4. **(13 pontos) Criar Endpoints de Leitura (`GetById` e `GetAll`) para `Product`**
   - **Descrição**: Crie os endpoints para obter um produto por ID e obter todos os produtos na camada `API`.
   - **Código**:
     ```csharp
     [ApiController]
     [Route("api/[controller]")]
     public class ProductsController : ControllerBase
     {
         private readonly IProductRepository _productRepository;

         public ProductsController(IProductRepository productRepository)
         {
             _productRepository = productRepository;
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> GetById(int id)
         {
             var product = await _productRepository.GetByIdAsync(id);
             if (product == null)
             {
                 return NotFound();
             }
             return Ok(product);
         }

         [HttpGet]
         public async Task<IActionResult> GetAll()
         {
             var products = await _productRepository.GetAllAsync();
             return Ok(products);
         }
     }
     ```

5. **(21 pontos) Implementar Segurança JWT na Camada `API`**
   - **Descrição**: Adicione autenticação JWT à camada `API` para proteger os endpoints.
   - **Introdução**: JSON Web Tokens (JWT) são um padrão aberto (RFC 7519) para representar reivindicações de forma segura entre duas partes. Para implementar JWT, é necessário configurar o middleware de autenticação e gerar tokens JWT para os usuários autenticados. [Documentação JWT em ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authentication?view=aspnetcore-5.0)
   - **Código**:
     ```csharp
     public void ConfigureServices(IServiceCollection services)
     {
         // Configuração do JWT
         var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
         services.AddAuthentication(x =>
         {
             x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         })
         .AddJwtBearer(x =>
         {
             x.RequireHttpsMetadata = false;
             x.SaveToken = true;
             x.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(key),
                 ValidateIssuer = false,
                 ValidateAudience = false
             };
         });

         services.AddControllers();
         services.AddSwaggerGen();
     }

     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
     {
         if (env.IsDevelopment())
         {
             app.UseDeveloperExceptionPage();
         }

         app.UseRouting();
         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
             endpoints.MapControllers();
         });

         app.UseSwagger();
         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
     }
     ```

6. **(34 pontos) Adicionar Middleware de Autorização JWT e Endpoint Protegido para `Product`**
   - **Descrição**: Adicione middleware de autorização JWT e proteja os endpoints de `Product`.
   - **Código**:
     ```csharp
     [Authorize]
     [ApiController]
     [Route("api/[controller]")]
     public class ProductsController : ControllerBase
     {
         // ... (restante do código)
     }
     ```

7. **(13 pontos) Criar Endpoint de Criação (`Create`) para `Product`**
   - **Descrição**: Crie o endpoint para adicionar um novo produto na camada `API`.
   - **Código**:
     ```csharp
     [HttpPost]
     public async Task<IActionResult> Create(Product product)
     {
         await _productRepository.AddAsync(product);
         return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
     }
     ```

8. **(21 pontos) Criar Endpoint de Atualização (`Update`) para `Product`**
   - **Descrição**: Crie o endpoint para atualizar um produto existente na camada `API`.
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

9. **(34 pontos) Criar Endpoint de Deleção (`Delete`) para `Product`**
   - **Descrição**: Crie o endpoint para deletar um produto existente na camada `API`.
   - **Código**:
     ```csharp
     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(int id)
     {
         await _productRepository.DeleteAsync(id);
         return NoContent();
     }
     ```

10. **(55 pontos) Implementar Logging Centralizado Usando Serilog e Integrar com Elastic Stack**
    - **Descrição**: Adicione logging centralizado usando Serilog e integre com Elastic Stack (Elasticsearch, Logstash, Kibana).
    - **Introdução**: Serilog é uma biblioteca de logging para .NET que permite registrar logs em diferentes formatos e destinos. Elastic Stack é uma suíte de ferramentas para busca, análise e visualização de dados em tempo real, amplamente usada para análise de logs. [Documentação Serilog](https://serilog.net/), [Documentação Elastic Stack](https://www.elastic.co/guide/index.html)
    - **Código**:
      ```csharp
      public void ConfigureServices(IServiceCollection services)
      {
          // Configuração do Serilog
          Log.Logger = new LoggerConfiguration()
              .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Configuration["ElasticConfiguration:Uri"]))
              {
                  AutoRegisterTemplate = true,
              })
              .CreateLogger();

          services.AddSingleton(Log.Logger);

          // ... (restante do código)
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
          if (env.IsDevelopment())
          {
              app.UseDeveloperExceptionPage();
          }

          app.UseSerilogRequestLogging();

          // ... (restante do código)
      }
      ```

