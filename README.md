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

Essa arquitetura modular e desacoplada permite a escalabilidade, facilidade de manutenção e evolução da aplicação, seguindo os princípios da Clean Architecture para garantir a separação de responsabilidades e a independência das camadas.
