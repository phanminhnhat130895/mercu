using Serilog;
using WebAPI.Extensions;
using Application;
using Infrastructure;
using Infrastructure.Data;
using Serilog.Sinks.ApplicationInsights.TelemetryConverters;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(builder.Configuration.GetValue<string>("ApplicationInsights:ConnectionString"), new TraceTelemetryConverter())
                .CreateLogger();

            builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.ConfigureApplication();
            builder.Services.ConfigureInfrastructure(builder.Configuration);

            builder.Services.ConfigureApiBehavior();
            builder.Services.ConfigureCorsPolicy();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var serviceScope = app.Services.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
            dataContext?.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseErrorHandler();
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
