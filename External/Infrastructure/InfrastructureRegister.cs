using Application.Services;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;


namespace Infrastructure;

public static class InfrastructureRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(opt => opt
        .FromAssemblies(typeof(InfrastructureRegister).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}
