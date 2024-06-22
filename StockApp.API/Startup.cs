using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using StockApp.Infra.Data.Repositories;
using StockApp.Application.Mappings;
using System.Text;
using System.Security.Claims;

using System;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

       
        
          

        services.AddAuthorization(options =>
        {
            options.AddPolicy("adminPolicy", policy =>
                policy.RequireClaim(ClaimTypes.Role, "admin"));
        });

        services.AddScoped<IProductRepository, ProductRepository>();
       
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new DomainToDTOMappingProfile());
            mc.AddProfile(new DTOToCommandMappingProfile());
        });


        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

           

          
           

        // Configuração do CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
    
        });
    }

    private static void ConfigureServices1(IServiceCollection services)
    {
        services.AddSingleton<ISentimentAnalysisService, SentimentAnalysisService>();
        services.AddScoped<IFeedbackService, FeedbackService>();

        // Outros serviços podem ser configurados aqui
        services.AddControllers();

        services.AddSingleton<IJustInTimeInventoryService, JustInTimeInventoryService>();

    }
}
