using Microsoft.EntityFrameworkCore;

namespace Shared.DataLayer.Persistence
{
    public abstract class ModuleDbContext : DbContext
    {
        protected abstract string Schema { get; }

        protected ModuleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Schema))
            {
                modelBuilder.HasDefaultSchema(Schema);
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
