using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MindResult;

namespace Application
{
    public static class ApplicationRegister
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
         
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(ApplicationRegister).Assembly);
            });
            services.AddMindResult();
            services.AddValidatorsFromAssembly(typeof(ApplicationRegister).Assembly);
            return services;
        }
    }
}
