using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StockApp.Application.Interfaces;
using StockApp.Application.Services;

namespace StockApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar servi�os
            builder.Services.AddSingleton<IDiscountService, DiscountService>();
            builder.Services.AddControllers();
            // Configura��o dos servi�os
            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICompetitivenessAnalysisService, CompetitivenessAnalysisService>();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IFinancialManagementService, FinancialManagementService>();

            // Configurar o Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StockApp API", Version = "v1" });
            });

            var app = builder.Build();

            // Configurar o ambiente de desenvolvimento
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockApp API v1");
                });
            }

            // Configurar middlewares, roteamento e autoriza��o
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRouting();

            app.Run();

            // Endpoint padr�o
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("StockApp API is running");
                });
            });

            

            // Configura��o dos servi�os
            builder.Services.AddControllers();
            builder.Services.AddSingleton<ISupplierRelationshipManagementService, SupplierRelationshipManagementService>();

           
            // Configura��o do pipeline de requisi��o HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
