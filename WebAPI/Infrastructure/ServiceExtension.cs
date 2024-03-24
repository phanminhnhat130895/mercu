using Application.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IInterviewerRepository, InterviewerRepository>();
        }
    }
}
