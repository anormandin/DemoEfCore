using Api.Application.Services;
using Api.Requests;

namespace Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ValidationService>();
        services.Scan( scan => scan
            .FromAssemblyOf<IService>()
            .AddClasses(classes => classes.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.AddValidatorsFromAssemblyContaining<CreateEmployeeRequestValidator>();

        return services;
    }
    
}