using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Scrutor;

namespace Persistance
{
    public static class PersistanceRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext>(opt =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection")!;
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<EfContext>());
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<EfContext>();

             services.Scan(opt => opt
            .FromAssemblies(typeof(PersistanceRegister).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            return services;
        }
       
    }
}
