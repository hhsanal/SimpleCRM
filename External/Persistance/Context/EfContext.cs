using Domain.Abstractions;
using Domain.Entities;
using Domain.ProductBrands;
using Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Persistance.Context;

public partial class EfContext : IdentityDbContext<AppUser, AppRole, Guid>, IUnitOfWork
{
    public EfContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var statusProperty = Expression.Property(parameter, nameof(BaseEntity.Status));
                var filter = Expression.Lambda(Expression.Equal(statusProperty, Expression.Constant(true)), parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }

            var decimalProperties = entityType.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var property in decimalProperties)
            {
                property.SetPrecision(18);
                property.SetScale(6);
            }
        }
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        HttpContextAccessor httpContextAccessor = new();
        string userIdString = httpContextAccessor
            .HttpContext?
            .User?
            .Claims?
            .FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?
            .Value ?? "1";

        Guid UserId = Guid.Parse(userIdString);
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.CreateAt).CurrentValue = DateTime.Now;
                entry.Property(x => x.Status).CurrentValue = true;
                entry.Property(x => x.CreatedUserId)
                   .CurrentValue = UserId;
            }

            if (entry.State == EntityState.Modified)
            {
                if (entry.Property(p => p.Status).CurrentValue == false)
                {
                    entry.Property(x => x.DeleteAt).CurrentValue = DateTime.Now;
                    entry.Property(x => x.DeleteUserId).CurrentValue = UserId;
                }
                else
                {
                    entry.Property(x => x.UpdateAt).CurrentValue = DateTime.Now;
                    entry.Property(x => x.UpdatedUserId)
                      .CurrentValue = UserId;
                }
                    
            }
            if (entry.State == EntityState.Deleted)
            {
                throw new ArgumentException("Db'den direkt silme işlemi yapamazsınız");
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
   
}