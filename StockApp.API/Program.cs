using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog;
using StockApp.Application.Interfaces;
using StockApp.Application.Services;
using Comtele.Sdk.Services;
using StockApp.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

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

    string comteleApiKey = builder.Configuration["Comtele:ApiKey"];

    builder.Services.AddHttpClient<IPricingService, PricingService>(client =>
    {
        client.BaseAddress = new Uri("https://api.pricing.com/");
    });

    builder.Services.AddSingleton<ISmsService>(provider => new ComteleSmsService(comteleApiKey));
    builder.Services.AddInfrastructureAPI(builder.Configuration);
    builder.Services.AddInfrastructureJWT(builder.Configuration); // Certifique-se de que o namespace correto � importado
    builder.Services.AddInfrastructureSwagger();

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("adminPolicy", policy =>
            policy.RequireRole("admin"));
        options.AddPolicy("publisherPolicy", policy =>
            policy.RequireRole("publisher"));
        options.AddPolicy("userPolicy", policy =>
            policy.RequireRole("user"));
    });

    builder.Services.AddControllers();
        builder.Services.AddSingleton<IMarketTrendAnalysisService, MarketTrendAnalysisService>();

        var app = builder.Build();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }

    app.UseHttpsRedirection();
    app.UseStatusCodePages();
    app.UseRouting();

    if (app.Environment.IsDevelopment())
    {
        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
