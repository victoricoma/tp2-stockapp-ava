using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using Comtele.Sdk.Services;

public class Program
{
    public static void Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
         .MinimumLevel.Information()
         .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
         .Enrich.FromLogContext()
         .WriteTo.Console(new CompactJsonFormatter())
         .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
         .CreateLogger();

        try
        {
            Log.Information("Starting web host");

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }

        CreateHostBuilder(args).Build().Run();
        var builder = WebApplication.CreateBuilder(args);
        string comteleApiKey = builder.Configuration["Comtele:ApiKey"];

        builder.Services.AddHttpClient<IPricingService, PricingService>(client =>
        {
            client.BaseAddress = new Uri("https://api.pricing.com/");
        });

        builder.Services.AddSingleton<ISmsService>(provider => new ComteleSmsService(comteleApiKey));

        var app = builder.Build();

        app.Run();


        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console(new CompactJsonFormatter())
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try
        {
            Log.Information("Starting web host");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
