using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Repositories;
using StockApp.Infra.IoC;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructureAPI(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddSingleton<ICompetitivenessAnalysisService, CompetitivenessAnalysisService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers();
        builder.Services.AddSingleton<IEmployeePerformanceEvaluationService, EmployeePerformanceEvaluationService>();

        builder.Services.AddControllers();
        builder.Services.AddSingleton<IProcessAutomationService, ProcessAutomationService>();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //cart


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}