using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceExtension
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(typeof(AssemblyReference));
        }
    }
}
